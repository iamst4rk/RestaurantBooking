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
    /// Логика взаимодействия для menuEdit.xaml
    /// </summary>
    public partial class menuEdit : Page
    {
        public int x;
        bool bobux = true;
        public byte[] mainImage;
        public menuEdit(int x)
        {
            InitializeComponent();
            this.x = x;
            bobux = false;
            List<DB.Menu> menus = DB.DBconnect.RestaurantBooking.Menu.ToList();
        }
        public menuEdit(DB.Menu a, int x)
        {
            InitializeComponent();
            change3 = a;
            bobux = true;
            this.DataContext = this;
            this.x = x;
        }
        public DB.Menu change3 { get; set; }

        private void btnImage_Click(object sender, RoutedEventArgs e)
        {
            string imagePath = "";
            ofd = new OpenFileDialog();
            ofd.Filter = "Image |*.png; *.jpg; *.jpeg";
            if (ofd.ShowDialog() == true)
            {
                mainImage = File.ReadAllBytes(ofd.FileName);
                imageMenu.DataContext = File.ReadAllBytes(ofd.FileName);
                imagePath = ofd.FileName;
            }
        }
        OpenFileDialog ofd = new OpenFileDialog();
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!bobux)
                {
                    DB.Menu menu = new DB.Menu();
                    menu.Name = tbName.Text;
                    menu.Price = Convert.ToDecimal(tbPrice.Text);
                    menu.Description = tbDescription.Text;
                    menu.Type = tbType.Text;
                    menu.Image = File.ReadAllBytes(ofd.FileName);
                    DBconnect.RestaurantBooking.Menu.Add(menu);
                    DBconnect.RestaurantBooking.SaveChanges();
                    MessageBox.Show("Новое меню успешно добавлено!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    change3.Image = mainImage;
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
    }
}
