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
    }
}
