using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using WpfApp1.Pages;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public event EventHandler<string> SearchTextChanged;
        public UserControl1()
        {
            InitializeComponent();
            if (Class1.auth != null)
            {
                img_enter.Visibility = Visibility.Hidden;
                btn_enter.Visibility = Visibility.Hidden;
                img_user.Visibility = Visibility.Visible;
                string imagePath = Class1.auth.Photo;

                if (imagePath != "" && imagePath != null)
                {
                    BitmapImage image = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
                    img_user.Source = image;
                }

            }
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Class1.auth == null)
            {
                MessageBox.Show("Пожалуйста авторизируйтесь");
            }
            else
            {
                Desires desire = new Desires();
                desire.Show();
                Application.Current.Windows.OfType<System.Windows.Window>().Except(new[] { desire }).ToList().ForEach(w => w.Close());

            }
            }
        private readonly TatExpEntities _context = new TatExpEntities();
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
            if (Class1.auth != null)
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
                var a = query.ToList();
                if (a.Count != 0)
                {
                    Korzina korzina = new Korzina();
                    korzina.Show();
                    Application.Current.Windows.OfType<System.Windows.Window>().Except(new[] { korzina }).ToList().ForEach(w => w.Close());
                }
                else
                {
                    MessageBox.Show("В корзине нет товаров");
                }
            }
            else
            {
               
            
                MessageBox.Show("Авторизируйтесь");


            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Pages.Authorization authorization = new Pages.Authorization();
            authorization.Show();
            Application.Current.Windows.OfType<System.Windows.Window>().Except(new[] { authorization }).ToList().ForEach(w => w.Close());

        }

        private void img_user_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            UserPage userPage = new UserPage();
            userPage.Show();
            Application.Current.Windows.OfType<System.Windows.Window>().Except(new[] { userPage }).ToList().ForEach(w => w.Close());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Application.Current.Windows.OfType<System.Windows.Window>().Except(new[] { mainWindow }).ToList().ForEach(w => w.Close());
        }

        public void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchTextBox.Text;
            SearchTextChanged?.Invoke(this, searchText);
        }
    }
}
