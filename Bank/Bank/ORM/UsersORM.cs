using Bank.Objects;
using System;
using System.Data.SqlClient;
using System.Windows;

namespace Bank.ORM
{
    public class UsersORM
    {
        private static String selectAdminCount = "SELECT count(*) FROM users WHERE AdminLogin=@AdminLogin and WorkPassword=@WorkPassword";
        private static String selectByLogin = "SELECT * FROM users WHERE AdminLogin=@AdminLogin and WorkPassword=@WorkPassword";
        private static String insertNewAdmin =
           "insert into Users values (@GUID,@Name,@Surname,@Address,@Mail,@Phone,@valid,NULL,NULL,NULL,@Password,NULL,NULL,@Type,@Login)";
        private static String changePassword = "UPDATE users SET WorkPassword = @Password where id = @GUID";


        public static Admin GetAdmin(string Login, string Password)
        {
            int count = 0;

            DBConnection connection = new DBConnection();
            connection.OpenConection();

            SqlCommand command = connection.CreateCommand(selectByLogin);
            command.Parameters.AddWithValue("@AdminLogin", Login);
            command.Parameters.AddWithValue("@WorkPassword", Password);

            SqlCommand commandCount = connection.CreateCommand(selectAdminCount);
            commandCount.Parameters.AddWithValue("@AdminLogin", Login);
            commandCount.Parameters.AddWithValue("@WorkPassword", Password);
            
            count = (int)commandCount.ExecuteScalar();

            SqlDataReader reader = command.ExecuteReader();

            switch (count)
            {
                case 0:
                    MessageBox.Show("Zadali jste neplatnou kombinaci Login + Password!");
                    connection.CloseConnection();
                    return null;
                case 1:
                    Admin admin = new Admin();
                    while (reader.Read())
                    {
                        admin.Guid = reader.GetGuid(0);
                        admin.Name = reader.GetString(1);
                        admin.SurName = reader.GetString(2);
                        admin.Address = new Address();
                        admin.Address.Id = reader.GetInt16(3);
                        admin.Valid = reader.GetBoolean(6);
                    }
                    connection.CloseConnection();
                    return admin;
                default:
                    MessageBox.Show("v DB existuje více uživatelů se stéjným ID! ");
                    connection.CloseConnection();
                    return null;
            }
        }

        public static bool CreateAdmin(Admin admin)
        {
            DBConnection connection = new DBConnection();
            connection.OpenConection();
            SqlCommand command = connection.CreateCommand(insertNewAdmin);

            command.Parameters.AddWithValue("@GUID", admin.Guid);
            command.Parameters.AddWithValue("@Name", admin.Name);
            command.Parameters.AddWithValue("@Surname", admin.SurName);
            command.Parameters.AddWithValue("@Address", admin.Address.Id);
            command.Parameters.AddWithValue("@Mail", admin.Mail);
            command.Parameters.AddWithValue("@Phone", admin.Phone);
            command.Parameters.AddWithValue("@valid", admin.Valid);
            command.Parameters.AddWithValue("@Password", admin.Password);
            command.Parameters.AddWithValue("@Type", admin.AdminType);
            command.Parameters.AddWithValue("@Login", admin.Login);

            int result = command.ExecuteNonQuery();
            connection.CloseConnection();
            if (result == 1) return true;
            return false;
        }

        public static bool ChangePassword(Admin admin)
        {
            DBConnection connection = new DBConnection();
            connection.OpenConection();
            SqlCommand command = connection.CreateCommand(changePassword);

            command.Parameters.AddWithValue("@GUID", admin.Guid);
            command.Parameters.AddWithValue("@Password", admin.Password);
            int result = command.ExecuteNonQuery();
            connection.CloseConnection();
            if (result == 1) return true;
            return false;
        }

    }
}
