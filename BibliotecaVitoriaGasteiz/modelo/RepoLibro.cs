using System;
using System.Data;
using System.Data.SQLite;
using Biblioteca_BBDD;

namespace BibliotecaVitoriaGasteiz.modelo
{
    /// <summary>
    /// Repositorio de Libros - Capa de Acceso a Datos
    /// 
    /// Esta clase es la ÚNICA responsable de ejecutar sentencias SQL contra la tabla 'Libros'.
    /// Sigue el principio de Responsabilidad Única (SRP).
    /// 
    /// NOTA TÉCNICA:
    /// SQLite no tiene tipo booleano nativo. Convertimos:
    /// - C# true  -> SQLite 1
    /// - C# false -> SQLite 0
    /// 
    /// Desarrollador: David Merchan
    /// Proyecto: Biblioteca Vitoria-Gasteiz
    /// </summary>
    public class RepositorioLibro
    {
        /// <summary>
        /// Inserta un nuevo libro en la base de datos.
        /// </summary>
        /// <param name="libro">Objeto Libro con los datos a guardar.</param>
        public void Insertar(Libro libro)
        {
            // Usamos los nombres reales de las columnas
            string sql = "INSERT INTO Libros (Titulo, Escritor, Ano_Edicion, Sinopsis, Disponible) VALUES (@titulo, @escritor, @anoEdicion, @sinopsis, @disponible)";

            SQLiteCommand cmd = new SQLiteCommand(sql);

            // Asignación de parámetros segura contra inyección SQL
            cmd.Parameters.Add("@titulo", DbType.String).Value = libro.Titulo;
            cmd.Parameters.Add("@escritor", DbType.String).Value = libro.Escritor;

            // Manejo de nulos para Ano_Edicion
            cmd.Parameters.Add("@anoEdicion", DbType.Int32).Value = libro.Ano_Edicion ?? (object)DBNull.Value;

            cmd.Parameters.Add("@sinopsis", DbType.String).Value = libro.Sinopsis ?? "";

            // Conversión explícita Bool -> Int para SQLite
            cmd.Parameters.Add("@disponible", DbType.Int32).Value = libro.Disponible ? 1 : 0;

            SQLiteHelper.Ejecuta(Properties.Settings.Default.conexion, cmd);
        }

        /// <summary>
        /// Modifica un libro existente. Actualiza todos sus campos basándose en el ID.
        /// </summary>
        /// <param name="libro">Objeto Libro con los datos modificados.</param>
        public void Modificar(Libro libro)
        {
            string sql = "UPDATE Libros SET Titulo=@titulo, Escritor=@escritor, Ano_Edicion=@anoEdicion, Sinopsis=@sinopsis, Disponible=@disponible WHERE ID=@id";

            SQLiteCommand cmd = new SQLiteCommand(sql);

            // IMPORTANTE: Aquí usamos la propiedad ID (en mayúsculas) corregida en la clase Libro
            cmd.Parameters.Add("@id", DbType.Int32).Value = libro.ID;
            cmd.Parameters.Add("@titulo", DbType.String).Value = libro.Titulo;
            cmd.Parameters.Add("@escritor", DbType.String).Value = libro.Escritor;
            cmd.Parameters.Add("@anoEdicion", DbType.Int32).Value = libro.Ano_Edicion ?? (object)DBNull.Value;
            cmd.Parameters.Add("@sinopsis", DbType.String).Value = libro.Sinopsis ?? "";
            cmd.Parameters.Add("@disponible", DbType.Int32).Value = libro.Disponible ? 1 : 0;

            SQLiteHelper.Ejecuta(Properties.Settings.Default.conexion, cmd);
        }

        /// <summary>
        /// Elimina un libro de la base de datos por su identificador.
        /// </summary>
        /// <param name="id">ID del libro a eliminar.</param>
        public void Eliminar(int id)
        {
            string sql = "DELETE FROM Libros WHERE ID=@id";
            SQLiteCommand cmd = new SQLiteCommand(sql);
            cmd.Parameters.Add("@id", DbType.Int32).Value = id;
            SQLiteHelper.Ejecuta(Properties.Settings.Default.conexion, cmd);
        }

        /// <summary>
        /// Obtiene el catálogo completo de libros, ordenado alfabéticamente por título.
        /// </summary>
        /// <returns>DataTable con todos los libros.</returns>
        public DataTable ObtenerTodos()
        {
            string sql = "SELECT * FROM Libros ORDER BY Titulo";
            SQLiteCommand cmd = new SQLiteCommand(sql);
            return SQLiteHelper.GetDataTable(Properties.Settings.Default.conexion, cmd);
        }

        /// <summary>
        /// Obtiene únicamente los libros que están disponibles para préstamo.
        /// Filtra donde la columna 'Disponible' es 1.
        /// </summary>
        /// <returns>DataTable con libros disponibles.</returns>
        public DataTable ObtenerDisponibles()
        {
            string sql = "SELECT * FROM Libros WHERE Disponible = 1 ORDER BY Titulo";
            SQLiteCommand cmd = new SQLiteCommand(sql);
            return SQLiteHelper.GetDataTable(Properties.Settings.Default.conexion, cmd);
        }

        /// <summary>
        /// Busca un libro específico por su clave primaria.
        /// </summary>
        /// <param name="id">ID del libro buscado.</param>
        /// <returns>DataTable con 0 o 1 fila.</returns>
        public DataTable BuscarPorId(int id)
        {
            string sql = "SELECT * FROM Libros WHERE ID=@id";
            SQLiteCommand cmd = new SQLiteCommand(sql);
            cmd.Parameters.Add("@id", DbType.Int32).Value = id;
            return SQLiteHelper.GetDataTable(Properties.Settings.Default.conexion, cmd);
        }

        /// <summary>
        /// Realiza una búsqueda flexible por Título o Autor.
        /// Utiliza el operador LIKE para coincidencias parciales.
        /// </summary>
        /// <param name="termino">Texto a buscar (ej: "Quijote").</param>
        /// <returns>DataTable con los resultados coincidentes.</returns>
        public DataTable Buscar(string termino)
        {
            string sql = "SELECT * FROM Libros WHERE Titulo LIKE @termino OR Escritor LIKE @termino ORDER BY Titulo";
            SQLiteCommand cmd = new SQLiteCommand(sql);
            cmd.Parameters.Add("@termino", DbType.String).Value = "%" + termino + "%";
            return SQLiteHelper.GetDataTable(Properties.Settings.Default.conexion, cmd);
        }

        /// <summary>
        /// Actualiza únicamente el estado de disponibilidad de un libro.
        /// Método optimizado para ser llamado cuando se realiza o devuelve un préstamo.
        /// </summary>
        /// <param name="id">ID del libro.</param>
        /// <param name="disponible">Nuevo estado (true/false).</param>
        public void CambiarDisponibilidad(int id, bool disponible)
        {
            string sql = "UPDATE Libros SET Disponible = @disponible WHERE ID = @id";
            SQLiteCommand cmd = new SQLiteCommand(sql);
            cmd.Parameters.Add("@id", DbType.Int32).Value = id;
            cmd.Parameters.Add("@disponible", DbType.Int32).Value = disponible ? 1 : 0;
            SQLiteHelper.Ejecuta(Properties.Settings.Default.conexion, cmd);
        }
    }
}