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
    /// Логика взаимодействия для StorePage.xaml
    /// </summary>
    public partial class StorePage : Window
    {
        private readonly TatExpEntities _context = new TatExpEntities();
        public StorePage()
        {
            InitializeComponent();
            StoreName.Text = Class1.store.Name;
            Descp.Text = Class1.store.Description;
            string imagePath = Class1.store.Logo;
            BitmapImage image = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
            MyImage.Source = image;
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
    }

}
