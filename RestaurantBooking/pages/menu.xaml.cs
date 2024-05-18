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
using RestaurantBooking.windows;

namespace RestaurantBooking.pages
{
    /// <summary>
    /// Логика взаимодействия для menu.xaml
    /// </summary>
    public partial class menu : Page
    {
        public int x = 0;
        public menu()
        {
            InitializeComponent();
            var a = DBconnect.RestaurantBooking.Menu.ToList();
            dgMenu.ItemsSource = a;
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (rbName.IsChecked == true)
            {
                if (tbSearch.Text != "")
                {
                    var b = DBconnect.RestaurantBooking.Menu.Where(p => p.Name.ToString().ToLower().Contains(tbSearch.Text.ToLower())).ToList();
                    dgMenu.ItemsSource = b.ToList();
                }
                else
                {
                    dgMenu.ItemsSource = DBconnect.RestaurantBooking.Menu.ToList();
                }
            }
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (rbId.IsChecked == true)
            {
                int value = Convert.ToInt32(slider.Value);
                dgMenu.ItemsSource = DBconnect.RestaurantBooking.Menu.Where(p => p.Menu_ID >= value).ToList();
            }
        }

        private void miAdd_Click(object sender, RoutedEventArgs e)
        {
            x = 0;
            menuEdit menuEdit = new menuEdit(x);
            NavigationService.Navigate(menuEdit);
        }

        private void miEdit_Click(object sender, RoutedEventArgs e)
        {
            var a = dgMenu.SelectedItem as DB.Menu;
            x = 1;
            menuEdit menuEdit = new menuEdit(a, x);
            NavigationService.Navigate(menuEdit);
        }

        private void miDelete_Click(object sender, RoutedEventArgs e)
        {
            var delete = dgMenu.SelectedItem as DB.Menu;
            DBconnect.RestaurantBooking.Menu.Remove(delete);
            DBconnect.RestaurantBooking.SaveChanges();
            dgMenu.ItemsSource = DBconnect.RestaurantBooking.Menu.ToList();
        }
    }
}
