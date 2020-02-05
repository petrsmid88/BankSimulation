using Bank.Objects;
using System;
using System.Data.SqlClient;
using System.Windows;

namespace Bank.ORM
{
    class UsersORM
    {
        private static String selectAdminCount = "SELECT count(*) FROM users WHERE AdminLogin=@AdminLogin and WorkPassword=@Password";
        private static String selectByLogin = "SELECT * FROM users WHERE AdminLogin=@AdminLogin and WorkPassword=@Password";


        public static Admin GetAdmin(string Login, string Password)
        {
            int count = 0;

            DBConnection connection = new DBConnection();
            connection.OpenConection();

            SqlCommand command = connection.CreateCommand(selectByLogin);
            command.Parameters.AddWithValue("@AdminLogin", Login);
            command.Parameters.AddWithValue("@Password", Password);

            SqlCommand commandCount = connection.CreateCommand(selectAdminCount);
            commandCount.Parameters.AddWithValue("@AdminLogin", Login);
            commandCount.Parameters.AddWithValue("@Password", Password);
            count = (int)commandCount.ExecuteScalar();

            SqlDataReader reader = command.ExecuteReader();

            switch (count)
            {
                case 0:
                    MessageBox.Show("Zadali jste neplatnou kombinaci Login + Password!");
                    return null;
                case 1:
                    Admin admin = new Admin();
                    while (reader.Read())
                    {
                        admin.Guid = Guid.NewGuid();
                        admin.Name = reader.GetString(1);
                        admin.SurName = reader.GetString(2);
                    }
                    connection.CloseConnection();
                    return admin;
                default:
                    MessageBox.Show("v DB existuje více uživatelů se stéjným ID! ");
                    return null;
            }
        }

    }
}
