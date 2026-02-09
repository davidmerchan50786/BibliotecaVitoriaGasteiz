using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using Biblioteca_BBDD;

namespace BibliotecaVitoriaGasteiz.helpers
{
    public static class DatabaseHelper
    {
        /// <summary>
        /// Corrige registros con ID = 0 o IDs inválidos en la base de datos
        /// </summary>
        public static void CorregirIDsInvalidos()
        {
            try
            {
                string conexion = Properties.Settings.Default.conexion;

                // ===== CORREGIR USUARIOS =====
                CorregirUsuariosInvalidos(conexion);

                // ===== CORREGIR LIBROS =====
                CorregirLibrosInvalidos(conexion);

                // ===== LIMPIAR PRÉSTAMOS HUÉRFANOS =====
                LimpiarPrestamosHuerfanos(conexion);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al corregir base de datos: {ex.Message}", 
                    "Error de inicialización",
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);
            }
        }

        private static void CorregirUsuariosInvalidos(string conexion)
        {
            try
            {
                // 1. Verificar si hay usuarios con ID <= 0
                string sqlCheck = "SELECT COUNT(*) FROM Usuarios WHERE ID <= 0";
                SQLiteCommand cmdCheck = new SQLiteCommand(sqlCheck);
                DataTable dtCheck = SQLiteHelper.GetDataTable(conexion, cmdCheck);
                int count = Convert.ToInt32(dtCheck.Rows[0][0]);

                if (count == 0) return; // No hay problemas

                // 2. Obtener el máximo ID actual
                string sqlMax = "SELECT COALESCE(MAX(ID), 0) FROM Usuarios WHERE ID > 0";
                SQLiteCommand cmdMax = new SQLiteCommand(sqlMax);
                DataTable dtMax = SQLiteHelper.GetDataTable(conexion, cmdMax);
                int maxId = Convert.ToInt32(dtMax.Rows[0][0]);

                // 3. Obtener usuarios con ID inválido
                string sqlGetInvalidos = "SELECT * FROM Usuarios WHERE ID <= 0";
                SQLiteCommand cmdGetInvalidos = new SQLiteCommand(sqlGetInvalidos);
                DataTable dtInvalidos = SQLiteHelper.GetDataTable(conexion, cmdGetInvalidos);

                // 4. Para cada usuario inválido, asignar nuevo ID
                int nuevoId = maxId + 1;
                foreach (DataRow row in dtInvalidos.Rows)
                {
                    int idViejo = Convert.ToInt32(row["ID"]);
                    string nombre = row["Nombre"].ToString();
                    string apellido1 = row["Apellido_1"].ToString();
                    string apellido2 = row["Apellido_2"] != DBNull.Value ? row["Apellido_2"].ToString() : "";
                    int telefono = Convert.ToInt32(row["Telefono"]);

                    // Actualizar ID
                    string sqlUpdate = "UPDATE Usuarios SET ID = @nuevoId WHERE ID = @idViejo";
                    SQLiteCommand cmdUpdate = new SQLiteCommand(sqlUpdate);
                    cmdUpdate.Parameters.Add("@nuevoId", DbType.Int32).Value = nuevoId;
                    cmdUpdate.Parameters.Add("@idViejo", DbType.Int32).Value = idViejo;
                    SQLiteHelper.Ejecuta(conexion, cmdUpdate);

                    // Actualizar préstamos relacionados
                    string sqlUpdatePrestamos = "UPDATE Prestamos SET ID_Usuario = @nuevoId WHERE ID_Usuario = @idViejo";
                    SQLiteCommand cmdUpdatePrestamos = new SQLiteCommand(sqlUpdatePrestamos);
                    cmdUpdatePrestamos.Parameters.Add("@nuevoId", DbType.Int32).Value = nuevoId;
                    cmdUpdatePrestamos.Parameters.Add("@idViejo", DbType.Int32).Value = idViejo;
                    SQLiteHelper.Ejecuta(conexion, cmdUpdatePrestamos);

                    nuevoId++;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al corregir usuarios: {ex.Message}");
            }
        }

        private static void CorregirLibrosInvalidos(string conexion)
        {
            try
            {
                // 1. Verificar si hay libros con ID <= 0
                string sqlCheck = "SELECT COUNT(*) FROM Libros WHERE ID <= 0";
                SQLiteCommand cmdCheck = new SQLiteCommand(sqlCheck);
                DataTable dtCheck = SQLiteHelper.GetDataTable(conexion, cmdCheck);
                int count = Convert.ToInt32(dtCheck.Rows[0][0]);

                if (count == 0) return; // No hay problemas

                // 2. Obtener el máximo ID actual
                string sqlMax = "SELECT COALESCE(MAX(ID), 0) FROM Libros WHERE ID > 0";
                SQLiteCommand cmdMax = new SQLiteCommand(sqlMax);
                DataTable dtMax = SQLiteHelper.GetDataTable(conexion, cmdMax);
                int maxId = Convert.ToInt32(dtMax.Rows[0][0]);

                // 3. Obtener libros con ID inválido
                string sqlGetInvalidos = "SELECT * FROM Libros WHERE ID <= 0";
                SQLiteCommand cmdGetInvalidos = new SQLiteCommand(sqlGetInvalidos);
                DataTable dtInvalidos = SQLiteHelper.GetDataTable(conexion, cmdGetInvalidos);

                // 4. Para cada libro inválido, asignar nuevo ID
                int nuevoId = maxId + 1;
                foreach (DataRow row in dtInvalidos.Rows)
                {
                    int idViejo = Convert.ToInt32(row["ID"]);

                    // Actualizar ID
                    string sqlUpdate = "UPDATE Libros SET ID = @nuevoId WHERE ID = @idViejo";
                    SQLiteCommand cmdUpdate = new SQLiteCommand(sqlUpdate);
                    cmdUpdate.Parameters.Add("@nuevoId", DbType.Int32).Value = nuevoId;
                    cmdUpdate.Parameters.Add("@idViejo", DbType.Int32).Value = idViejo;
                    SQLiteHelper.Ejecuta(conexion, cmdUpdate);

                    // Actualizar préstamos relacionados
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

        private static void LimpiarPrestamosHuerfanos(string conexion)
        {
            try
            {
                // Eliminar préstamos que referencian usuarios o libros inexistentes
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
