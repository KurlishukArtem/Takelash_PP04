using System;
using System.Collections.Generic;
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

namespace Takelash_app.Elements
{
    /// <summary>
    /// Логика взаимодействия для Client_El.xaml
    /// </summary>
    public partial class Client_El : UserControl
    {
        public Classes.Client _client;
        public Client_El(Classes.Client idclient = null)
        {
            InitializeComponent();
            _client = idclient;
            this.Name.Content = idclient.Name; /*new DataContext().typeCompanies.FirstOrDefault(x => x.id == partner.type).name + " | " + partner.name_company;*/
            //this.Discount.Content = idclient.Date.ToString();
            this.Director.Content = idclient.Description;
            this.Phone.Content = "+7 " + idclient.Phone.ToString().Insert(3, " ").Insert(7, " ").Insert(10, " ").Insert(13, " ");
            this.Rating.Content = idclient.Date.ToString();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.init.OpenPages(new Pages.Edit(_client));
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
