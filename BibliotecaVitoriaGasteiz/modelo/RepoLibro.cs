using System;
using System.Data;
using System.Data.SQLite;
using Biblioteca_BBDD;

namespace BibliotecaVitoriaGasteiz.modelo
{
    /// <summary>
    /// Repositorio de Libros - Capa de acceso a datos
    /// 
    /// Esta clase es la ÚNICA que accede directamente a la tabla Libros en SQLite.
    /// 
    /// IMPORTANTE: El campo Disponible se guarda como INTEGER en SQLite:
    /// - 1 = true (disponible para préstamo)
    /// - 0 = false (prestado, no disponible)
    /// 
    /// En C# trabajo con bool, pero tengo que convertirlo a 1/0 para SQLite.
    /// Esto es porque SQLite no tiene un tipo BOOLEAN nativo.
    /// Lo aprendí de la documentación de SQLite en clase.
    /// 
    /// Desarrollador: David
    /// Proyecto: Biblioteca Ayuntamiento Vitoria-Gasteiz
    /// </summary>
    public class RepositorioLibro
    {
        /// <summary>
        /// Inserta un nuevo libro en la base de datos
        /// 
        /// ESTRUCTURA DE LA TABLA LIBROS:
        /// - ID: INTEGER PRIMARY KEY (se genera automáticamente)
        /// - Titulo: TEXT NOT NULL
        /// - Escritor: TEXT NOT NULL
        /// - Ano_Edicion: INTEGER (puede ser NULL)
        /// - Sinopsis: TEXT (puede ser NULL)
        /// - Disponible: INTEGER (1 = disponible, 0 = prestado)
        /// 
        /// CAMPOS OPCIONALES:
        /// - Ano_Edicion: Si es null, guardo DBNull.Value
        /// - Sinopsis: Si es null, guardo cadena vacía ""
        /// 
        /// Por defecto, los libros nuevos se crean como Disponible = 1 (true).
        /// </summary>
        public void Insertar(Libro libro)
        {
            string sql = "INSERT INTO Libros (Titulo, Escritor, Ano_Edicion, Sinopsis, Disponible) VALUES (@titulo, @escritor, @anoEdicion, @sinopsis, @disponible)";
            SQLiteCommand cmd = new SQLiteCommand(sql);

            cmd.Parameters.Add("@titulo", DbType.String).Value = libro.Titulo;
            cmd.Parameters.Add("@escritor", DbType.String).Value = libro.Escritor;

            // Año de edición es opcional (nullable int)
            cmd.Parameters.Add("@anoEdicion", DbType.Int32).Value = libro.AnoEdicion ?? (object)DBNull.Value;

            // Sinopsis es opcional, pero guardo "" en vez de null
            cmd.Parameters.Add("@sinopsis", DbType.String).Value = libro.Sinopsis ?? "";

            // Convertir bool a int para SQLite (true ? 1, false ? 0)
            cmd.Parameters.Add("@disponible", DbType.Int32).Value = libro.Disponible ? 1 : 0;

            SQLiteHelper.Ejecuta(Properties.Settings.Default.conexion, cmd);
        }

        /// <summary>
        /// Modifica un libro existente en la base de datos
        /// 
        /// Actualiza todos los campos excepto el ID.
        /// El campo Disponible normalmente se modifica desde CambiarDisponibilidad(),
        /// pero también puede cambiarse desde aquí si se edita el libro completo.
        /// </summary>
        public void Modificar(Libro libro)
        {
            string sql = "UPDATE Libros SET Titulo=@titulo, Escritor=@escritor, Ano_Edicion=@anoEdicion, Sinopsis=@sinopsis, Disponible=@disponible WHERE ID=@id";
            SQLiteCommand cmd = new SQLiteCommand(sql);

            cmd.Parameters.Add("@id", DbType.Int32).Value = libro.Id;
            cmd.Parameters.Add("@titulo", DbType.String).Value = libro.Titulo;
            cmd.Parameters.Add("@escritor", DbType.String).Value = libro.Escritor;
            cmd.Parameters.Add("@anoEdicion", DbType.Int32).Value = libro.AnoEdicion ?? (object)DBNull.Value;
            cmd.Parameters.Add("@sinopsis", DbType.String).Value = libro.Sinopsis ?? "";
            cmd.Parameters.Add("@disponible", DbType.Int32).Value = libro.Disponible ? 1 : 0;

            SQLiteHelper.Ejecuta(Properties.Settings.Default.conexion, cmd);
        }

        /// <summary>
        /// Elimina un libro de la base de datos
        /// 
        /// PRECAUCIÓN: Si este libro tiene préstamos asociados, podría causar
        /// problemas de integridad referencial.
        /// La validación se hace en el Controlador, no aquí.
        /// </summary>
        public void Eliminar(int id)
        {
            string sql = "DELETE FROM Libros WHERE ID=@id";
            SQLiteCommand cmd = new SQLiteCommand(sql);
            cmd.Parameters.Add("@id", DbType.Int32).Value = id;
            SQLiteHelper.Ejecuta(Properties.Settings.Default.conexion, cmd);
        }

