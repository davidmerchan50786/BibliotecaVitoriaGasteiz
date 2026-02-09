using System;
using System.Data;
using System.Data.SQLite;
using Biblioteca_BBDD;

namespace BibliotecaVitoriaGasteiz.modelo
{
    public class RepositorioUsuario
    {
        public void Insertar(Usuario usuario)
        {
            string sql = "INSERT INTO Usuarios (Nombre, Apellido_1, Apellido_2, Telefono) VALUES (@nombre, @apellido1, @apellido2, @telefono)";
            SQLiteCommand cmd = new SQLiteCommand(sql);

            cmd.Parameters.Add("@nombre", DbType.String).Value = usuario.Nombre;
            cmd.Parameters.Add("@apellido1", DbType.String).Value = usuario.Apellido1;
            cmd.Parameters.Add("@apellido2", DbType.String).Value = usuario.Apellido2 ?? (object)DBNull.Value;
            cmd.Parameters.Add("@telefono", DbType.Int32).Value = usuario.Telefono;

            SQLiteHelper.Ejecuta(Properties.Settings.Default.conexion, cmd);
        }

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

        public void Eliminar(int id)
        {
            string sql = "DELETE FROM Usuarios WHERE ID=@id";
            SQLiteCommand cmd = new SQLiteCommand(sql);
            cmd.Parameters.Add("@id", DbType.Int32).Value = id;
            SQLiteHelper.Ejecuta(Properties.Settings.Default.conexion, cmd);
        }

        public DataTable ObtenerTodos()
        {
            string sql = "SELECT * FROM Usuarios ORDER BY Nombre, Apellido_1";
            SQLiteCommand cmd = new SQLiteCommand(sql);
            return SQLiteHelper.GetDataTable(Properties.Settings.Default.conexion, cmd);
        }

        public DataTable BuscarPorId(int id)
        {
            string sql = "SELECT * FROM Usuarios WHERE ID=@id";
            SQLiteCommand cmd = new SQLiteCommand(sql);
            cmd.Parameters.Add("@id", DbType.Int32).Value = id;
            return SQLiteHelper.GetDataTable(Properties.Settings.Default.conexion, cmd);
        }

        public DataTable Buscar(string termino)
        {
            string sql = "SELECT * FROM Usuarios WHERE Nombre LIKE @termino OR Apellido_1 LIKE @termino OR Apellido_2 LIKE @termino ORDER BY Nombre, Apellido_1";
            SQLiteCommand cmd = new SQLiteCommand(sql);
            cmd.Parameters.Add("@termino", DbType.String).Value = "%" + termino + "%";
            return SQLiteHelper.GetDataTable(Properties.Settings.Default.conexion, cmd);
        }

        public DataTable BuscarPorTelefono(int telefono)
        {
            string sql = "SELECT * FROM Usuarios WHERE Telefono = @telefono";
            SQLiteCommand cmd = new SQLiteCommand(sql);
            cmd.Parameters.Add("@telefono", DbType.Int32).Value = telefono;
            return SQLiteHelper.GetDataTable(Properties.Settings.Default.conexion, cmd);
        }
    }
}
