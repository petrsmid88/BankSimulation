

using System.Data;
using System.Data.SqlClient;
using System.Windows;


namespace Bank.ORM
{
    public class Class1
    {
        static string connectionString = @"Server=localhost\SQLEXPRESS;Database=Bank;Trusted_Connection=True;";

        public SqlConnection Cnn { get; set; }

        public Class1()
        {
            Cnn = new SqlConnection();
        }

        public bool OpenConnection()
        {

            Cnn.ConnectionString = connectionString;
            Cnn.Open();
            if (Cnn.State == ConnectionState.Open)
            {
                MessageBox.Show("Open");
                return true;
            }
            MessageBox.Show("Close");
            return false;
        }
    }

}
