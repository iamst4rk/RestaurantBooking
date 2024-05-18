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
using RestaurantBooking.DB;
using RestaurantBooking.windows;

namespace RestaurantBooking.windows
{
    /// <summary>
    /// Логика взаимодействия для main.xaml
    /// </summary>
    public partial class main : Window
    {
        public main()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            windows.order order = new windows.order();
            order.Show();
            this.Close();
        }

        private void btnAdminPanel_Click(object sender, RoutedEventArgs e)
        {
            windows.adminpanel adminpanel = new windows.adminpanel();
            adminpanel.Show();
            this.Close();
        }

        private void btnBooking_Click(object sender, RoutedEventArgs e)
        {
            windows.booking booking = new windows.booking();
            booking.Show();
            this.Close();
        }
    }
}
