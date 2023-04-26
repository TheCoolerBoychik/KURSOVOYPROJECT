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
    /// Логика взаимодействия для Add1.xaml
    /// </summary>
    public partial class Add1 : Window
    {
        public Add1()
        {
            InitializeComponent();
            title.ItemsSource = AppData.db.TypeOfRooms.ToList(); // обращение к списку типов помещения
        }

        private void Save_Btn_Click(object sender, RoutedEventArgs e)  //кнопка сохранения
        {
            Contracts clients = new Contracts();

            clients.Number = number.Text;  //заполнение данных
            clients.RieltorsFullName = realtor.Text;
            clients.UsersFullName = user.Text;
            clients.Period = period.Text;
            clients.Amount = amount.Text;

            var CurrentDate = Date.SelectedDate.Value;  // функция для даты
            clients.DateofContract = CurrentDate;

            var CurrentOffice = title.SelectedItem as TypeOfRooms;
            clients.TypeOfRoomID = CurrentOffice.ID;

            AppData.db.Contracts.Add(clients);  // уведомления об успешном добавлении
            AppData.db.SaveChanges();
            MessageBox.Show("Добавлено");

            Window1 glavnoe = new Window1();  // переход на страницу 
            glavnoe.Show();
            this.Close();

        }


    }
}
