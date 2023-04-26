using Prilozhenie.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    public partial class Dobavlenie3 : Window


    {
        private Rooms _current = new Rooms();
        public Dobavlenie3(Rooms current)
        {
            InitializeComponent();

            if (current != null)
                _current = current;

            DataContext = _current;
            tip.ItemsSource = DatabaseEntities.GetContext().TypeOfRooms.ToList();
            counts.ItemsSource = DatabaseEntities.GetContext().CountsOfRooms.ToList();

        }
        private void Save_Btn_Click(object sender, RoutedEventArgs e)  // кнопка сохранения
        {
            Rooms clients = new Rooms();

            var zxc = tip.SelectedItem as TypeOfRooms;
            var asd = counts.SelectedItem as CountsOfRooms;
            if (_current.ID >= 0)
                DatabaseEntities.GetContext().Rooms.AddOrUpdate(_current);

            try
            {
                DatabaseEntities.GetContext().SaveChanges();  // окно с уведомлением о сохранении
                MessageBox.Show("Информация сохранена!");
                Window4 qwe = new Window4();
                qwe.Show();
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }


        }

    }
}

