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
using Microsoft.Win32;
using RestaurantBooking.DB;
using RestaurantBooking.pages;

namespace RestaurantBooking.edit
{
    /// <summary>
    /// Логика взаимодействия для couponEdit.xaml
    /// </summary>
    public partial class couponEdit : Page
    {
        public int x;
        bool bobux = true;
        public byte[] mainImage;
        public couponEdit(int x)
        {
            InitializeComponent();
            this.x = x;
            bobux = false;
            List<Coupon> coupons = DB.DBconnect.RestaurantBooking.Coupon.ToList();
        }
        public couponEdit(Coupon a, int x)
        {
            InitializeComponent();
            change2 = a;
            bobux = true;
            this.DataContext = this;
            this.x = x;
        }

        public Coupon change2 { get; set; }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!bobux)
                {
                    Coupon coupon = new Coupon();
                    coupon.Name = tbName.Text;
                    coupon.Price = Convert.ToDecimal(tbPrice.Text);
                    coupon.Image = File.ReadAllBytes(ofd.FileName) ;
                    DBconnect.RestaurantBooking.Coupon.Add(coupon);
                    DBconnect.RestaurantBooking.SaveChanges();
                    MessageBox.Show("Новый купон успешно добавлен!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    change2.Image = mainImage;
                    DBconnect.RestaurantBooking.SaveChanges();
                    MessageBox.Show("Данные обновлены", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                NavigationService.GoBack();
            }
            catch (Exception)
            {
                MessageBox.Show("Введены некорректные данные или остались незаполненные поля!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        OpenFileDialog ofd = new OpenFileDialog();
        private void btnImage_Click(object sender, RoutedEventArgs e)
        {
            string imagePath = "";
            ofd = new OpenFileDialog();
            ofd.Filter = "Image |*.png; *.jpg; *.jpeg";
            if (ofd.ShowDialog() == true)
            {
                mainImage = File.ReadAllBytes(ofd.FileName);
                imageCoupon.DataContext = File.ReadAllBytes(ofd.FileName);
                imagePath = ofd.FileName;

            }
        }
    }
}
