using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Authorization : System.Windows.Window
    {
        public Authorization()
        {
            InitializeComponent();

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Korzina W4 = new Korzina();
            W4.Show();
        }
        public bool a = false;
        public bool r = false;
        public void Login(string email, string pass)
        {
            using (TatExpEntities db = new TatExpEntities())
            {
                Class1.store = null;
                Class1.vender = null;
                Class1.auth = null;
                //Пользователь
                var user = db.User.FirstOrDefault(u => u.Email == email && u.Password == pass);
                if (user != null)
                {
                    MessageBox.Show("Вы вошли под учетной записью " + user.Name);
                    Class1.auth = user;
                    this.Hide();
                    MainWindow W7 = new MainWindow();
                    W7.Show();
                    a = true;
                }
                //Продавец
                var vender = db.Vender.FirstOrDefault(u => u.Email == email && u.Password == pass);
                if (vender != null)
                {
                    this.Hide();
                    Class1.vender = vender;
                    Class1.store = db.Store.FirstOrDefault(u => u.id_vender == vender.id);
                    MessageBox.Show("Вы вошли под учетной записью " + vender.name);
                    Vender_page W7 = new Vender_page();
                    W7.Show();
                }
                //Владелец ПВЗ
                var pp_owner = db.PP_owner.FirstOrDefault(u => u.Email == email && u.Password == pass);
                if (pp_owner != null)
                {
                    this.Hide();
                    MessageBox.Show("Вы вошли под учетной записью " + pp_owner.Name);
                    MainWindow W7 = new MainWindow();
                    W7.Show();
                }
                //Сотрудник
                var employe = db.Employee.FirstOrDefault(u => u.Email == email && u.Password == pass);
                if (employe != null)
                {
                    this.Hide();
                    MessageBox.Show("Вы вошли под учетной записью " + employe.Name);
                    Employe_page W7 = new Employe_page();
                    W7.Show();
                }
            }
        }
        public void Registartion(string email, string pass, string pass1) {
            using (TatExpEntities db = new TatExpEntities())
            {
                if (email != "" && pass != "" && pass1 != "")
                {
                    //Пользователь
                    var user = db.User.FirstOrDefault(u => u.Email == email);

                    //Продавец
                    var vender = db.Vender.FirstOrDefault(u => u.Email == email);

                    //Владелец ПВЗ
                    var pp_owner = db.PP_owner.FirstOrDefault(u => u.Email == email);

                    //Сотрудник
                    var employe = db.Employee.FirstOrDefault(u => u.Email == email);
                    if (pass == pass1)
                    {
                        if (user == null && vender == null && pp_owner == null && employe == null)
                        {
                            User user1 = new User();
                            user1.Name = "";
                            user1.Email = email.ToString();
                            user1.Telephone = "";
                            user1.Password = pass;
                            db.User.Add(user1);
                            db.SaveChanges();
                            MessageBox.Show("Успешная регистрация");
                            MainWindow mainWindow = new MainWindow();
                            mainWindow.Show();
                            this.Hide();
                            Class1.auth = user1;
                            r = true;
                        }
                        else
                        {
                            MessageBox.Show("Такой пользователь уже существует");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Введите все данные");
                }

            }
        }
        //Авторизация
        private void Voiti_Click(object sender, RoutedEventArgs e)
        {
            Login(textBoxLog.Text, textBoxPass.Password);
        }
        
        //Регистрация
        private void Voiti_Copy_Click(object sender, RoutedEventArgs e)
        {
            Registartion(textBoxLog1.Text, textBoxPass1.Text, textBoxPass2.Text);
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow MW = new MainWindow();
            this.Hide();
            MW.Show();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            
            this.Hide();
        
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Recovery w6 = new Recovery();
            this.Hide();
            w6.Show(); 
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Reg_vender_page reg_Vender_Page = new Reg_vender_page();
            reg_Vender_Page.Show();
        }
    }
}
