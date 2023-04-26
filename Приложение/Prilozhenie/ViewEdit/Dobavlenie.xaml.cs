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
    public partial class Dobavlenie : Window


    {
        private Contracts _currentHotel = new Contracts();
        public Dobavlenie(Contracts current)
        {
            InitializeComponent();

            if (current != null)
                _currentHotel = current;

            DataContext = _currentHotel;
            title.ItemsSource = DatabaseEntities.GetContext().TypeOfRooms.ToList(); // обращение к другой сущности

        }
         private void Save_Btn_Click(object sender, RoutedEventArgs e) // кнопка сохранения
        {
            Contracts clients = new Contracts();

            var zxc = title.SelectedItem as TypeOfRooms;
            if (_currentHotel.ID >= 0)
                DatabaseEntities.GetContext().Contracts.AddOrUpdate(_currentHotel);

            try
            {
                DatabaseEntities.GetContext().SaveChanges(); // окно с уведомлением о сохранении
                MessageBox.Show("Информация сохранена!");
                Window1 qwe = new Window1();
                qwe.Show();
                this.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            

        }

    }
}

