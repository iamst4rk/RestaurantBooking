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
using RestaurantBooking.windows;
using RestaurantBooking.pages;
using RestaurantBooking.DB;

namespace RestaurantBooking.windows
{
    /// <summary>
    /// Логика взаимодействия для adminpanel.xaml
    /// </summary>
    public partial class adminpanel : Window
    {
        public adminpanel()
        {
            InitializeComponent();
            menu menuPage = new menu();
            frMain.Navigate(menuPage);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            menu menuPage = new menu();
            frMain.Navigate(menuPage);
        }

        private void btnCoupon_Click(object sender, RoutedEventArgs e)
        {
            coupon couponPage = new coupon();
            frMain.Navigate(couponPage);
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            pages.order orderPage = new pages.order();
            frMain.Navigate(orderPage);
        }

        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            auth authPage = new auth();
            frMain.Navigate(authPage);
        }
    }
}
