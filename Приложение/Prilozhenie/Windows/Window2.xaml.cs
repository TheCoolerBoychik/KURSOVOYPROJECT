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
using System.Windows.Shapes;

namespace Prilozhenie
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            if (MainWindow.Globals.UserRole == 1)  // Разграничение для пользователя и админа
            {
                invisible.Visibility = Visibility.Visible;
            }
            else
            {
                invisible.Visibility = Visibility.Collapsed;
            }
        }
        private void Exit_Click(object sender, RoutedEventArgs e)  // кнопка выхода из аккаунта
        {
            MainWindow zxc = new MainWindow();
            zxc.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e) // кнопка перехода на договоры
        {
            Window1 zxc = new Window1();
            zxc.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)  // кнопка перехода на заявки
        {
            Window3 w3 = new Window3();
            w3.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)  // кнопка перехода на помещения
        {
            Window4 w5 = new Window4();
            w5.Show();
            this.Close();
        }
    }
}

