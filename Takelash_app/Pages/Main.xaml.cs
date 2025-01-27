using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using Excel = Microsoft.Office.Interop.Excel;

namespace Takelash_app.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public Classes.Client _client;
        public Classes.ClientContext _context = new Classes.ClientContext();
        public static MainWindow init;
        public Main()
        {
            InitializeComponent();
            //List<Classes.Client> list = _context.Clients.ToList();
            LoadItem();
        }

        public void LoadItem()
        {
            parent.Children.Clear();
            foreach (Classes.Client _cl in _context.Clients)
            {
                parent.Children.Add(new Elements.Client_El(_cl));
            }
        }

        //public void CreateUI()
        //{
        //    parent.Children.Clear();
        //    foreach (var partner in new Classes.ClientContext().Clients)
        //    {
        //        parent.Children.Add(new Elements.Client_El(partner));
        //    }
        //}

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.init.OpenPages(new Pages.Edit());
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EXEL_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog SFD = new SaveFileDialog
            {
                InitialDirectory = @"C:",
                Filter = "Excel Files (*.xlsx)|*.xlsx"
            };
            if (SFD.ShowDialog() == true)
            {
                var ExcelApp = new Excel.Application();
                Excel.Workbook Workbook = null;
                Excel.Worksheet Worksheet = null;
                try
                {
                    ExcelApp.Visible = false;
                    Workbook = ExcelApp.Workbooks.Add(Type.Missing);
                    Worksheet = (Excel.Worksheet)Workbook.ActiveSheet;
                    (Worksheet.Cells[1, 1] as Excel.Range).Value = $"Отчет о Партнерах: ";
                    int Row = 2;

                    // Заголовки
                    (Worksheet.Cells[Row, 1] as Excel.Range).Value = "Наименование";
                    (Worksheet.Cells[Row, 2] as Excel.Range).Value = "Описание";
                    (Worksheet.Cells[Row, 3] as Excel.Range).Value = "Дата";
                    (Worksheet.Cells[Row, 4] as Excel.Range).Value = "Номер телефона";
                    Row++;

                    foreach (Classes.Client Zal_Item in _context.Clients)
                    {
                        (Worksheet.Cells[Row, 1] as Excel.Range).Value = $"{Zal_Item.Name}";
                        (Worksheet.Cells[Row, 2] as Excel.Range).Value = $"{Zal_Item.Description}";
                        (Worksheet.Cells[Row, 3] as Excel.Range).Value = $"{Zal_Item.Date}";
                        (Worksheet.Cells[Row, 4] as Excel.Range).Value = $"{Zal_Item.Phone}";
                        Row++;
                    }

                    Workbook.SaveAs(SFD.FileName);
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    // Закрываем и освобождаем ресурсы
                    if (Worksheet != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(Worksheet);
                    if (Workbook != null)
                    {
                        Workbook.Close();
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(Workbook);
                    }
                    ExcelApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(ExcelApp);
                }
            }
        }
    }
}
