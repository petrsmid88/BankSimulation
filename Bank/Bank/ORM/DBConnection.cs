using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows;

namespace Bank.ORM
{
    public class DBConnection
    {
        static string connectionString = @"Server=localhost\SQLEXPRESS;Database=Bank;Trusted_Connection=True;";
        private SqlConnection Connection { get; set; }

        public DBConnection()
        {
            Connection = new SqlConnection();
        }











        public bool OpenConection()
        {
            if (Connection.State != ConnectionState.Open)
                try
                {
                    Connection.ConnectionString = connectionString;
                    Connection.Open();
                    //MessageBox.Show("Connection Open ! ");
                    return true;
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Can not open connection ! ");
                    return false;
                }
            //MessageBox.Show("Connection is already oppened ! ");
            return false;
        }

        public SqlCommand CreateCommand(string strCommand)
        {
            SqlCommand command = new SqlCommand(strCommand, Connection);
            return command;
        }


        public void CloseConnection()
        {
            Connection.Close();
        }


    }
}
