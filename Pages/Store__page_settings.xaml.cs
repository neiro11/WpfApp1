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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для Vender_page.xaml
    /// </summary>
    public partial class Store_page_settings : Window
    {
        private readonly TatExpEntities _context = new TatExpEntities();
        public Store_page_settings()
        {
            InitializeComponent();
           
            StoreName.Text = Class1.store.Name;
            Descp.Text = Class1.store.Description;
            string imagePath = Class1.store.Logo;
            if (imagePath != null)
            {
                BitmapImage image = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));

                MyImage.Source = image;
            }
            int storeId = Class1.store.id;
            var query = from p in _context.Product
                        where p.Store_id == storeId
                        select new
                        {
                            p.Name,
                            p.Price,
                            p.Photo
                        };
            ProductList.ItemsSource = query.ToList();
        }

        //Сохранение измененеий
        private void Voiti_Copy_Click(object sender, RoutedEventArgs e)
        {


            Store store = _context.Store.FirstOrDefault(s => s.id == Class1.store.id);
            if (store != null)
            {
                if (Store_name.Text == null || Store_name.Text == "")
                {
                    store.Name = Class1.store.Name;
                }
                else
                {
                    store.Name = Store_name.Text;
                }
                if (Store_logo.Text == null || Store_logo.Text == "")
                {
                    store.Logo = Class1.store.Logo;
                }
                else
                {
                    store.Logo = Store_logo.Text;
                }
                if (Store_desc.Text == null || Store_desc.Text == "")
                {
                    store.Description = Class1.store.Description;
                }
                else
                {
                    store.Description = Store_desc.Text;
                }
                MessageBox.Show("Данные успешно измененены");
                _context.SaveChanges();
                Class1.store = store;
            }
            this.Hide();
            Vender_page vender_Page = new Vender_page();
            vender_Page.Show();
           

        }

        private void Store_settings_Click(object sender, RoutedEventArgs e)
        {

        }

        //Добавление товара
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Class1.store.Name == "Наименование магазина" || Class1.store.Description == "Описание магазина" || Class1.store.Logo == null)
            {
                MessageBox.Show("Обновите данные вашего магазина");
            }
            else
            {
                Add_product add_Product = new Add_product();
                add_Product.Show();
                this.Hide();
            }
        }

        private void btn_enter_Click(object sender, RoutedEventArgs e)
        {
            Authorization authorization = new Authorization();
            authorization.Show();
            this.Hide();
            Class1.vender = null; Class1.store = null;
        }
    }
}
