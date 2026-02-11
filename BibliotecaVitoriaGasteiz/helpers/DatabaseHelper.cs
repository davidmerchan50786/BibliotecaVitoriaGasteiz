using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using Biblioteca_BBDD;

namespace BibliotecaVitoriaGasteiz.helpers
{
    /// <summary>
    /// Clase auxiliar para corregir problemas en la base de datos al iniciar la aplicación.
    /// Creada para solucionar el problema de IDs inválidos (ID = 0 o negativos) que impedían
    /// realizar préstamos correctamente.
    /// 
    /// Desarrollador: David
    /// Propósito: Gestión de biblioteca del Ayuntamiento de Vitoria-Gasteiz
    /// </summary>
    public static class DatabaseHelper
    {
        /// <summary>
        /// Método principal que se ejecuta al iniciar la aplicación.
        /// Corrige automáticamente registros con ID = 0 o IDs inválidos en las tablas
        /// de Usuarios y Libros, y limpia préstamos huérfanos.
        /// 
        /// Al principio SQLite me dio problemas con los IDs, algunos registros tenían ID = 0
        /// y eso rompía toda la lógica de préstamos. Esta función los detecta y corrige.
        /// </summary>
        public static void CorregirIDsInvalidos()
        {
            try
            {
                // Obtengo la cadena de conexión desde las propiedades del proyecto
                string conexion = Properties.Settings.Default.conexion;

                // Corrijo los tres problemas principales:
                CorregirUsuariosInvalidos(conexion);  // 1. Usuarios con ID <= 0
                CorregirLibrosInvalidos(conexion);     // 2. Libros con ID <= 0
                LimpiarPrestamosHuerfanos(conexion);   // 3. Préstamos que apuntan a IDs inexistentes
            }
            catch (Exception ex)
            {
                // Si algo falla, muestro un aviso pero no detengo la aplicación
                MessageBox.Show($"Error al corregir base de datos: {ex.Message}",
                    "Error de inicialización",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Corrige usuarios que tienen ID inválido (menor o igual a 0).
        /// Les asigna un nuevo ID válido comenzando desde el máximo ID existente + 1.
        /// También actualiza las referencias en la tabla Prestamos para mantener la integridad.
        /// </summary>
        private static void CorregirUsuariosInvalidos(string conexion)
        {
            try
            {
                // PASO 1: Verifico si hay usuarios con problemas
                string sqlCheck = "SELECT COUNT(*) FROM Usuarios WHERE ID <= 0";
                SQLiteCommand cmdCheck = new SQLiteCommand(sqlCheck);
                DataTable dtCheck = SQLiteHelper.GetDataTable(conexion, cmdCheck);
                int count = Convert.ToInt32(dtCheck.Rows[0][0]);

                if (count == 0) return; // No hay problemas, salgo del método

                // PASO 2: Obtengo el ID más alto actual para saber desde dónde empezar
                // COALESCE devuelve 0 si no hay ningún usuario con ID válido
                string sqlMax = "SELECT COALESCE(MAX(ID), 0) FROM Usuarios WHERE ID > 0";
                SQLiteCommand cmdMax = new SQLiteCommand(sqlMax);
                DataTable dtMax = SQLiteHelper.GetDataTable(conexion, cmdMax);
                int maxId = Convert.ToInt32(dtMax.Rows[0][0]);

                // PASO 3: Obtengo todos los usuarios con ID inválido
                string sqlGetInvalidos = "SELECT * FROM Usuarios WHERE ID <= 0";
                SQLiteCommand cmdGetInvalidos = new SQLiteCommand(sqlGetInvalidos);
                DataTable dtInvalidos = SQLiteHelper.GetDataTable(conexion, cmdGetInvalidos);

                // PASO 4: Recorro cada usuario problemático y le asigno un ID nuevo
                int nuevoId = maxId + 1;
                foreach (DataRow row in dtInvalidos.Rows)
                {
                    int idViejo = Convert.ToInt32(row["ID"]);

                    // Actualizo el ID del usuario
                    string sqlUpdate = "UPDATE Usuarios SET ID = @nuevoId WHERE ID = @idViejo";
                    SQLiteCommand cmdUpdate = new SQLiteCommand(sqlUpdate);
                    cmdUpdate.Parameters.Add("@nuevoId", DbType.Int32).Value = nuevoId;
                    cmdUpdate.Parameters.Add("@idViejo", DbType.Int32).Value = idViejo;
                    SQLiteHelper.Ejecuta(conexion, cmdUpdate);

                    // IMPORTANTE: También actualizo los préstamos que referencian este usuario
                    // Si no hago esto, se pierden las relaciones
                    string sqlUpdatePrestamos = "UPDATE Prestamos SET ID_Usuario = @nuevoId WHERE ID_Usuario = @idViejo";
                    SQLiteCommand cmdUpdatePrestamos = new SQLiteCommand(sqlUpdatePrestamos);
                    cmdUpdatePrestamos.Parameters.Add("@nuevoId", DbType.Int32).Value = nuevoId;
                    cmdUpdatePrestamos.Parameters.Add("@idViejo", DbType.Int32).Value = idViejo;
                    SQLiteHelper.Ejecuta(conexion, cmdUpdatePrestamos);

                    nuevoId++; // Siguiente ID disponible
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al corregir usuarios: {ex.Message}");
            }
        }

        /// <summary>
        /// Corrige libros que tienen ID inválido (menor o igual a 0).
        /// Funcionamiento idéntico a CorregirUsuariosInvalidos pero para la tabla Libros.
        /// </summary>
        private static void CorregirLibrosInvalidos(string conexion)
        {
            try
            {
                // PASO 1: Verifico si hay libros con problemas
                string sqlCheck = "SELECT COUNT(*) FROM Libros WHERE ID <= 0";
                SQLiteCommand cmdCheck = new SQLiteCommand(sqlCheck);
                DataTable dtCheck = SQLiteHelper.GetDataTable(conexion, cmdCheck);
                int count = Convert.ToInt32(dtCheck.Rows[0][0]);

                if (count == 0) return; // No hay problemas

                // PASO 2: Obtengo el ID más alto actual
                string sqlMax = "SELECT COALESCE(MAX(ID), 0) FROM Libros WHERE ID > 0";
                SQLiteCommand cmdMax = new SQLiteCommand(sqlMax);
                DataTable dtMax = SQLiteHelper.GetDataTable(conexion, cmdMax);
                int maxId = Convert.ToInt32(dtMax.Rows[0][0]);

                // PASO 3: Obtengo todos los libros con ID inválido
                string sqlGetInvalidos = "SELECT * FROM Libros WHERE ID <= 0";
                SQLiteCommand cmdGetInvalidos = new SQLiteCommand(sqlGetInvalidos);
                DataTable dtInvalidos = SQLiteHelper.GetDataTable(conexion, cmdGetInvalidos);

                // PASO 4: Recorro cada libro problemático y le asigno un ID nuevo
                int nuevoId = maxId + 1;
                foreach (DataRow row in dtInvalidos.Rows)
                {
                    int idViejo = Convert.ToInt32(row["ID"]);

                    // Actualizo el ID del libro
                    string sqlUpdate = "UPDATE Libros SET ID = @nuevoId WHERE ID = @idViejo";
                    SQLiteCommand cmdUpdate = new SQLiteCommand(sqlUpdate);
                    cmdUpdate.Parameters.Add("@nuevoId", DbType.Int32).Value = nuevoId;
                    cmdUpdate.Parameters.Add("@idViejo", DbType.Int32).Value = idViejo;
                    SQLiteHelper.Ejecuta(conexion, cmdUpdate);

                    // Actualizo también los préstamos relacionados
                    string sqlUpdatePrestamos = "UPDATE Prestamos SET ID_Libro = @nuevoId WHERE ID_Libro = @idViejo";
                    SQLiteCommand cmdUpdatePrestamos = new SQLiteCommand(sqlUpdatePrestamos);
                    cmdUpdatePrestamos.Parameters.Add("@nuevoId", DbType.Int32).Value = nuevoId;
                    cmdUpdatePrestamos.Parameters.Add("@idViejo", DbType.Int32).Value = idViejo;
                    SQLiteHelper.Ejecuta(conexion, cmdUpdatePrestamos);

                    nuevoId++;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al corregir libros: {ex.Message}");
            }
        }

        /// <summary>
        /// Elimina préstamos "huérfanos", es decir, préstamos que referencian
        /// usuarios o libros que ya no existen en la base de datos.
        /// Esto mantiene la integridad referencial de la BD.
        /// </summary>
        private static void LimpiarPrestamosHuerfanos(string conexion)
        {
            try
            {
                // Elimino préstamos donde el ID_Usuario no existe en la tabla Usuarios
                // O donde el ID_Libro no existe en la tabla Libros
                string sqlLimpiar = @"DELETE FROM Prestamos 
                                     WHERE ID_Usuario NOT IN (SELECT ID FROM Usuarios)
                                     OR ID_Libro NOT IN (SELECT ID FROM Libros)";
                SQLiteCommand cmd = new SQLiteCommand(sqlLimpiar);
                SQLiteHelper.Ejecuta(conexion, cmd);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al limpiar préstamos huérfanos: {ex.Message}");
            }
        }
    }
}