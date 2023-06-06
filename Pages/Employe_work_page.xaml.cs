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

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для Desires.xaml
    /// </summary>
    public partial class Employe_work_page : Window
    {
        private readonly TatExpEntities _context = new TatExpEntities();
        public Employe_work_page()
        {
            InitializeComponent();
            if (Class1.order == null)
            {
                return;
            }
            var query = from Order in _context.Order
                        join prod_order in _context.Prod_order on Order.id equals prod_order.id_order
                        join product in _context.Product on prod_order.id_prod equals product.id
                        join orderCount in _context.Order on Order.id equals orderCount.id into orderGroup
                        where Order.id == Class1.order.id
                        group new { product, prod_order, orderGroup } by product.id into grouped
                        select new
                        {
                            grouped.FirstOrDefault().product.Photo,
                            grouped.FirstOrDefault().product.Name,
                            grouped.FirstOrDefault().product.Price,
                            id = grouped.Key,
                            grouped.FirstOrDefault().prod_order.Count
                        };

            ProductList.ItemsSource = query.ToList();


        }

        private void Voiti_Click(object sender, RoutedEventArgs e)
        {


            Order order = _context.Order.FirstOrDefault(s => s.id == Class1.order.id);
            order.Status_id = 3;
            _context.SaveChanges();
            this.Hide();

            Employe_page page = new Employe_page();  
            page.Show(); 
        }
    }
}
