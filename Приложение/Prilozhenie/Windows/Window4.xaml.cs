using Prilozhenie.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using Word = Microsoft.Office.Interop.Word;

namespace Prilozhenie
{
    /// <summary>
    /// Логика взаимодействия для Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();

            if (MainWindow.Globals.UserRole == 1) // Разграничение для пользователя
            {
                invisible.Visibility = Visibility.Visible;
            }
            else
            {
                invisible.Visibility = Visibility.Collapsed;
            }
            if (MainWindow.Globals.UserRole == 1)
            {
                invisible1.Visibility = Visibility.Visible;
            }
            else
            {
                invisible1.Visibility = Visibility.Collapsed;
            }
            if (MainWindow.Globals.UserRole == 1)
            {
                invisible2.Visibility = Visibility.Visible;
            }
            else
            {
                invisible2.Visibility = Visibility.Collapsed;
            }
            if (MainWindow.Globals.UserRole == 1)
            {
                invisible3.Visibility = Visibility.Visible;
            }
            else
            {
                invisible3.Visibility = Visibility.Collapsed;
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)  // функция для обновления данных на странице
        {
            Grid4.ItemsSource = AppData.db.Rooms.ToList();
        }
        private void Add_Click(object sender, RoutedEventArgs e)  // кнопка добавления
        {
            Add3 dobavlenie = new Add3();
            dobavlenie.Show();
            this.Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)  // кнопка удаления 
        {
            if (MessageBox.Show("Вы точно хотите удалить следующие элементы?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var Current1 = Grid4.SelectedItem as Rooms;
                AppData.db.Rooms.Remove(Current1);
                AppData.db.SaveChanges();

                Grid4.ItemsSource = AppData.db.Rooms.ToList();
                MessageBox.Show("Удалено");
            }
        }
        private void Exit_Click(object sender, RoutedEventArgs e)  // кнопка выхода из аккаунта
        {
            MainWindow zxc = new MainWindow();
            zxc.Show();
            this.Close();
        }
        private void Edit_Click(object sender, RoutedEventArgs e)  // кнопка редактирования
        {
            Dobavlenie3 zxc = new Dobavlenie3(((sender as Button).DataContext as Rooms));
            zxc.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)  // добавление перехода
        {
            Window1 w2 = new Window1();
            w2.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)  // добавление перехода
        {
            Window2 w3 = new Window2();
            w3.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)  // добавление перехода
        {
            Window3 w4 = new Window3();
            w4.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)  // добавление перехода
        {

        }

        private void Export_Click(object sender, RoutedEventArgs e)  // добавление перехода
        {
            var allRequest = DatabaseEntities.GetContext().Rooms.ToList();

            var application = new Word.Application();

            Word.Document document = application.Documents.Add();

            Word.Paragraph userParagraph = document.Paragraphs.Add();
            Word.Range userRange = userParagraph.Range;
            userRange.Text = "Отчет по помещениям";

            userRange.InsertParagraphAfter();

            Word.Paragraph tableParagraph = document.Paragraphs.Add();
            Word.Range tableRange = tableParagraph.Range;
            Word.Table paymentsTable = document.Tables.Add(tableRange, allRequest.Count() + 1, 5);  // размер максимального кол-ва столбцов
            paymentsTable.Borders.InsideLineStyle = paymentsTable.Borders.OutsideLineStyle
                = Word.WdLineStyle.wdLineStyleSingle;
            paymentsTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            Word.Range cellRange;

            cellRange = paymentsTable.Cell(1, 1).Range;   // названия столбцов в экспортируемой таблице
            cellRange.Text = "Тип помещения";
            cellRange = paymentsTable.Cell(1, 2).Range;
            cellRange.Text = "Город";
            cellRange = paymentsTable.Cell(1, 3).Range;
            cellRange.Text = "Адрес недвижимости";
            cellRange = paymentsTable.Cell(1, 4).Range;
            cellRange.Text = "Цена";
            cellRange = paymentsTable.Cell(1, 5).Range;
            cellRange.Text = "Кол-во комнат";


            paymentsTable.Rows[1].Range.Bold = 1;
            paymentsTable.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            for (int i = 0; i < allRequest.Count(); i++)
            {
                var currentCategory = allRequest[i];  // добавление данных в столбцы
                {
                    cellRange = paymentsTable.Cell(i + 2, 1).Range;
                    cellRange.Text = Convert.ToString(currentCategory.TypeOfRooms.title);
                    cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                    cellRange = paymentsTable.Cell(i + 2, 2).Range;
                    cellRange.Text = Convert.ToString(currentCategory.Town);

                    cellRange = paymentsTable.Cell(i + 2, 3).Range;
                    cellRange.Text = Convert.ToString(currentCategory.address);

                    cellRange = paymentsTable.Cell(i + 2, 4).Range;
                    cellRange.Text = Convert.ToString(currentCategory.Price);

                    cellRange = paymentsTable.Cell(i + 2, 5).Range;
                    cellRange.Text = Convert.ToString(currentCategory.CountsOfRooms.type);
                }
            }

            application.Visible = true;

        }
    }
}




