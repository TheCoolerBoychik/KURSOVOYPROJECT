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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            if (MainWindow.Globals.UserRole == 1)  // разграничение для пользователей и админа
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
            Grid2.ItemsSource = AppData.db.Contracts.ToList();
        }
        private void Add_Click(object sender, RoutedEventArgs e)  // кнопка добавления
        {
            Add1 dobavlenie = new Add1();
            dobavlenie.Show();
            this.Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)  // кнопка для удаления
        {
            if (MessageBox.Show("Вы точно хотите удалить следующие элементы?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var CurrentSotrudnikii = Grid2.SelectedItem as Contracts;
                AppData.db.Contracts.Remove(CurrentSotrudnikii);
                AppData.db.SaveChanges();

                Grid2.ItemsSource = AppData.db.Contracts.ToList();
                MessageBox.Show("Удалено");
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)  // кнопка для редактирования
        {
            Dobavlenie zxc = new Dobavlenie(((sender as Button).DataContext as Contracts));
            zxc.Show();
            this.Close();
        }
        private void Exit_Click(object sender, RoutedEventArgs e)  // кнопка выхода из аккаунта
        {
            MainWindow zxc = new MainWindow();
            zxc.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)  // кнопка перехода на главная
        {
            Window1 w2 = new Window1();
            w2.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)  // кнопка перехода на заявки
        {
            Window2 w3 = new Window2();
            w3.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) // кнопка перехода на помещения
        {
            Window3 w4 = new Window3();
            w4.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)  // кнопка перехода на договоры
        {
            Window4 w4 = new Window4();
            w4.Show();
            this.Close();
        }

        private void Export_Click(object sender, RoutedEventArgs e)  // кнопка формирования отчета в ворде
        {
            var allRequest = DatabaseEntities.GetContext().Contracts.ToList();

            var application = new Word.Application();

            Word.Document document = application.Documents.Add();

            Word.Paragraph userParagraph = document.Paragraphs.Add();
            Word.Range userRange = userParagraph.Range;
            userRange.Text = "Отчет по договорам";

            userRange.InsertParagraphAfter();

            Word.Paragraph tableParagraph = document.Paragraphs.Add();
            Word.Range tableRange = tableParagraph.Range;
            Word.Table paymentsTable = document.Tables.Add(tableRange, allRequest.Count() + 1, 7);  // размер максимального кол-ва столбцов
            paymentsTable.Borders.InsideLineStyle = paymentsTable.Borders.OutsideLineStyle
                = Word.WdLineStyle.wdLineStyleSingle;
            paymentsTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            Word.Range cellRange;

            cellRange = paymentsTable.Cell(1, 1).Range;  // названия столбцов в экспортируемой таблице
            cellRange.Text = "Номер договора";
            cellRange = paymentsTable.Cell(1, 2).Range;
            cellRange.Text = "ФИО риелтора";
            cellRange = paymentsTable.Cell(1, 3).Range;
            cellRange.Text = "ФИО клиента";
            cellRange = paymentsTable.Cell(1, 4).Range;
            cellRange.Text = "Период договора";
            cellRange = paymentsTable.Cell(1, 5).Range;
            cellRange.Text = "Дата заключения";
            cellRange = paymentsTable.Cell(1, 6).Range;
            cellRange.Text = "Тип помещения";
            cellRange = paymentsTable.Cell(1, 7).Range;
            cellRange.Text = "Стоимость";


            paymentsTable.Rows[1].Range.Bold = 1;
            paymentsTable.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            for (int i = 0; i < allRequest.Count(); i++)
            {
                var currentCategory = allRequest[i];  // добавление данных в столбцы
                {
                    cellRange = paymentsTable.Cell(i + 2, 1).Range;
                    cellRange.Text = Convert.ToString(currentCategory.Number);
                    cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                    cellRange = paymentsTable.Cell(i + 2, 2).Range;
                    cellRange.Text = Convert.ToString(currentCategory.RieltorsFullName);

                    cellRange = paymentsTable.Cell(i + 2, 3).Range;
                    cellRange.Text = currentCategory.UsersFullName;

                    cellRange = paymentsTable.Cell(i + 2, 4).Range;
                    cellRange.Text = Convert.ToString(currentCategory.Period);

                    cellRange = paymentsTable.Cell(i + 2, 5).Range;
                    cellRange.Text = currentCategory.DateofContract.ToString("dd.MM.yyyy");

                    cellRange = paymentsTable.Cell(i + 2, 6).Range;
                    cellRange.Text = Convert.ToString(currentCategory.TypeOfRooms.title);

                    cellRange = paymentsTable.Cell(i + 2, 7).Range;
                    cellRange.Text = Convert.ToString(currentCategory.Amount);
                }


                application.Visible = true;

            }
        }
    }
}







