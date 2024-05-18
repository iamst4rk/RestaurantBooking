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
using RestaurantBooking.edit;

namespace RestaurantBooking.pages
{
    /// <summary>
    /// Логика взаимодействия для auth.xaml
    /// </summary>
    public partial class auth : Page
    {
        public int x = 0;
        public auth()
        {
            InitializeComponent();
            var a = DBconnect.RestaurantBooking.Auth.ToList();
            dgAuth.ItemsSource = a;
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (rbId.IsChecked == true)
            {
                int value = Convert.ToInt32(slider.Value);
                dgAuth.ItemsSource = DBconnect.RestaurantBooking.Auth.Where(p => p.User_ID >= value).ToList();
            }
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (rbFIO.IsChecked == true)
            {
                if (tbSearch.Text != "")
                {
                    var b = DBconnect.RestaurantBooking.Auth.Where(p => p.FIO.ToString().ToLower().Contains(tbSearch.Text.ToLower())).ToList();
                    dgAuth.ItemsSource = b.ToList();
                }
                else
                {
                    dgAuth.ItemsSource = DBconnect.RestaurantBooking.Auth.ToList();
                }
            }
        }
        private void miAdd_Click(object sender, RoutedEventArgs e)
        {
            x = 0;
            authEdit authEdit = new authEdit(x);
            NavigationService.Navigate(authEdit);
        }

        private void miEdit_Click(object sender, RoutedEventArgs e)
        {
            var a = dgAuth.SelectedItem as Auth;
            x = 1;
            authEdit authEdit = new authEdit(a, x);
            NavigationService.Navigate(authEdit);
        }

        private void miDelete_Click(object sender, RoutedEventArgs e)
        {
            var delete = dgAuth.SelectedItem as Auth;
            DBconnect.RestaurantBooking.Auth.Remove(delete);
            DBconnect.RestaurantBooking.SaveChanges();
            dgAuth.ItemsSource = DBconnect.RestaurantBooking.Auth.ToList();
        }
    }
}
