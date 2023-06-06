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
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Product_page : Window
    {
        private readonly TatExpEntities _context = new TatExpEntities();
        
        public Product_page()
        {
            InitializeComponent();
             if(Class1.product != null)
             {

                int id_store = Class1.product.Store_id;
                Store store = _context.Store.FirstOrDefault(s => s.id == id_store);
                Class1.store = store;   
                NameProduct.Content = Class1.product.Name;
                NameProdavec.Content = store.Name;
                Describe.Text = Class1.product.Description;
                Price.Content = Class1.product.Price + "₽";
                Nalichie.Content = Class1.product.Count;
                Skidka.Text = Convert.ToDouble(Class1.product.Price) + "₽";
                string imagePath = Class1.product.Photo;
                BitmapImage image = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
                img_prod.Source = image;


            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Authorization W3 = new Authorization();
            W3.Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow MW = new MainWindow();
            this.Hide();
            MW.Show();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
           
        }

       

        private void AddToBasket_Click(object sender, RoutedEventArgs e)
        {
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
                        count = Convert.ToInt32(Count_add.Text)

                    };
                    _context.Shop_cart_Prod.Add(shop_Cart_Prod);
                }
                //Если товар уже есть в корзине у этого пользователя 
                else
                {

                    Shop_cart_Prod1.count = Shop_cart_Prod1.count + Convert.ToInt32(Count_add.Text);  
                }
                _context.SaveChanges();
                MessageBox.Show("Товар добавлен");
            }
            else
            {
                MessageBox.Show("Пожалуйста авторизируйтесь");
            }
        }

        private void izbran_Click(object sender, RoutedEventArgs e)
        {
            if (Class1.auth != null)
            {
                int id_user = Class1.auth.Id;
                Desire desire = _context.Desire.FirstOrDefault(s => s.User_id == id_user);

                //добавление избранного если ее не было
                if (desire == null)
                {
                    desire = new Desire();
                    desire.User_id = id_user;
                    _context.Desire.Add(desire);
                    _context.SaveChanges();
                }
                //добавление товара в избранное
                Desire_prod Shop_cart_Prod1 = _context.Desire_prod.FirstOrDefault(s => s.id_prod == Class1.product.id && s.id_desire == desire.id);
                if (Shop_cart_Prod1 == null)
                {
                    Desire_prod desire_Prod = new Desire_prod
                    {
                        id_prod = Class1.product.id,
                        id_desire = desire.id,
                       

                    };
                    _context.Desire_prod.Add(desire_Prod);
                }
                //Если товар уже есть в избранных у этого пользователя 
                else
                {

                    MessageBox.Show("У вас уже есть этот товар в избранных");
                }
                _context.SaveChanges();
                MessageBox.Show("Товар добавлен в избранные");
            }
            else
            {
                MessageBox.Show("Пожалуйста авторизируйтесь");
            }
        }

        private void NameProdavec_Click(object sender, RoutedEventArgs e)
        {
           StorePage store = new StorePage();
            store.Show();
            this.Hide();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Count_add.Text =  (Convert.ToInt32(Count_add.Text) + 1).ToString();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Count_add.Text != "1") {
                Count_add.Text = (Convert.ToInt32(Count_add.Text) - 1).ToString();
            }
        }

    }
}
