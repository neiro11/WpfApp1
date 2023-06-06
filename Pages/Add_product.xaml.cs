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
    /// Логика взаимодействия для Add_product.xaml
    /// </summary>
    public partial class Add_product : Window
    {
        public Add_product()
        {
            InitializeComponent();
        }
        public bool r = false;
        private readonly TatExpEntities _context = new TatExpEntities();
        public void Add_tovar(string Name,string Price, string Photo,string Width, string Height,string Desc, string Count, int id, string mass)
        {
            try
            {
                Product product = new Product();
                product.Name = Name;
                product.Price = Convert.ToInt32(Price);
                product.Photo = Photo;
                product.Width = Width;
                product.Height = Height;
                product.Description = Desc;
                product.Count = Convert.ToInt32(Count);
                product.Store_id = id;
                product.Mass = mass;
                _context.Product.Add(product);
                _context.SaveChanges();

                MessageBox.Show("Товар успешно добавлен");
                r = true;
                this.Hide();
                Vender_page vender_Page = new Vender_page();
                vender_Page.Show();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Проверьте данные");
                
            }
        }
        private void Add_tovar_Click(object sender, RoutedEventArgs e)
        {
            Add_tovar(Name.Text, Price.Text, Photo.Text, Width.Text, Height.Text, Desc.Text, Count.Text,Class1.store.id,mass.Text);
        }

    }
}
