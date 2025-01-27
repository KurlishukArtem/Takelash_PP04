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
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Takelash_app.Pages
{
    /// <summary>
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    public partial class Edit : Page
    {
        Classes.Client cLient;
        Classes.CompContext _compContext;
        public Edit(Classes.Client _client = null)
        {
            InitializeComponent();
            cLient = _client;
            if (cLient != null)
            {
                Add.Content = "Изменить";
                this.tb_name.Text = cLient.Name;
                this.tb_desc.Text = cLient.Description;
                this.tb_date.Text = cLient.Date;
                this.tb_phone.Text = cLient.Phone;
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.init.OpenPages(new Pages.Main());
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (tb_name.Text == "")
            {
                MessageBox.Show("Не указано наименование", "Заполните поле!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (tb_desc.Text == "")
            {
                MessageBox.Show("не указано описание", "Заполните поле!", MessageBoxButton.OK, MessageBoxImage.Error);
                return ;
            }
            if(tb_date.Text == "")
            {
                MessageBox.Show("Не указана дата", "Заполните поле!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!Regex.IsMatch(tb_phone.Text, @"^\d{10}$"))
            {
                MessageBox.Show("Неверный номер телефона", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Classes.ClientContext client = new Classes.ClientContext();
            
            if (cLient == null)
            {
                Classes.Client newClient = new Classes.Client();
                newClient.Name = tb_name.Text;
                newClient.Description = tb_desc.Text;
                newClient.Date = tb_date.Text;
                newClient.Phone = tb_phone.Text;

                client.Clients.Add(newClient);
                client.SaveChanges();

                MainWindow.init.OpenPages(new Pages.Main());

                MessageBox.Show("Партнёр успешно добавлен", "Добавление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {

                cLient.Name = tb_name.Text;
                cLient.Description = tb_desc.Text;
                cLient.Date = tb_date.Text;
                cLient.Phone = tb_phone.Text;

                client.Clients.Update(cLient);
                client.SaveChanges();

                MainWindow.init.OpenPages(new Pages.Main());

                MessageBox.Show("Партнёр успешно Изменен", "Изменение", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
    }
}
