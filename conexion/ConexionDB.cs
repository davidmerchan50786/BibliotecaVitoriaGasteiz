using Microsoft.Data.Sqlite;
using System;
using System.Data.SQLite;
using System.IO;

namespace Biblioteca_BBDD.Conexion
{
    public class ConexionDB
    {
        private static string nombreBD = "biblioteca.db";
        private static string rutaBD = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, nombreBD);
        private static string cadenaConexion = $"Data Source={rutaBD};Version=3;";

        // Obtener conexión
        public static SqliteConnection ObtenerConexion()
        {
            return new SqliteConnection(cadenaConexion);
        }

        // Crear la base de datos y las tablas si no existen
        public static void InicializarBaseDatos()
        {
            // Si no existe el archivo, se crea automáticamente
            if (!File.Exists(rutaBD))
            {
                object value = SqliteConnection.CreateFile(rutaBD);
            }

            using (SqliteConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                string crearTablas = @"
                    CREATE TABLE IF NOT EXISTS Usuarios (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Nombre TEXT NOT NULL,
                        Apellidos TEXT NOT NULL,
                        Email TEXT NOT NULL,
                        Telefono TEXT
                    );

                    CREATE TABLE IF NOT EXISTS Libros (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Titulo TEXT NOT NULL,
                        Autor TEXT NOT NULL,
                        ISBN TEXT,
                        Descripcion TEXT,
                        NumEjemplares INTEGER DEFAULT 1,
                        Disponibles INTEGER DEFAULT 1
                    );

                    CREATE TABLE IF NOT EXISTS Prestamos (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        IdLibro INTEGER NOT NULL,
                        IdUsuario INTEGER NOT NULL,
                        FechaPrestamo TEXT NOT NULL,
                        FechaDevolucion TEXT,
                        Devuelto INTEGER DEFAULT 0,
                        FOREIGN KEY (IdLibro) REFERENCES Libros(Id),
                        FOREIGN KEY (IdUsuario) REFERENCES Usuarios(Id)
                    );
                ";

                using (SqliteCommand comando = new SqliteCommand(crearTablas, conexion))
                {
                    comando.ExecuteNonQuery();
                }

                conexion.Close();
            }
        }
    }
}