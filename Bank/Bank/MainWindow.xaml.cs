﻿using System;
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
            
        Class1 con = new Class1();
        con.OpenConnection();


        //Admin admin = UsersORM.GetAdmin(Login.Text, Password.Text);
        //if (admin.AdminType == AdminType.SuperAdmin)
        //{

        //}
        //else if (admin.AdminType == AdminType.Admin)
        //{
        //}
        }
    }
}
