using System;
using System.Collections;
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
    /// Логика взаимодействия для Window4.xaml
    /// </summary>
    public partial class Korzina : Window
    {
        private readonly TatExpEntities _context = new TatExpEntities();
        public Korzina()
        {
            InitializeComponent();
            try
            {
               
                    int userId = Class1.auth.Id;
                    var query = from cart in _context.Shoppping_cart
                                join cartProd in _context.Shop_cart_Prod on cart.id equals cartProd.id_shop_cart
                                join product in _context.Product on cartProd.id_prod equals product.id
                                where cart.User_id == userId
                                select new
                                {
                                    product.Photo,
                                    product.Name,
                                    product.Price,
                                    product.id,
                                    cartProd.count
                                };

                    ProductList.ItemsSource = query.ToList();


                    int totalPrice = (int)query.Sum(p => p.Price * p.count);

                    // Update the itog_price label content
                    itog_price.Content = totalPrice.ToString("N0") + " P";
                    itog_price1.Content = totalPrice.ToString("N0") + " P";
                
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("В корзине нет товаров");
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Hide();
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MW = new MainWindow();
            this.Hide();
            MW.Show();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try {
                Button btn = sender as Button;
                int cartProdId = (int)btn.Tag; // get the id of the Shop_cart_Prod record associated with the clicked button
                var cartProd = _context.Shop_cart_Prod.FirstOrDefault(cp => cp.id_prod == cartProdId);
                if (cartProd != null)
                {
                    _context.Shop_cart_Prod.Remove(cartProd); // remove the record from the database
                    _context.SaveChanges(); // save changes to the database
                    var query = from cart in _context.Shoppping_cart
                                join cartProd1 in _context.Shop_cart_Prod on cart.id equals cartProd1.id_shop_cart
                                join product in _context.Product on cartProd1.id_prod equals product.id
                                where cart.User_id == Class1.auth.Id
                                select new
                                {
                                    cart.id,
                                    product.Photo,
                                    product.Name,
                                    product.Price,
                                    cartProd1.count
                                };
                    ProductList.ItemsSource = query.ToList(); // update the list view
                    int totalPrice = (int)query.Sum(p => p.Price * p.count);
                    itog_price.Content = totalPrice.ToString("N0") + " P";
                    itog_price1.Content = totalPrice.ToString("N0") + " P";
                }
            }
            catch (Exception) { }
            }


        

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            
            int itemCount = (ProductList.ItemsSource as IList)?.Count ?? 0;
            Order order = new Order();
            Class1.order = order;
            order.Date_create = DateTime.Now;
            order.User_id = Class1.auth.Id;
            order.Count = itemCount;
            string price_it = itog_price.Content.ToString();
            string p = price_it.Substring(0, price_it.Length - 2);
            p = new string(p.Where(c => !Char.IsWhiteSpace(c)).ToArray());
            order.Price = Convert.ToInt32(p);
            order.Status_id = 1;

            // Add the Order object to the database
            _context.Order.Add(order);


            foreach (var item in ProductList.ItemsSource)
            {


                // Получение Id и Count у продукта
                var productId = (int)item.GetType().GetProperty("id").GetValue(item);
                Product product = _context.Product.FirstOrDefault(cp => cp.id == productId);
                int productQuantity = (int)item.GetType().GetProperty("count").GetValue(item);
                product.Count = Convert.ToInt32(product.Count) - productQuantity;
                // Создание нового Prod_order
                Prod_order prodOrder = new Prod_order
                {
                    id_prod = productId,
                    id_order = order.id,
                    Count = productQuantity,

                };

                // Добавление Prod_order в БД
                _context.Prod_order.Add(prodOrder);
                
            }
            int userId = Class1.auth.Id;

            // Retrieve the shopping cart record for the current user
            var shoppingCart = _context.Shoppping_cart.FirstOrDefault(sc => sc.User_id == userId);

            if (shoppingCart != null)
            {
                // Retrieve all the shop_cart_prod records for the shopping cart

                var cartProducts = _context.Shop_cart_Prod.Where(cp => cp.id_shop_cart == shoppingCart.id).ToList();

                // Delete all the shop_cart_prod records
                foreach (var cartProduct in cartProducts)
                {
                    _context.Shop_cart_Prod.Remove(cartProduct);
                   
                }


                // Save the changes to the database
            }
            _context.SaveChanges();
            this.Hide();
            Pay_page pay_Page   = new Pay_page();   
            pay_Page.Show();    
        }
    }
}
