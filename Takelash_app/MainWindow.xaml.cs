using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Takelash_app.Pages;

namespace Takelash_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow init;
        public Main main;
        public MainWindow()
        {
            InitializeComponent();
            init = this;
            OpenPages(new Pages.Main());
        }
        public void OpenPages(Page pages)
        {
            frame.Navigate(pages);
        }
    }
}
