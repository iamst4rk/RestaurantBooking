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
using RestaurantBooking.DB;
using RestaurantBooking.pages;
using RestaurantBooking.edit;

namespace RestaurantBooking.pages
{
    /// <summary>
    /// Логика взаимодействия для order.xaml
    /// </summary>
    public partial class order : Page
    {
        public int x = 0;
        public order()
        {
            InitializeComponent();
            var a = DBconnect.RestaurantBooking.Order.ToList();
            dgOrder.ItemsSource = a;
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (rbNumber.IsChecked == true)
            {
                if (tbSearch.Text != "")
                {
                    var b = DBconnect.RestaurantBooking.Order.Where(p => p.Number.ToString().ToLower().Contains(tbSearch.Text.ToLower())).ToList();
                    dgOrder.ItemsSource = b.ToList();
                }
                else
                {
                    dgOrder.ItemsSource = DBconnect.RestaurantBooking.Order.ToList();
                }
            }
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (rbId.IsChecked == true)
            {
                int value = Convert.ToInt32(slider.Value);
                dgOrder.ItemsSource = DBconnect.RestaurantBooking.Order.Where(p => p.Order_ID >= value).ToList();
            }
        }

        private void miAdd_Click(object sender, RoutedEventArgs e)
        {
            x = 0;
            orderEdit orderEdit = new orderEdit(x);
            NavigationService.Navigate(orderEdit);
        }

        private void miEdit_Click(object sender, RoutedEventArgs e)
        {
            var a = dgOrder.SelectedItem as Order;
            x = 1;
            orderEdit orderEdit = new orderEdit(a, x);
            NavigationService.Navigate(orderEdit);
        }

        private void miDelete_Click(object sender, RoutedEventArgs e)
        {
            var delete = dgOrder.SelectedItem as Order;
            DBconnect.RestaurantBooking.Order.Remove(delete);
            DBconnect.RestaurantBooking.SaveChanges();
            dgOrder.ItemsSource = DBconnect.RestaurantBooking.Order.ToList();
        }
    }
}
