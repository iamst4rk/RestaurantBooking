using System;
using System.Collections.Generic;
using System.Data;
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
using RestaurantBooking.Properties;
using RestaurantBooking.DB;
using RestaurantBooking.windows;

namespace RestaurantBooking.windows
{
    /// <summary>
    /// Логика взаимодействия для order.xaml
    /// </summary>
    public partial class order : Window
    {
        static List<DB.Menu> menu = new List<DB.Menu>();
        static List<Coupon> coupons = new List<Coupon>();
        public order()
        {
            InitializeComponent();
            btnPay.Visibility = Visibility.Hidden;
            lvBurger.ItemsSource = DBconnect.RestaurantBooking.Menu.Where(x => x.Type == "Завтрак").ToList();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnbreakfast_Click(object sender, RoutedEventArgs e)
        {
            lvBurger.ItemsSource = DBconnect.RestaurantBooking.Menu.Where(x => x.Type == "Завтрак").ToList();
        }

        private void btnSalad_Click(object sender, RoutedEventArgs e)
        {
            lvBurger.ItemsSource = DBconnect.RestaurantBooking.Menu.Where(x => x.Type == "Салат").ToList();
        }

        private void btnSoup_Click(object sender, RoutedEventArgs e)
        {
            lvBurger.ItemsSource = DBconnect.RestaurantBooking.Menu.Where(x => x.Type == "Суп").ToList();
        }

        private void btnHotdishes_Click(object sender, RoutedEventArgs e)
        {
            lvBurger.ItemsSource = DBconnect.RestaurantBooking.Menu.Where(x => x.Type == "Горячие блюда").ToList();
        }

        private void btnDesserts_Click(object sender, RoutedEventArgs e)
        {
            lvBurger.ItemsSource = DBconnect.RestaurantBooking.Menu.Where(x => x.Type == "Десерт").ToList();
        }

        private void btnDrinks_Click(object sender, RoutedEventArgs e)
        {
            lvBurger.ItemsSource = DBconnect.RestaurantBooking.Menu.Where(x => x.Type == "Напиток").ToList();
        }
        private void btnCoupons_Click(object sender, RoutedEventArgs e)
        {
            lvBurger.ItemsSource = DBconnect.RestaurantBooking.Coupon.ToList();
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            btnPay.Visibility = Visibility.Visible;
            var a = ((Button)sender).DataContext.GetType();
            if (a.BaseType == typeof(Coupon))
            {
                var c = (Coupon)((Button)sender).DataContext;
                coupons.Add(c);
                dgCoupon.ItemsSource = null;
                dgCoupon.ItemsSource = coupons;
            }
            else if (a.BaseType == typeof(DB.Menu))
            {
                var m = (DB.Menu)((Button)sender).DataContext;
                menu.Add(m);
                dgBasket.ItemsSource = null;
                dgBasket.ItemsSource = menu;
            }
            decimal? msum = menu.Sum(x => x.Price);
            decimal? csum = coupons.Sum(z => z.Price);
            tbSum.Text = (msum + csum).ToString();
            tbSum.Text= tbSum.Text.Remove(tbSum.Text.Length - 5);
        }
        private void btnPay_Click(object sender, RoutedEventArgs e)
        {
            btnClear.Visibility = Visibility.Collapsed;
            Random random = new Random();
            int value = random.Next(0, 100);
            try
            {
                Order order = new Order();
                order.Date = DateTime.Now;
                order.Status = "Принят";
                order.Number = "A-" + value;
                order.FullPrice = Convert.ToDecimal(tbSum.Text);
                var y = dgCoupon.ItemsSource as List<Coupon>;
                var x = dgBasket.ItemsSource as List<DB.Menu>;
                if (x!=null)
                {
                    foreach (var item in x)
                    {

                        order.OrderMenu.Add(new OrderMenu()
                        {
                            Order = order,
                            Menu = item
                        });
                    }
                    DBconnect.RestaurantBooking.Order.Add(order);
                }
                else
                {
                    foreach (var item in y)
                    {

                        order.OrderCoupon.Add(new OrderCoupon()
                        {
                            Order = order,
                             Coupon= item
                        });
                    }
                    DBconnect.RestaurantBooking.Order.Add(order);
                }
              
                
                DBconnect.RestaurantBooking.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            dgBasket.Visibility = Visibility.Collapsed;
            dgCoupon.Visibility = Visibility.Collapsed;
            btnPay.Visibility = Visibility.Collapsed;
            tbBasket.Text = "Номер вашего заказа A-" + value;
            tbBasket.FontSize = 30;
            tbSum.FontSize = 30;
            tbPrice.FontSize = 30;
            tbRubles.FontSize = 30;
            spOrder.Background = new SolidColorBrush(Color.FromRgb(9, 24, 45));
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            menu.Clear();
            coupons.Clear();
            dgBasket.ItemsSource = null;
            dgCoupon.ItemsSource = null;
            tbSum.Text = "0";
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            main main = new main();
            main.Show();
            this.Close();
        }

        private void btnReOrder_Click(object sender, RoutedEventArgs e)
        {
            menu.Clear();
            coupons.Clear();
            dgBasket.ItemsSource = null;
            dgCoupon.ItemsSource = null;
            tbSum.Text = "0";
            order orderPage = new order();
            orderPage.Show();
            this.Close();
        }
    }
}
