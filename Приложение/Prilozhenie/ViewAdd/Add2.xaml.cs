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
    /// Логика взаимодействия для Add2.xaml
    /// </summary>
    public partial class Add2 : Window
    {
        public Add2()
        {
            InitializeComponent();
        }

        private void Save_Btn_Click(object sender, RoutedEventArgs e)  //кнопка сохранения
        {
            Requests clients = new Requests();

            clients.FullName = name.Text;  //заполнение данных
            clients.PhoneNumber = number.Text;
            clients.City = city.Text;
            clients.Email = email.Text;

            AppData.db.Requests.Add(clients);  // уведомления об успешном добавлении
            AppData.db.SaveChanges();
            MessageBox.Show("Добавлено");

            Window3 glavnoe = new Window3();  // переход на страницу 
            glavnoe.Show();
            this.Close();

        }
    }
}
