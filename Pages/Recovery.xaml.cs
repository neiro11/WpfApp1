using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для Window6.xaml
    /// </summary>
    public partial class Recovery : Window
    {
        public bool flag;
        private User _user;
        private int _code;

        public Recovery()
        {
            InitializeComponent();
        }
        public string GetHashString(string s)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(s);
            MD5CryptoServiceProvider CSP = new MD5CryptoServiceProvider();
            byte[] byteHash = CSP.ComputeHash(bytes);
            string hash = "";
            foreach (byte b in byteHash)
            {
                hash += string.Format("{0:x2}", b);
            }
            return hash;
        }

        private void Otpravit_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    Random rnd = new Random();
            //    MailAddress from = new MailAddress("teslavod337@mail.ru", "TatExpress Corp.");
            //    MailAddress to = new MailAddress(textBoxLog.Text);
            //    MailMessage m = new MailMessage(from, to);
            //    m.Subject = "Код подтверждения:";
            //    _code = rnd.Next(100000, 999999);
            //    using (UserContext db = new UserContext())
            //    {
            //        foreach (User user in db.Users)
            //        {
            //            if (textBoxLog.Text == user.Email)
            //            {
            //                _user = user;
            //                m.Body = "<h1>Код: " + _code + "</h1>";
            //                flag = true;
            //            }
            //        }
            //    }
            //    m.IsBodyHtml = true;
            //    SmtpClient smtp = new SmtpClient("smtp.inbox.ru", 587);
            //    smtp.Credentials = new NetworkCredential("teslavod337@mail.ru", "BcA6kfno07CcnQ8TseW7");
            //    smtp.EnableSsl = true;
            //    if (flag)
            //    {
            //        smtp.Send(m);
            //        MessageBox.Show("Письмо отправлено");
            //    }
            //    else
            //    {
            //        flag = false;
            //        MessageBox.Show("Пользователь не найден");
            //    }
            //    textBoxLog.IsReadOnly = true;
            //    textBoxPass.Clear();
            //    textBoxCode.Clear();
            //}
            //catch
            //{
            //    MessageBox.Show("Ошибка");
            //}
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

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            Catalog W1 = new Catalog();
            this.Hide();
            W1.Show();
        }

        private void Voiti_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    if (_code == Convert.ToInt32(textBoxCode.Text))
            //    {
            //        using (UserContext db = new UserContext())
            //        {
            //            foreach (User user in db.Users)
            //            {
            //                if (user.Email == textBoxLog.Text)
            //                {
            //                    if (textBoxPass.Text == "")
            //                    {
            //                        MessageBox.Show("Введите пароль");
            //                        return;
            //                    }
            //                    user.Password = GetHashString(textBoxPass.Text);
            //                }
            //            }
            //            db.SaveChanges();
            //            MessageBox.Show("Успешно");
            //            this.Hide();
            //            MainWindow w1 = new MainWindow();
            //            w1.Show();
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Введите правильный код");
            //    }
            //}
            //catch
            //{
            //    MessageBox.Show("Ошибка");
            //}
            }
        }
    }
