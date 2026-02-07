using System;
using System.Data;
using System.Data.SQLite;

namespace BibliotecaVitoriaGasteiz.modelo
{
    public static class SQLiteHelper
    {
        public static SQLiteConnection Conectar(string bbdd)
        {
            try
            {
                SQLiteConnection cnn = new SQLiteConnection(bbdd);
                cnn.Open();
                return cnn;
            }
            catch (Exception ex)
            {
                throw new Exception("No se logró realizar la conexión debido a: " + ex.Message);
            }
        }

        public static SQLiteDataReader GetDataReader(string bbdd, SQLiteCommand cmd)
        {
            try
            {
                SQLiteConnection cnx = Conectar(bbdd);
                cmd.Connection = cnx;

                // El DataReader cerrará la conexión cuando se cierre
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw new Exception("No se logró realizar la consulta por: " + ex.Message);
            }
        }

        public static DataTable GetDataTable(string bbdd, SQLiteCommand cmd)
        {
            try
            {
                using (SQLiteConnection cnx = Conectar(bbdd))
                {
                    cmd.Connection = cnx;

                    DataSet ds = new DataSet();
                    ds.Tables.Add("datos");

                    using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
                    {
                        da.Fill(ds, "datos");
                    }

                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se logró realizar la consulta por: " + ex.Message);
            }
        }

        public static void Ejecuta(string bbdd, SQLiteCommand cmd)
        {
            try
            {
                using (SQLiteConnection cnx = Conectar(bbdd))
                {
                    cmd.Connection = cnx;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se logró realizar la consulta por: " + ex.Message);
            }
        }
    }
}
