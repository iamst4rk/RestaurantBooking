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
    /// Логика взаимодействия для authEdit.xaml
    /// </summary>
    public partial class authEdit : Page
    {
        public int x;
        public authEdit(int x)
        {
            InitializeComponent();
            this.x = x;
        }
        public authEdit(Auth a, int x)
        {
            InitializeComponent();
            change1 = a;
            this.DataContext = this;
            this.x = x;
        }

        public Auth change1 { get; set; }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (x == 0)
            {
                Auth b = new Auth();
                if (tbId.Text == "" || tbLogin.Text == "" || tbPassword.Text == "" || tbFIO.Text == "" || tbMail.Text == "")
                {
                    MessageBox.Show("Заполните все поля");
                    auth auth = new auth();
                    NavigationService.Navigate(auth);
                }
                else
                {
                    b.User_ID = Convert.ToInt32(tbId.Text);
                    b.Login = tbLogin.Text;
                    b.Password = tbPassword.Text;
                    b.FIO = tbFIO.Text;
                    b.Mail = tbMail.Text;
                    DBconnect.RestaurantBooking.Auth.Add(b);
                    DBconnect.RestaurantBooking.SaveChanges();
                }
            }
            DBconnect.RestaurantBooking.SaveChanges();
            auth auth1 = new auth();
            NavigationService.Navigate(auth1);
        }
    }
}
