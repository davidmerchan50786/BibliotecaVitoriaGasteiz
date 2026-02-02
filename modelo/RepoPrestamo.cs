using System;
using System.Data;
using System.Data.SQLite;

namespace Proyecto_compartido_biblioteca.modelo
{
	public class RepositorioPrestamo
	{
		public void RealizarPrestamo(int idLibro, int idUsuario, string fechaInicio, string fechaFin)
		{
			string sql = "INSERT INTO Prestamos (ID_Libro, ID_Usuario, Fecha_Inicio, Fecha_Fin) VALUES (@idLibro, @idUsuario, @fechaInicio, @fechaFin)";
			SQLiteCommand cmd = new SQLiteCommand(sql);

			cmd.Parameters.Add("@idLibro", DbType.Int32).Value = idLibro;
			cmd.Parameters.Add("@idUsuario", DbType.Int32).Value = idUsuario;
			cmd.Parameters.Add("@fechaInicio", DbType.String).Value = fechaInicio;
			cmd.Parameters.Add("@fechaFin", DbType.String).Value = fechaFin;

			SQLiteHelper.Ejecuta(Properties.Settings.Default.conexion, cmd);
		}

		public void Eliminar(int id)
		{
			string sql = $"DELETE FROM Prestamos WHERE ID={id}";
			SQLiteCommand cmd = new SQLiteCommand(sql);
			SQLiteHelper.Ejecuta(Properties.Settings.Default.conexion, cmd);
		}

		public DataTable ObtenerTodos()
		{
			string sql = @"SELECT p.ID, p.Fecha_Inicio, p.Fecha_Fin,
                           l.ID AS LibroId, l.Titulo,
                           u.ID AS UsuarioId, u.Nombre || ' ' || u.Apellido_1 || ' ' || IFNULL(u.Apellido_2, '') AS NombreUsuario
                           FROM Prestamos p
                           INNER JOIN Libros l ON p.ID_Libro = l.ID
                           INNER JOIN Usuarios u ON p.ID_Usuario = u.ID
                           ORDER BY p.Fecha_Inicio DESC";
			SQLiteCommand cmd = new SQLiteCommand(sql);
			return SQLiteHelper.GetDataTable(Properties.Settings.Default.conexion, cmd);
		}

		public DataTable BuscarPorId(int id)
		{
			string sql = $"SELECT * FROM Prestamos WHERE ID={id}";
			SQLiteCommand cmd = new SQLiteCommand(sql);
			return SQLiteHelper.GetDataTable(Properties.Settings.Default.conexion, cmd);
		}

		public DataTable BuscarPorUsuario(int idUsuario)
		{
			string sql = @"SELECT p.ID, p.Fecha_Inicio, p.Fecha_Fin,
                           l.ID AS LibroId, l.Titulo
                           FROM Prestamos p
                           INNER JOIN Libros l ON p.ID_Libro = l.ID
                           WHERE p.ID_Usuario = @idUsuario
                           ORDER BY p.Fecha_Inicio DESC";
			SQLiteCommand cmd = new SQLiteCommand(sql);
			cmd.Parameters.Add("@idUsuario", DbType.Int32).Value = idUsuario;
			return SQLiteHelper.GetDataTable(Properties.Settings.Default.conexion, cmd);
		}

		public DataTable BuscarPorLibro(int idLibro)
		{
			string sql = @"SELECT p.ID, p.Fecha_Inicio, p.Fecha_Fin,
                           u.ID AS UsuarioId, u.Nombre || ' ' || u.Apellido_1 AS NombreUsuario
                           FROM Prestamos p
                           INNER JOIN Usuarios u ON p.ID_Usuario = u.ID
                           WHERE p.ID_Libro = @idLibro
                           ORDER BY p.Fecha_Inicio DESC";
			SQLiteCommand cmd = new SQLiteCommand(sql);
			cmd.Parameters.Add("@idLibro", DbType.Int32).Value = idLibro;
			return SQLiteHelper.GetDataTable(Properties.Settings.Default.conexion, cmd);
		}
	}
}