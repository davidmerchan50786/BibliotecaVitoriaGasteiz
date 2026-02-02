using System;
using System.Data;
using System.Data.SQLite;

namespace Proyecto_compartido_biblioteca.modelo
{
    public class RepositorioLibro
    {
        public void Insertar(Libro libro)
        {
            string sql = "INSERT INTO Libros (Titulo, Escritor, Ano_Edicion, Sinopsis, Disponible) VALUES (@titulo, @escritor, @anoEdicion, @sinopsis, @disponible)";
            SQLiteCommand cmd = new SQLiteCommand(sql);

            cmd.Parameters.Add("@titulo", DbType.String).Value = libro.Titulo;
            cmd.Parameters.Add("@escritor", DbType.String).Value = libro.Escritor;
            cmd.Parameters.Add("@anoEdicion", DbType.Int32).Value = libro.AnoEdicion ?? (object)DBNull.Value;
            cmd.Parameters.Add("@sinopsis", DbType.String).Value = libro.Sinopsis ?? "";
            cmd.Parameters.Add("@disponible", DbType.Int32).Value = libro.Disponible ? 1 : 0;

            SQLiteHelper.Ejecuta(Properties.Settings.Default.conexion, cmd);
        }

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

        public void Eliminar(int id)
        {
            string sql = $"DELETE FROM Libros WHERE ID={id}";
            SQLiteCommand cmd = new SQLiteCommand(sql);
            SQLiteHelper.Ejecuta(Properties.Settings.Default.conexion, cmd);
        }

        public DataTable ObtenerTodos()
        {
            string sql = "SELECT * FROM Libros";
            SQLiteCommand cmd = new SQLiteCommand(sql);
            return SQLiteHelper.GetDataTable(Properties.Settings.Default.conexion, cmd);
        }

        public DataTable ObtenerDisponibles()
        {
            string sql = "SELECT * FROM Libros WHERE Disponible = 1";
            SQLiteCommand cmd = new SQLiteCommand(sql);
            return SQLiteHelper.GetDataTable(Properties.Settings.Default.conexion, cmd);
        }

        public DataTable BuscarPorId(int id)
        {
            string sql = $"SELECT * FROM Libros WHERE ID={id}";
            SQLiteCommand cmd = new SQLiteCommand(sql);
            return SQLiteHelper.GetDataTable(Properties.Settings.Default.conexion, cmd);
        }

        public DataTable Buscar(string termino)
        {
            string sql = "SELECT * FROM Libros WHERE Titulo LIKE @termino OR Escritor LIKE @termino";
            SQLiteCommand cmd = new SQLiteCommand(sql);
            cmd.Parameters.Add("@termino", DbType.String).Value = "%" + termino + "%";
            return SQLiteHelper.GetDataTable(Properties.Settings.Default.conexion, cmd);
        }

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