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
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Window
    {
        private readonly TatExpEntities _context = new TatExpEntities();
        public UserPage()
        {
            InitializeComponent();
            
            name_user.Text = Class1.auth.Name;
            surname_user.Text = Class1.auth.Surname;
            photo_user.Text = Class1.auth.Photo;
            telephone_user.Text = Class1.auth.Telephone;
            email_user.Text = Class1.auth.Email;

            int userId = Class1.auth.Id;
            var query = from order in _context.Order
                        join status in _context.Status on order.Status_id equals status.id

                        where order.User_id == userId
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
        public bool r = false;
        public void Save(string Name, string Surname,string Photo, string Telephone, string Email, int id_user)
        {
           
            User user = _context.User.FirstOrDefault(s => s.Id == id_user);
            if (user != null)
            {
                user.Name = Name;
                user.Surname = Surname;
                user.Photo = Photo;
                user.Telephone = Telephone;
                user.Email = Email;
                _context.SaveChanges();
                r = true;
                Class1.auth = user;
                MessageBox.Show("Данные сохранены");
                this.Hide();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }

        }
        private void Save_data_Click(object sender, RoutedEventArgs e)
        {
            int id_user = Class1.auth.Id;
            Save(name_user.Text, surname_user.Text, photo_user.Text, telephone_user.Text, email_user.Text, id_user);
        }

        private void Exit_sys_Click(object sender, RoutedEventArgs e)
        {
            Class1.auth = null;
            this.Hide();
            MainWindow mainWindow   = new MainWindow();
            mainWindow.Show();
        }
    }
}
