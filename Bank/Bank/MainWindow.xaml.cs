using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Bank.Objects;
using Bank.ORM;
using Bank.Types;

namespace Bank
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Admin admin = UsersORM.GetAdmin(Login.Text, Password.Text);
           if (admin != null)
           {
               AdminWindow adminWindow = new AdminWindow();
               adminWindow.Show();
               Close();
           }


           // Admin admin = new Admin();
           //admin.SurName = "petr";
           //admin.Name = "petr";
           //admin.Guid = new Guid();
           //admin.Mail = "test@mail.com";
           //admin.Phone = "777777777";
           //admin.AdminType = AdminType.Admin;
           //admin.Address = new Address();
           //admin.Address.Id = 1;
           //admin.Login = "petr";
           //admin.Password = "123456";
           //admin.Valid = true;

           //UsersORM.CreateAdmin(admin);

        }
    }
}
