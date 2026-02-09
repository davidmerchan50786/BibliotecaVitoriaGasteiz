using System;
using System.Data;
using System.Data.SQLite;
using Biblioteca_BBDD;

namespace BibliotecaVitoriaGasteiz.modelo
{
    public class RepositorioPrestamo
    {
        public void Insertar(Prestamo prestamo)
        {
            string sql = "INSERT INTO Prestamos (ID_Libro, ID_Usuario, Fecha_Inicio, Fecha_Fin) VALUES (@idLibro, @idUsuario, @fechaInicio, @fechaFin)";
            SQLiteCommand cmd = new SQLiteCommand(sql);

            cmd.Parameters.Add("@idLibro", DbType.Int32).Value = prestamo.IdLibro;
            cmd.Parameters.Add("@idUsuario", DbType.Int32).Value = prestamo.IdUsuario;
            cmd.Parameters.Add("@fechaInicio", DbType.String).Value = prestamo.FechaInicio;
            cmd.Parameters.Add("@fechaFin", DbType.String).Value = prestamo.FechaFin;

            SQLiteHelper.Ejecuta(Properties.Settings.Default.conexion, cmd);
        }

        public void Modificar(Prestamo prestamo)
        {
            string sql = "UPDATE Prestamos SET ID_Libro=@idLibro, ID_Usuario=@idUsuario, Fecha_Inicio=@fechaInicio, Fecha_Fin=@fechaFin WHERE ID=@id";
            SQLiteCommand cmd = new SQLiteCommand(sql);

            cmd.Parameters.Add("@id", DbType.Int32).Value = prestamo.Id;
            cmd.Parameters.Add("@idLibro", DbType.Int32).Value = prestamo.IdLibro;
            cmd.Parameters.Add("@idUsuario", DbType.Int32).Value = prestamo.IdUsuario;
            cmd.Parameters.Add("@fechaInicio", DbType.String).Value = prestamo.FechaInicio;
            cmd.Parameters.Add("@fechaFin", DbType.String).Value = prestamo.FechaFin;

            SQLiteHelper.Ejecuta(Properties.Settings.Default.conexion, cmd);
        }

        public void Eliminar(int id)
        {
            string sql = "DELETE FROM Prestamos WHERE ID=@id";
            SQLiteCommand cmd = new SQLiteCommand(sql);
            cmd.Parameters.Add("@id", DbType.Int32).Value = id;
            SQLiteHelper.Ejecuta(Properties.Settings.Default.conexion, cmd);
        }

        public DataTable ObtenerTodos()
        {
            string sql = @"SELECT 
                            p.ID, 
                            p.ID_Libro, 
                            p.ID_Usuario, 
                            p.Fecha_Inicio, 
                            p.Fecha_Fin,
                            l.Titulo AS Libro,
                            (u.Nombre || ' ' || u.Apellido_1 || ' ' || COALESCE(u.Apellido_2, '')) AS Usuario
                          FROM Prestamos p
                          INNER JOIN Libros l ON p.ID_Libro = l.ID
                          INNER JOIN Usuarios u ON p.ID_Usuario = u.ID
                          ORDER BY p.Fecha_Inicio DESC";
            SQLiteCommand cmd = new SQLiteCommand(sql);
            return SQLiteHelper.GetDataTable(Properties.Settings.Default.conexion, cmd);
        }

        public DataTable ObtenerActivos()
        {
            // Préstamos activos: libros que están prestados (Disponible = 0)
            string sql = @"SELECT 
                            p.ID, 
                            p.ID_Libro, 
                            p.ID_Usuario, 
                            p.Fecha_Inicio, 
                            p.Fecha_Fin,
                            l.Titulo AS Libro,
                            (u.Nombre || ' ' || u.Apellido_1 || ' ' || COALESCE(u.Apellido_2, '')) AS Usuario
                          FROM Prestamos p
                          INNER JOIN Libros l ON p.ID_Libro = l.ID
                          INNER JOIN Usuarios u ON p.ID_Usuario = u.ID
                          WHERE l.Disponible = 0
                          ORDER BY p.Fecha_Inicio DESC";
            SQLiteCommand cmd = new SQLiteCommand(sql);
            return SQLiteHelper.GetDataTable(Properties.Settings.Default.conexion, cmd);
        }

        public DataTable BuscarPorId(int id)
        {
            string sql = @"SELECT 
                            p.ID, 
                            p.ID_Libro, 
                            p.ID_Usuario, 
                            p.Fecha_Inicio, 
                            p.Fecha_Fin,
                            l.Titulo AS Libro,
                            (u.Nombre || ' ' || u.Apellido_1 || ' ' || COALESCE(u.Apellido_2, '')) AS Usuario
                          FROM Prestamos p
                          INNER JOIN Libros l ON p.ID_Libro = l.ID
                          INNER JOIN Usuarios u ON p.ID_Usuario = u.ID
                          WHERE p.ID = @id";
            SQLiteCommand cmd = new SQLiteCommand(sql);
            cmd.Parameters.Add("@id", DbType.Int32).Value = id;
            return SQLiteHelper.GetDataTable(Properties.Settings.Default.conexion, cmd);
        }

        public DataTable BuscarPorLibro(int idLibro)
        {
            string sql = @"SELECT 
                            p.ID, 
                            p.ID_Libro, 
                            p.ID_Usuario, 
                            p.Fecha_Inicio, 
                            p.Fecha_Fin,
                            l.Titulo AS Libro,
                            (u.Nombre || ' ' || u.Apellido_1 || ' ' || COALESCE(u.Apellido_2, '')) AS Usuario
                          FROM Prestamos p
                          INNER JOIN Libros l ON p.ID_Libro = l.ID
                          INNER JOIN Usuarios u ON p.ID_Usuario = u.ID
                          WHERE p.ID_Libro = @idLibro
                          ORDER BY p.Fecha_Inicio DESC";
            SQLiteCommand cmd = new SQLiteCommand(sql);
            cmd.Parameters.Add("@idLibro", DbType.Int32).Value = idLibro;
            return SQLiteHelper.GetDataTable(Properties.Settings.Default.conexion, cmd);
        }

        public DataTable BuscarPorUsuario(int idUsuario)
        {
            string sql = @"SELECT 
                            p.ID, 
                            p.ID_Libro, 
                            p.ID_Usuario, 
                            p.Fecha_Inicio, 
                            p.Fecha_Fin,
                            l.Titulo AS Libro,
                            (u.Nombre || ' ' || u.Apellido_1 || ' ' || COALESCE(u.Apellido_2, '')) AS Usuario
                          FROM Prestamos p
                          INNER JOIN Libros l ON p.ID_Libro = l.ID
                          INNER JOIN Usuarios u ON p.ID_Usuario = u.ID
                          WHERE p.ID_Usuario = @idUsuario
                          ORDER BY p.Fecha_Inicio DESC";
            SQLiteCommand cmd = new SQLiteCommand(sql);
            cmd.Parameters.Add("@idUsuario", DbType.Int32).Value = idUsuario;
            return SQLiteHelper.GetDataTable(Properties.Settings.Default.conexion, cmd);
        }
    }
}