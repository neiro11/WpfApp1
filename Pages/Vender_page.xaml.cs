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
    /// Логика взаимодействия для Vender_page.xaml
    /// </summary>
    public partial class Vender_page : Window
    {
        public Vender_page()
        {
            InitializeComponent();
            using (TatExpEntities db = new TatExpEntities())
            {

                var vender = db.Vender.FirstOrDefault(u => u.id == Class1.vender.id);
                if (vender != null)
                {
                    Name.Text = vender.name;
                    Surname.Text = vender.surname;
                    Patron.Text = vender.patronymic;
                    Adress.Text = vender.Adress;
                    KPP.Text = vender.КПП;
                    BIK.Text = vender.БИК;
                    Telephone.Text = vender.Telephone;
                    ras_chet.Text = vender.Расчетный_счет;
                        Reg_form.Text = vender.Форма_регистрации;
                        OGRNIP.Text = vender.ОГРНИП;
                        Email.Text = vender.Email;
                }
            }

        }

        //Сохранение измененеий
        private void Voiti_Copy_Click(object sender, RoutedEventArgs e)
        {
            using (TatExpEntities db = new TatExpEntities())
            {

                var vender = db.Vender.FirstOrDefault(u => u.id == Class1.vender.id);
                if (Name.Text != "")
                {
                    vender.name = Name.Text;
                }
                if (Surname.Text != "")
                {
                    vender.surname = Surname.Text;
                }
                if (Patron.Text != "") { vender.patronymic = Patron.Text; }
                if (Adress.Text != "")
                {
                    vender.Adress = Adress.Text;
                }
                if (Email.Text != "") {
                    vender.Email = Email.Text;
                }
                if (BIK.Text != "")
                {
                    vender.БИК = BIK.Text;
                }
                if (Telephone.Text != "")
                {
                    vender.Telephone = Telephone.Text;
                }
                if (OGRNIP.Text != "") {
                    vender.ОГРНИП = OGRNIP.Text;
                }
                if (ras_chet.Text != "")
                {
                    vender.Расчетный_счет = ras_chet.Text;
                }
                if (Reg_form.Text != "")
                {
                    vender.Форма_регистрации = Reg_form.Text;
                }
                db.SaveChanges();
                MessageBox.Show("Данные успешно изменены");
            }
        }

 
        //окно магазина
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (TatExpEntities db = new TatExpEntities())
            {

                Store store = db.Store.FirstOrDefault(u => u.id_vender == Class1.vender.id);
                Class1.store = store;
                
            }
            Store_page_settings store_Page_Settings = new Store_page_settings();
            store_Page_Settings.Show();
            this.Hide();
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
