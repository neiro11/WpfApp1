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
    /// Логика взаимодействия для Desires.xaml
    /// </summary>
    public partial class Desires : Window
    {
        private readonly TatExpEntities _context = new TatExpEntities();
        public Desires()
        {
            InitializeComponent();
            if (Class1.auth == null)
            {
                MessageBox.Show("Пожалуйста авторизируйтесь");
            }
            else
            {

                try
                {
                    int userId = Class1.auth.Id;
                    var query = from desire in _context.Desire
                                join desireProd in _context.Desire_prod on desire.id equals desireProd.id_desire
                                join product in _context.Product on desireProd.id_prod equals product.id
                                where desire.User_id == userId
                                select new
                                {
                                    product.id,
                                    product.Name,
                                    product.Price,
                                    product.Count,
                                    product.Description,
                                    product.Mass,
                                    product.Width,
                                    product.Height,
                                    product.Photo,
                                    product.Store_id
                                };

                    ProductList.ItemsSource = query.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("В избранных нет товаров");
                }
            }
        }
       
        private void Image_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)

        {
            //Class1.product = null;
            //var product = (sender as Image)?.DataContext as Product;
            //Class1.product = product;
            //if (Class1.auth != null)
            //{
            //    int id_user = Class1.auth.Id;
            //    Shoppping_cart shoppping_Cart = _context.Shoppping_cart.FirstOrDefault(s => s.User_id == id_user);

            //    //добавление корзины если ее не было
            //    if (shoppping_Cart == null)
            //    {
            //        shoppping_Cart = new Shoppping_cart
            //        {
            //            User_id = id_user
            //        };
            //        _context.Shoppping_cart.Add(shoppping_Cart);
            //        _context.SaveChanges();
            //    }
            //    //добавление товара в корзину
            //    Shop_cart_Prod Shop_cart_Prod1 = _context.Shop_cart_Prod.FirstOrDefault(s => s.id_prod == Class1.product.id && s.id_shop_cart == shoppping_Cart.id);
            //    if (Shop_cart_Prod1 == null)
            //    {
            //        Shop_cart_Prod shop_Cart_Prod = new Shop_cart_Prod
            //        {
            //            id_prod = Class1.product.id,
            //            id_shop_cart = shoppping_Cart.id,
            //            count = 1

            //        };
            //        _context.Shop_cart_Prod.Add(shop_Cart_Prod);
            //    }
            //    //Если товар уже есть в корзине у этого пользователя 
            //    else
            //    {

            //        Shop_cart_Prod1.count += 1;
            //    }
            //    _context.SaveChanges();
            //    MessageBox.Show("Товар добавлен");
            //}
            //else
            //{
            //    MessageBox.Show("Пожалуйста авторизируйтесь");
            //}
        }
    }
}
