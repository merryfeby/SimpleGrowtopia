using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace T6_ACS
{
    class DB
    {
        private static string connString = "";
        public static SqlConnection conn = null;
        const string NAMADB = "db_growtopia_sederhana";
        public DB()
        {
            try
            {
                string connString = $"Data Source=.;Initial Catalog={NAMADB};Integrated Security=True;";
                conn = new SqlConnection(connString);
            }
            catch (Exception exc)
            {
                throw new Exception("Konfigurasi gagal, " + exc.Message.ToString());
            }
        }
        //funcion2 ini dibuat static 
        public static void openConnection()
        {

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();

        }
        public static void closeConnection()
        {
            conn.Close();
        }
    }
}
