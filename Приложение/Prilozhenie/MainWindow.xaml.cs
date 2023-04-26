using Prilozhenie.Model;
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

namespace Prilozhenie
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            password.IsEnabled = false;  //заблокировать поле ввода пароля
        }
        public static class Globals
        {
            public static int UserRole;
            public static Users userinfo { get; set; }
        }


        private void BtnSignIn_Click(object sender, RoutedEventArgs e)  // кнопка входа
        {
            var CurrentUser = AppData.db.Users.FirstOrDefault(u => u.Login == login.Text);  // подключение к Users
            if (CurrentUser != null)
            {
                Globals.UserRole = CurrentUser.RoleID;  // глобальный класс для пользователя
                Globals.userinfo = CurrentUser;
                password.IsEnabled = true;  // разблокировка пароля при проверке логина
                knopka.Visibility = Visibility.Hidden;
                knopka_2.Visibility = Visibility.Visible;

            }
            else
            {
                MessageBox.Show("Такого пользователя нет в базе!");  // уведомление
            }
        }

        private void Next_Btn(object sender, RoutedEventArgs e)
        {
            if (TXB2.Text == TXB1.Text)

            {
                Window2 zxc = new Window2();
                zxc.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Неверный код подтверждения!");  // уведомление о неверном коде подтверждения
            }
        }
        private async void BtnSignIn_Click_2(object sender, RoutedEventArgs e) // кнопка входа после проверки логина и пароля
        {
            var CurrentUser1 = AppData.db.Users.FirstOrDefault(u => u.Login == login.Text && u.Password == password.Password) ;
            if (CurrentUser1 != null)
            {
                Globals.UserRole = CurrentUser1.RoleID;  // ввод капчи
                Globals.userinfo = CurrentUser1;
                if (kapcha.Visibility == Visibility.Hidden)
                    kapcha.Visibility = Visibility.Visible;
                login.IsEnabled = false;
                password.IsEnabled = false;
                knopka_2.IsEnabled = false;
                while (true)
                {
                    Random x = new Random();  // генератор случайных чисел в капче
                    int a = x.Next(1000, 9999);
                    TXB1.Text = a.ToString();
                    await Task.Delay(10000);
                }
            }
            else
            {
                MessageBox.Show("Неверный пароль!");
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)  // кнопка обновления капчи
        {
            while (true)
            {
                Random x = new Random();
                int a = x.Next(1000, 9999);
                TXB1.Text = a.ToString();
                await Task.Delay(10000);
            }
        }
    }
}
