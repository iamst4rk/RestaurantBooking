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
using RestaurantBooking.DB;
using RestaurantBooking.windows;
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;

namespace RestaurantBooking.windows
{
    /// <summary>
    /// Логика взаимодействия для booking.xaml
    /// </summary>
    public partial class booking : Window
    {
        public int selectedTable = 0;
        public booking()
        {
            InitializeComponent();
            var a = DBconnect.RestaurantBooking.Auth.Where(c => c.User_ID == Properties.Settings.Default.Current_User_ID).FirstOrDefault();
            //tbID.Text = a.User_ID.ToString();
            btnReTable.Visibility = Visibility.Collapsed;
        }
        //public Booking change5 { get; set; }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            windows.main main = new windows.main();
            main.Show();
            this.Close();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void BtnTable1_Click(object sender, RoutedEventArgs e)
        {
            selectedTable = 1;
            BtnTable2.Visibility = Visibility.Collapsed;
            BtnTable3.Visibility = Visibility.Collapsed;
            BtnTable4.Visibility = Visibility.Collapsed;
            btnReTable.Visibility = Visibility.Visible;
            return;
        }

        private void BtnTable2_Click(object sender, RoutedEventArgs e)
        {
            selectedTable = 2;
            BtnTable1.Visibility = Visibility.Collapsed;
            BtnTable3.Visibility = Visibility.Collapsed;
            BtnTable4.Visibility = Visibility.Collapsed;
            btnReTable.Visibility = Visibility.Visible;
            return;
        }

        private void BtnTable3_Click(object sender, RoutedEventArgs e)
        {
            selectedTable = 3;
            BtnTable1.Visibility = Visibility.Collapsed;
            BtnTable2.Visibility = Visibility.Collapsed;
            BtnTable4.Visibility = Visibility.Collapsed;
            btnReTable.Visibility = Visibility.Visible;
            return;
        }

        private void BtnTable4_Click(object sender, RoutedEventArgs e)
        {
            selectedTable = 4;
            BtnTable1.Visibility = Visibility.Collapsed;
            BtnTable2.Visibility = Visibility.Collapsed;
            BtnTable3.Visibility = Visibility.Collapsed;
            btnReTable.Visibility = Visibility.Visible;
            return;
        }

        private void btnReTable_Click(object sender, RoutedEventArgs e)
        {
            selectedTable = 0;
            BtnTable1.Visibility = Visibility.Visible;
            BtnTable2.Visibility = Visibility.Visible;
            BtnTable3.Visibility = Visibility.Visible;
            BtnTable4.Visibility = Visibility.Visible;
        }

        private void btnBooking_Click(object sender, RoutedEventArgs e)
        {
            if (selectedTable == 0)
            {
                MessageBox.Show("Выберите стол!");
            }
            Booking b = new Booking();
            if (tbID.Text == "" || tbAmount.Text == "" || tbDate.Text == "" || startTime.Text == "" || endTime.Text == "")
            {
                MessageBox.Show("Заполните все поля");
            }
            //if (startTime.SelectedTime.Value.TimeOfDay > endTime.SelectedTime.Value.TimeOfDay)
            //{
            //    MessageBox.Show("Временя начала и конца бронирования указано неверно!");
            //}
            else
            {
                b.User_ID = Convert.ToInt32(tbID.Text);
                b.Table = selectedTable;
                b.Amount = Convert.ToInt32(tbAmount.Text);
                b.Date = tbDate.SelectedDate.Value;
                b.Start = startTime.SelectedTime.Value.TimeOfDay;
                b.End = endTime.SelectedTime.Value.TimeOfDay;
                DBconnect.RestaurantBooking.Booking.Add(b);
                DBconnect.RestaurantBooking.SaveChanges();
            }
            DBconnect.RestaurantBooking.SaveChanges();
            MessageBox.Show("Бронирование добавлено");
            main mainPage = new main();
            mainPage.Show();
            this.Close();
            //var a = DBconnect.RestaurantBooking.Where(c => c.User_ID == Properties.Settings.Default.Current_User_ID).FirstOrDefault();
            //DBconnect.RestaurantBooking = a.WorkerId;
        }
    }
} 
