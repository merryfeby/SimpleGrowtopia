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
        const string NAMADB = "db_rubik";
        public DB()
        {
            //class ini digunakan untuk menyimpan konfigurasi database
            try
            {
                //yang data source sesuain sama nama server di sql server
                string connString = $"Data Source=.;Initial Catalog={NAMADB};User ID={"user1"};Password={"user1"};";

                //connection string ini digunakan semacam identitas pengenal buat connect ke database
                //string yang ada dollarnya ($) ini untuk interpolation string, silahkan cari sendiri apa itu :)

                conn = new SqlConnection(connString);
                //ini untuk init connection, supaya kita nantinya bisa pakai connection ini dan gaperlu buat connection baru lagi.
                //dimasukkin try catch karena kalo ada error si sql bakal ngethrow error

                //PASTIKAN DI HALAMAN CONNECTION CLASS DB DI INIT, kalau gak ndabisa di open / close
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
