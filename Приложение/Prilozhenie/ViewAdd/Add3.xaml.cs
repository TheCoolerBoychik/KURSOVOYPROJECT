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
    /// Логика взаимодействия для Dobavlenie.xaml
    /// </summary>
    public partial class Add3 : Window
    {
        public Add3()
        {
            InitializeComponent();
            counts.ItemsSource = AppData.db.CountsOfRooms.ToList(); // обращения к списку кол-ва комнат
            tip.ItemsSource = AppData.db.TypeOfRooms.ToList();  // обращение к свиску типов помещений
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Rooms clients = new Rooms();

            clients.address = address.Text;  //заполнение данных
            clients.Town = town.Text;
            clients.Price = price.Text;


            var Current = counts.SelectedItem as CountsOfRooms;  // обращение к свиску типов помещений
            clients.CountOfRoomID = Current.ID;

            var Current1 = tip.SelectedItem as TypeOfRooms;
            clients.TypeOfRoomID = Current1.ID;

            AppData.db.Rooms.Add(clients);  // уведомления об успешном добавлении
            AppData.db.SaveChanges();
            MessageBox.Show("Добавлено");

            Window4 glavnoe = new Window4();  // переход на страницу 
            glavnoe.Show();
            this.Close();
        }
    }
}
