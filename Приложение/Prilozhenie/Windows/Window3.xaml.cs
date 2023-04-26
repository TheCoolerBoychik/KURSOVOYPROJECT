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
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
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
        private void Window_Loaded(object sender, RoutedEventArgs e)  // функция для обновления данных на странице
        {
            Grid3.ItemsSource = AppData.db.Requests.ToList();
        }
        private void Add_Click(object sender, RoutedEventArgs e)  // кнопка добавления
        {
            Add2 dobavlenie = new Add2();
            dobavlenie.Show();
            this.Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)  // кнопка для удаления
        {
            if (MessageBox.Show("Вы точно хотите удалить следующие элементы?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var Current = Grid3.SelectedItem as Requests;
                AppData.db.Requests.Remove(Current);
                AppData.db.SaveChanges();

                Grid3.ItemsSource = AppData.db.Requests.ToList();
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
            Dobavlenie2 qwe = new Dobavlenie2(((sender as Button).DataContext as Requests));
            qwe.Show();
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
            Window2 w4 = new Window2();
            w4.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)  // добавление перехода
        {
            Window4 w5 = new Window4();
            w5.Show();
            this.Close();
        }

        private void Export_Click(object sender, RoutedEventArgs e)  // кнопка формирования отчета в ворде
        {
            var allRequest = DatabaseEntities.GetContext().Requests.ToList();

            var application = new Word.Application();

            Word.Document document = application.Documents.Add();

            Word.Paragraph userParagraph = document.Paragraphs.Add();
            Word.Range userRange = userParagraph.Range;
            userRange.Text = "Отчет по заявкам";

            userRange.InsertParagraphAfter();

            Word.Paragraph tableParagraph = document.Paragraphs.Add();
            Word.Range tableRange = tableParagraph.Range;
            Word.Table paymentsTable = document.Tables.Add(tableRange, allRequest.Count() + 1, 4);   // размер максимального кол-ва столбцов
            paymentsTable.Borders.InsideLineStyle = paymentsTable.Borders.OutsideLineStyle
                = Word.WdLineStyle.wdLineStyleSingle;
            paymentsTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            Word.Range cellRange;

            cellRange = paymentsTable.Cell(1, 1).Range;  // названия столбцов в экспортируемой таблице
            cellRange.Text = "ФИО клиента";
            cellRange = paymentsTable.Cell(1, 2).Range;
            cellRange.Text = "Номер телефона";
            cellRange = paymentsTable.Cell(1, 3).Range;
            cellRange.Text = "Город";
            cellRange = paymentsTable.Cell(1, 4).Range;
            cellRange.Text = "Email адрес";


            paymentsTable.Rows[1].Range.Bold = 1;
            paymentsTable.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            for (int i = 0; i < allRequest.Count(); i++)
            {
                var currentCategory = allRequest[i];  // добавление данных в столбцы
                {
                    cellRange = paymentsTable.Cell(i + 2, 1).Range;
                    cellRange.Text = Convert.ToString(currentCategory.FullName);
                    cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                    cellRange = paymentsTable.Cell(i + 2, 2).Range;
                    cellRange.Text = Convert.ToString(currentCategory.PhoneNumber);

                    cellRange = paymentsTable.Cell(i + 2, 3).Range;
                    cellRange.Text = Convert.ToString(currentCategory.City);

                    cellRange = paymentsTable.Cell(i + 2, 4).Range;
                    cellRange.Text = Convert.ToString(currentCategory.Email);

                }
            }

            application.Visible = true;

        }
    }
}



