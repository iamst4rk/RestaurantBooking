using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
using RestaurantBooking.DB;
using RestaurantBooking.windows;

namespace RestaurantBooking
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                //var a = DBconnect.RestaurantBooking.Auth.Where(p => p.Login == tbLogin.Text && p.Password == pbPassword.Password).FirstOrDefault();
                //Properties.Settings.Default.Current_User_ID = a.User_ID;
            }
            catch
            {
                MessageBox.Show("Ошибка присоединения к базе данных");
                this.Close();
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var b = DBconnect.RestaurantBooking.Auth.Where(p => p.Login == tbLogin.Text && p.Password == pbPassword.Password).FirstOrDefault();
            //Properties.Settings.Default.Current_User_ID = b.User_ID;
            if (tbLogin.Text == "" && pbPassword.Password == "")
            {
                errorLbl.Content = "Введите логин и пароль";
                return;
            }
            if (tbLogin.Text == "")
            {
                errorLbl.Content = "Введите логин";
                return;
            }
            if (pbPassword.Password == "")
            {
                errorLbl.Content = "Введите пароль";
                return;
            }
            if (tbLogin.Text == "admin" && pbPassword.Password == "admin123")
            {
                adminpanel adminPanel = new adminpanel();
                adminPanel.Show();
                this.Close();
            }
            if (b == null)
            {
                errorLbl.Content = "Неправильный логин или пароль";
                errorLbl.Foreground = Brushes.Red;
                return;
            }
            else
            {
                main mainPage = new main();
                mainPage.Show();
                this.Close();
            }
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            reg regPage = new reg();
            regPage.Show();
            this.Close();
        }
    }
}
