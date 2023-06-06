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
using System.Windows.Shapes;

namespace WpfApp1.Pages
{ 
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Catalog : Window
    {
        public Catalog()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Product_page W2 = new Product_page();
            W2.Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Authorization W3 = new Authorization();
            this.Hide();
            W3.Show();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            MainWindow MW = new MainWindow();
            this.Hide();
            MW.Show();
        }
    }
}
