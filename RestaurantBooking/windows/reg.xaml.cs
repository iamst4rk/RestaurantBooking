using RestaurantBooking.DB;
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
using System.Windows.Shapes;

namespace RestaurantBooking.windows
{
    /// <summary>
    /// Логика взаимодействия для reg.xaml
    /// </summary>
    public partial class reg : Window
    {
        public reg()
        {
            InitializeComponent();
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Auth b = new Auth();
                b.Login = Convert.ToString(tbLogin.Text);
                b.Password = Convert.ToString(pbPassword.Password);
                b.FIO = Convert.ToString(tbFIO.Text);
                b.Phone = Convert.ToString(tbPhone.Text);
                b.Mail = Convert.ToString(tbMail.Text);
                DBconnect.RestaurantBooking.Auth.Add(b);
                DBconnect.RestaurantBooking.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Произошла ошибка, попробуйте еще раз!");
            }
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
