using System;
using System.Data;
using System.Data.SQLite;
using Biblioteca_BBDD;

namespace BibliotecaVitoriaGasteiz.modelo
{
    /// <summary>
    /// Repositorio de Préstamos - Capa de acceso a datos
    /// 
    /// Esta clase es la ÚNICA que accede directamente a la tabla Prestamos en la BD.
    /// Siguiendo el patrón MVC que vi en los apuntes de clase:
    /// - El Controlador llama a estos métodos
    /// - Estos métodos ejecutan SQL a través de SQLiteHelper
    /// 
    /// Al principio SQLite me dio problemas, pero aprendí de la documentación de Microsoft
    /// y los apuntes que hay que usar parámetros (@idLibro, @idUsuario...) para evitar
    /// inyección SQL y otros problemas de seguridad.
    /// 
    /// Desarrollador: David
    /// Proyecto: Biblioteca Ayuntamiento Vitoria-Gasteiz
    /// </summary>
    public class RepositorioPrestamo
    {
        /// <summary>
        /// Inserta un nuevo préstamo en la base de datos
        /// 
        /// Guardo:
        /// - ID_Libro: Qué libro se presta
        /// - ID_Usuario: A quién se le presta
        /// - Fecha_Inicio: Cuándo se prestó
        /// - Fecha_Fin: Cuándo debe devolverse
        /// 
        /// Las fechas las guardo como TEXT en formato "dd/MM/yyyy"
        /// (Lo vi así en los ejemplos de SQLite de clase)
        /// </summary>
        public void Insertar(Prestamo prestamo)
        {
            string sql = "INSERT INTO Prestamos (ID_Libro, ID_Usuario, Fecha_Inicio, Fecha_Fin) VALUES (@idLibro, @idUsuario, @fechaInicio, @fechaFin)";
            SQLiteCommand cmd = new SQLiteCommand(sql);

            // Agrego los parámetros para evitar inyección SQL
            cmd.Parameters.Add("@idLibro", DbType.Int32).Value = prestamo.IdLibro;
            cmd.Parameters.Add("@idUsuario", DbType.Int32).Value = prestamo.IdUsuario;
            cmd.Parameters.Add("@fechaInicio", DbType.String).Value = prestamo.FechaInicio;
            cmd.Parameters.Add("@fechaFin", DbType.String).Value = prestamo.FechaFin;

            // Ejecuto el INSERT usando la clase SQLiteHelper que nos proporcionó el profesor
            SQLiteHelper.Ejecuta(Properties.Settings.Default.conexion, cmd);
        }

        /// <summary>
        /// Modifica un préstamo existente
        /// Se usa principalmente al devolver un libro (actualizar Fecha_Fin)
        /// </summary>
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

        /// <summary>
        /// Elimina un préstamo de la base de datos
        /// </summary>
        public void Eliminar(int id)
        {
            string sql = "DELETE FROM Prestamos WHERE ID=@id";
            SQLiteCommand cmd = new SQLiteCommand(sql);
            cmd.Parameters.Add("@id", DbType.Int32).Value = id;
            SQLiteHelper.Ejecuta(Properties.Settings.Default.conexion, cmd);
        }

        /// <summary>
        /// Obtiene todos los préstamos con información completa
        /// 
        /// USO INNER JOIN para combinar tres tablas:
        /// - Prestamos (p): Tiene los IDs y fechas
        /// - Libros (l): Necesito el título del libro
        /// - Usuarios (u): Necesito el nombre del usuario
        /// 
        /// Esto lo aprendí de los apuntes de SQL de clase y la documentación de Microsoft.
        /// En vez de devolver solo IDs, devuelvo información legible.
        /// 
        /// ALIAS:
        /// - l.Titulo AS Libro: Renombro la columna para que sea más clara
        /// - (u.Nombre || ' ' || ...) AS Usuario: Concateno nombre y apellidos
        /// 
        /// COALESCE(u.Apellido_2, ''): Si Apellido_2 es NULL, uso cadena vacía
        /// Esto evita que salga "Juan Pérez NULL" en la interfaz
        /// </summary>
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

        /// <summary>
        /// Obtiene solo los préstamos activos (libros actualmente prestados)
        /// 
        /// Un préstamo está activo cuando:
        /// - El libro tiene Disponible = 0 (está prestado)
        /// 
        /// Esta consulta es la que uso en FormPrestamos para mostrar
        /// la tabla de préstamos en curso. Solo aparecen los libros
        /// que están actualmente en manos de usuarios.
        /// 
        /// WHERE l.Disponible = 0: Filtro por libros NO disponibles
        /// En SQLite: 0 = false (prestado), 1 = true (disponible)
        /// </summary>
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

        /// <summary>
        /// Busca un préstamo específico por su ID
        /// Devuelve toda la información relacionada (libro, usuario)
        /// </summary>
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

        /// <summary>
        /// Busca todos los préstamos de un libro específico
        /// 
        /// Útil para ver el historial completo de un libro:
        /// - Quiénes lo han prestado
        /// - Cuándo se prestó cada vez
        /// 
        /// Se ordena por fecha descendente (los más recientes primero)
        /// </summary>
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

        /// <summary>
        /// Busca todos los préstamos de un usuario específico
        /// 
        /// Útil para ver el historial de lectura de un usuario:
        /// - Qué libros ha prestado
        /// - Cuándo los prestó
        /// 
        /// Se ordena por fecha descendente (los más recientes primero)
        /// </summary>
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