        /// <summary>
        /// Obtiene todos los libros de la biblioteca
        /// 
        /// Los ordeno alfabéticamente por Título.
        /// Así es más fácil navegar por la lista de libros.
        /// 
        /// Devuelve tanto libros disponibles como prestados.
        /// Para obtener solo disponibles, usar ObtenerDisponibles().
        /// </summary>
        public DataTable ObtenerTodos()
        {
            string sql = "SELECT * FROM Libros ORDER BY Titulo";
            SQLiteCommand cmd = new SQLiteCommand(sql);
            return SQLiteHelper.GetDataTable(Properties.Settings.Default.conexion, cmd);
        }

        /// <summary>
        /// Obtiene solo los libros DISPONIBLES para préstamo
        /// 
        /// Filtro: WHERE Disponible = 1
        /// 
        /// Esta consulta es la que uso en FormPrestamos para llenar
        /// el ComboBox de libros. No tiene sentido mostrar libros
        /// ya prestados cuando alguien quiere realizar un préstamo.
        /// 
        /// Esta separación de métodos (ObtenerTodos vs ObtenerDisponibles)
        /// hace el código más claro y evita filtrar en la interfaz.
        /// </summary>
        public DataTable ObtenerDisponibles()
        {
            string sql = "SELECT * FROM Libros WHERE Disponible = 1 ORDER BY Titulo";
            SQLiteCommand cmd = new SQLiteCommand(sql);
            return SQLiteHelper.GetDataTable(Properties.Settings.Default.conexion, cmd);
        }

        /// <summary>
        /// Busca un libro específico por su ID
        /// 
        /// Se usa en FormDetalleLibro para cargar la información
        /// completa de un libro cuando se hace click en "Ver Detalles".
        /// 
        /// Devuelve un DataTable con 0 o 1 filas.
        /// </summary>
        public DataTable BuscarPorId(int id)
        {
            string sql = "SELECT * FROM Libros WHERE ID=@id";
            SQLiteCommand cmd = new SQLiteCommand(sql);
            cmd.Parameters.Add("@id", DbType.Int32).Value = id;
            return SQLiteHelper.GetDataTable(Properties.Settings.Default.conexion, cmd);
        }

        /// <summary>
        /// Busca libros que coincidan con un término de búsqueda
        /// 
        /// BÚSQUEDA FLEXIBLE con LIKE:
        /// Busca en dos campos: Titulo y Escritor
        /// Permite coincidencias parciales:
        /// - Si busco "Quijote", encuentra "Don Quijote de la Mancha"
        /// - Si busco "Cervan", encuentra "Miguel de Cervantes"
        /// 
        /// Esta búsqueda se usa en el TextBox de búsqueda de FormLibros
        /// para filtrar las TarjetaLibro en tiempo real mientras se escribe.
        /// 
        /// Es mucho más cómodo que tener que escribir el título completo.
        /// </summary>
        public DataTable Buscar(string termino)
        {
            string sql = "SELECT * FROM Libros WHERE Titulo LIKE @termino OR Escritor LIKE @termino ORDER BY Titulo";
            SQLiteCommand cmd = new SQLiteCommand(sql);

            // Añado % antes y después para buscar en cualquier parte
            cmd.Parameters.Add("@termino", DbType.String).Value = "%" + termino + "%";

            return SQLiteHelper.GetDataTable(Properties.Settings.Default.conexion, cmd);
        }

        /// <summary>
        /// Cambia la disponibilidad de un libro
        /// 
        /// Este método es FUNDAMENTAL para la lógica de préstamos:
        /// 
        /// CUANDO SE PRESTA UN LIBRO:
        /// - CambiarDisponibilidad(idLibro, false) ? Disponible = 0
        /// 
        /// CUANDO SE DEVUELVE UN LIBRO:
        /// - CambiarDisponibilidad(idLibro, true) ? Disponible = 1
        /// 
        /// Esto se llama automáticamente desde PrestamoControlador.
        /// Mantiene sincronizados los préstamos con la disponibilidad de los libros.
        /// 
        /// Si no hiciera esto, un libro podría prestarse múltiples veces
        /// porque siempre aparecería como disponible.
        /// </summary>
        public void CambiarDisponibilidad(int id, bool disponible)
        {
            string sql = "UPDATE Libros SET Disponible = @disponible WHERE ID = @id";
            SQLiteCommand cmd = new SQLiteCommand(sql);

            cmd.Parameters.Add("@id", DbType.Int32).Value = id;

            // Convertir bool a int (true ? 1, false ? 0)
            cmd.Parameters.Add("@disponible", DbType.Int32).Value = disponible ? 1 : 0;

            SQLiteHelper.Ejecuta(Properties.Settings.Default.conexion, cmd);
        }
    }
}