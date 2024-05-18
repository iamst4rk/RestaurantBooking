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
    /// Логика взаимодействия для coupon.xaml
    /// </summary>
    public partial class coupon : Page
    {
        public int x = 0;
        public coupon()
        {
            InitializeComponent();
            var a = DBconnect.RestaurantBooking.Coupon.ToList();
            dgCoupon.ItemsSource = a;
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (rbName.IsChecked == true)
            {
                if (tbSearch.Text != "")
                {
                    var b = DBconnect.RestaurantBooking.Coupon.Where(p => p.Name.ToString().ToLower().Contains(tbSearch.Text.ToLower())).ToList();
                    dgCoupon.ItemsSource = b.ToList();
                }
                else
                {
                    dgCoupon.ItemsSource = DBconnect.RestaurantBooking.Coupon.ToList();
                }
            }
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (rbId.IsChecked == true)
            {
                int value = Convert.ToInt32(slider.Value);
                dgCoupon.ItemsSource = DBconnect.RestaurantBooking.Coupon.Where(p => p.Coupon_ID >= value).ToList();
            }
        }

        private void miAdd_Click(object sender, RoutedEventArgs e)
        {
            x = 0;
            couponEdit couponEdit = new couponEdit(x);
            NavigationService.Navigate(couponEdit);
        }

        private void miEdit_Click(object sender, RoutedEventArgs e)
        {
            var a = dgCoupon.SelectedItem as Coupon;
            x = 1;
            couponEdit couponEdit = new couponEdit(a, x);
            NavigationService.Navigate(couponEdit);
        }

        private void miDelete_Click(object sender, RoutedEventArgs e)
        {
            var delete = dgCoupon.SelectedItem as Coupon;
            DBconnect.RestaurantBooking.Coupon.Remove(delete);
            DBconnect.RestaurantBooking.SaveChanges();
            dgCoupon.ItemsSource = DBconnect.RestaurantBooking.Coupon.ToList();
        }
    }
}
