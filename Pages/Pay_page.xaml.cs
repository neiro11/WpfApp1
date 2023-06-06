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
    /// Логика взаимодействия для Pay_page.xaml
    /// </summary>
    public partial class Pay_page : Window
    {
        private readonly TatExpEntities _context = new TatExpEntities();
        public Pay_page()
        {

            InitializeComponent();
            PVZ.ItemsSource = _context.Pick_point.OrderBy(pp => pp.id).ToList();
            PVZ.DisplayMemberPath = "Street"; // or whichever property you want to display in the ComboBox
            PVZ.SelectedValuePath = "id";

        }

        private void Voiti_Click(object sender, RoutedEventArgs e)
        {
            PP_order pp = new PP_order();
            pp.id_pp = PVZ.SelectedIndex;
            pp.Order_id = Class1.order.id;
            Order order1 = _context.Order.FirstOrDefault(cp => cp.id == Class1.order.id);
            order1.Status_id = 2;
            _context.SaveChanges();
            MessageBox.Show("Заказ успешно оплачен");
            MainWindow mainWindow   = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }
    }
}
