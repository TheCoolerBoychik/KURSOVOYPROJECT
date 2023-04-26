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
    public partial class Dobavlenie2 : Window


    {
        private Requests _current = new Requests();
        public Dobavlenie2(Requests current1)
        {
            InitializeComponent();

            if (current1 != null)
                _current = current1;

            DataContext = _current;

        }
        private void Save_Btn_Click(object sender, RoutedEventArgs e)  // кнопка сохранения
        {
            Requests clients = new Requests();

            
            if (_current.ID >= 0)
                DatabaseEntities.GetContext().Requests.AddOrUpdate(_current);

            try
            {
                DatabaseEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                Window3 qwe = new Window3();  // переход на страницу заполнения заявки
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

