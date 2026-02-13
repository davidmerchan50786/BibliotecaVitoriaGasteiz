using System;
using System.Data;
using System.Data.SQLite;
using Biblioteca_BBDD;

namespace BibliotecaVitoriaGasteiz.modelo
{
    /// <summary>
    /// Repositorio de Usuarios - Capa de acceso a datos
    /// 
    /// Esta clase es la ÚNICA que accede directamente a la tabla Usuarios en SQLite.
    /// Siguiendo el patrón MVC de los apuntes de clase:
    /// - El Controlador llama a estos métodos
    /// - Estos métodos ejecutan SQL a través de SQLiteHelper
    /// 
    /// IMPORTANTE: Uso parámetros (@nombre, @apellido1...) en vez de concatenar
    /// strings directamente en el SQL. Esto previene inyección SQL y es una
    /// buena práctica que vi en la documentación de Microsoft.
    /// 
    /// Desarrollador: David Merchan
    /// Proyecto: Biblioteca Vitoria-Gasteiz
    /// </summary>
    public class RepositorioUsuario
    {
        /// <summary>
        /// Inserta un nuevo usuario en la base de datos
        /// IMPORTANTE:
        /// ID: INTEGER PRIMARY KEY (se genera automáticamente)
        /// Apellido_2 es opcional
        /// Si viene null desde C#, lo convierto a DBNull.Value para SQLite.
        /// </summary>
        public void Insertar(Usuario usuario)
        {
            string sql = "INSERT INTO Usuarios (Nombre, Apellido_1, Apellido_2, Telefono) VALUES (@nombre, @apellido1, @apellido2, @telefono)";
            SQLiteCommand cmd = new SQLiteCommand(sql);

            // Añado los parámetros para evitar inyección SQL
            cmd.Parameters.Add("@nombre", DbType.String).Value = usuario.Nombre;
            cmd.Parameters.Add("@apellido1", DbType.String).Value = usuario.Apellido1;

            // Apellido_2 puede ser null
            // El operador ?? dice: "si es null, usa DBNull.Value; si no, usa el valor"
            cmd.Parameters.Add("@apellido2", DbType.String).Value = usuario.Apellido2 ?? (object)DBNull.Value;

            cmd.Parameters.Add("@telefono", DbType.Int32).Value = usuario.Telefono;

            // Ejecuto el INSERT usando SQLiteHelper (clase del profesor)
            SQLiteHelper.Ejecuta(Properties.Settings.Default.conexion, cmd);
        }

        /// <summary>
        /// Modifica un usuario existente en la base de datos
        /// Actualiza todos los campos excepto el ID.
        /// El ID se usa en la cláusula WHERE para identificar qué usuario modificar.
        /// </summary>
        public void Modificar(Usuario usuario)
        {
            string sql = "UPDATE Usuarios SET Nombre=@nombre, Apellido_1=@apellido1, Apellido_2=@apellido2, Telefono=@telefono WHERE ID=@id";
            SQLiteCommand cmd = new SQLiteCommand(sql);

            cmd.Parameters.Add("@id", DbType.Int32).Value = usuario.Id;
            cmd.Parameters.Add("@nombre", DbType.String).Value = usuario.Nombre;
            cmd.Parameters.Add("@apellido1", DbType.String).Value = usuario.Apellido1;
            cmd.Parameters.Add("@apellido2", DbType.String).Value = usuario.Apellido2 ?? (object)DBNull.Value;
            cmd.Parameters.Add("@telefono", DbType.Int32).Value = usuario.Telefono;

            SQLiteHelper.Ejecuta(Properties.Settings.Default.conexion, cmd);
        }

        /// <summary>
        /// Elimina un usuario de la base de datos
        /// PRECAUCIÓN: Si este usuario tiene préstamos activos, podría causar
        /// problemas de integridad referencial.
        /// La validación de si tiene préstamos activos se hace en el Controlador,
        /// </summary>
        public void Eliminar(int id)
        {
            string sql = "DELETE FROM Usuarios WHERE ID=@id";
            SQLiteCommand cmd = new SQLiteCommand(sql);
            cmd.Parameters.Add("@id", DbType.Int32).Value = id;
            SQLiteHelper.Ejecuta(Properties.Settings.Default.conexion, cmd);
        }

        /// <summary>
        /// Obtiene todos los usuarios de la biblioteca
        /// Los ordeno alfabéticamente por Nombre y luego por Apellido_1.
        /// Así la lista queda más organizada y fácil de navegar.
        /// Devuelve un DataTable con todas las columnas de la tabla Usuarios.
        /// </summary>
        public DataTable ObtenerTodos()
        {
            string sql = "SELECT * FROM Usuarios ORDER BY Nombre, Apellido_1";
            SQLiteCommand cmd = new SQLiteCommand(sql);
            return SQLiteHelper.GetDataTable(Properties.Settings.Default.conexion, cmd);
        }

        /// <summary>
        /// Busca un usuario específico por su ID
        /// Devuelve un DataTable con 0 o 1 filas:
        /// - 0 filas: El usuario no existe
        /// - 1 fila: El usuario existe y devuelve todos sus datos
        /// Se usa cuando necesito información de un usuario concreto.
        /// </summary>
        public DataTable BuscarPorId(int id)
        {
            string sql = "SELECT * FROM Usuarios WHERE ID=@id";
            SQLiteCommand cmd = new SQLiteCommand(sql);
            cmd.Parameters.Add("@id", DbType.Int32).Value = id;
            return SQLiteHelper.GetDataTable(Properties.Settings.Default.conexion, cmd);
        }

        /// <summary>
        /// Busca usuarios que coincidan con un término de búsqueda 
        /// BÚSQUEDA FLEXIBLE con LIKE:
        /// Busca en tres campos: Nombre, Apellido_1 y Apellido_2
        /// El operador LIKE con % permite coincidencias parciales:
        /// - Si busco "Juan", encuentra "Juan", "Juan Carlos", "María Juan", etc.
        /// Es mucho más útil que una búsqueda exacta (=).
        /// </summary>
        public DataTable Buscar(string termino)
        {
            string sql = "SELECT * FROM Usuarios WHERE Nombre LIKE @termino OR Apellido_1 LIKE @termino OR Apellido_2 LIKE @termino ORDER BY Nombre, Apellido_1";
            SQLiteCommand cmd = new SQLiteCommand(sql);

            // Añado % antes y después del término para buscar en cualquier parte
            // Ejemplo: si termino = "Juan", @termino = "%Juan%"
            cmd.Parameters.Add("@termino", DbType.String).Value = "%" + termino + "%";

            return SQLiteHelper.GetDataTable(Properties.Settings.Default.conexion, cmd);
        }

        /// <summary>
        /// Busca un usuario por su número de teléfono
        /// BÚSQUEDA EXACTA: Uso = en vez de LIKE
        /// porque el teléfono debe coincidir completamente.
        /// Útil para verificar si un teléfono ya está registrado
        /// o para buscar usuarios por su número.
        /// </summary>
        public DataTable BuscarPorTelefono(int telefono)
        {
            string sql = "SELECT * FROM Usuarios WHERE Telefono = @telefono";
            SQLiteCommand cmd = new SQLiteCommand(sql);
            cmd.Parameters.Add("@telefono", DbType.Int32).Value = telefono;
            return SQLiteHelper.GetDataTable(Properties.Settings.Default.conexion, cmd);
        }
    }
}