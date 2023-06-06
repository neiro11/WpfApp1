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
    /// Логика взаимодействия для Employe_page.xaml
    /// </summary>
    public partial class Employe_page : Window
    {
        private readonly TatExpEntities _context = new TatExpEntities();
        public Employe_page()
        {
            InitializeComponent();



            var query = from order in _context.Order
                        join status in _context.Status on order.Status_id equals status.id
                        select new
                        {
                            order.id,
                            order.Price,
                            status.Name,
                            order.Count,
                            order.Date_create
                        };
            ProductList.ItemsSource = query.ToList();

        }

        private void Voiti_Click(object sender, RoutedEventArgs e)
        {

            Class1.order = null;
            Button button = (Button)sender;
            int orderId = (int)button.CommandParameter;
            Order order = _context.Order.FirstOrDefault(s => s.id == orderId);
            if (order != null)
            {

                Class1.order = order;
                Employe_work_page employe_Page = new Employe_work_page();
                employe_Page.Show();
            }
        } 
        
    }

}
