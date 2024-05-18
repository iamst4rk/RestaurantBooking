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

namespace RestaurantBooking.edit
{
    /// <summary>
    /// Логика взаимодействия для orderEdit.xaml
    /// </summary>
    public partial class orderEdit : Page
    {
        public int x;
        public orderEdit(int x)
        {
            InitializeComponent();
            this.x = x;
        }
        public orderEdit(Order a, int x)
        {
            InitializeComponent();
            change4 = a;
            this.DataContext = this;
            this.x = x;
        }
        public Order change4 { get; set; }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (x == 0)
            {
                Order b = new Order();
                if (tbId.Text == "" || tbDate.Text == "" || tbStatus.Text == "" || tbNumber.Text == "" || tbFullPrice.Text == "")
                {
                    MessageBox.Show("Заполните все поля");
                    pages.order order = new pages.order();
                    NavigationService.Navigate(order);
                }
                else
                {
                    b.Order_ID = Convert.ToInt32(tbId.Text);
                    b.Date = Convert.ToDateTime(tbDate.Text);
                    b.Status = tbStatus.Text;
                    b.Number = tbNumber.Text;
                    b.FullPrice = Convert.ToInt32(tbFullPrice.Text);
                    DBconnect.RestaurantBooking.Order.Add(b);
                    DBconnect.RestaurantBooking.SaveChanges();
                }
            }
            DBconnect.RestaurantBooking.SaveChanges();
            pages.order order1 = new pages.order();
            NavigationService.Navigate(order1);
        }
    }
}
