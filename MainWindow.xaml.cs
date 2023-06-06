using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using WpfApp1.Pages;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly TatExpEntities _context = new TatExpEntities();
        public MainWindow()
        {
            InitializeComponent();
            ProductList.ItemsSource = _context.Product.OrderBy(product => product.Name).ToList();
           
        }

        private void UserControl1_SearchTextChanged(object sender, string searchText)
        {
            MessageBox.Show("wow");
            // Handle the search text changed event here
            // You can access the updated search text using the 'searchText' parameter
            // Perform the search or update UI based on the new search text
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Catalog w1 = new Catalog();
            w1.Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Authorization W3 = new Authorization();
            this.Hide();
            W3.Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Korzina W4 = new Korzina();
            this.Hide();
            W4.Show();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            ProductList.ItemsSource = _context.Product.OrderBy(product => product.Name).ToList();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            Catalog W1 = new Catalog();
            this.Hide();
            W1.Show();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Class1.product = null;
            Product product = (sender as Image)?.DataContext as Product;
            Class1.product = product;
            this.Hide();
            Product_page product1 = new Product_page();
            product1.Show();
        }

        private void Image_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            Product product = (sender as Image)?.DataContext as Product;
            Class1.product = null;
            Class1.product = product;
            if (Class1.auth != null)
            {
                int id_user = Class1.auth.Id;
                Shoppping_cart shoppping_Cart = _context.Shoppping_cart.FirstOrDefault(s => s.User_id == id_user);

                //добавление корзины если ее не было
                if (shoppping_Cart == null)
                {
                    shoppping_Cart = new Shoppping_cart
                    {
                        User_id = id_user
                    };
                    _context.Shoppping_cart.Add(shoppping_Cart);
                    _context.SaveChanges();
                }
                //добавление товара в корзину
                Shop_cart_Prod Shop_cart_Prod1 = _context.Shop_cart_Prod.FirstOrDefault(s => s.id_prod == Class1.product.id && s.id_shop_cart == shoppping_Cart.id);
                if (Shop_cart_Prod1 == null)
                {
                    Shop_cart_Prod shop_Cart_Prod = new Shop_cart_Prod
                    {
                        id_prod = Class1.product.id,
                        id_shop_cart = shoppping_Cart.id,
                        count = 1

                    };
                    _context.Shop_cart_Prod.Add(shop_Cart_Prod);
                }
                //Если товар уже есть в корзине у этого пользователя 
                else
                {

                    Shop_cart_Prod1.count += 1;
                }
                _context.SaveChanges();
                MessageBox.Show("Товар добавлен");
            }
            else
            {
                MessageBox.Show("Пожалуйста авторизируйтесь");
            }
        }
    
    }
}