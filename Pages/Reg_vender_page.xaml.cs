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
    /// Логика взаимодействия для Reg_vender_page.xaml
    /// </summary>
    public partial class Reg_vender_page : Window
    {
        private readonly TatExpEntities _context = new TatExpEntities();
        public Reg_vender_page()
        {
            InitializeComponent();
        }
        public bool a = false;
        public void Reg(string email,string pass,string name,string surname, string patronymic, string adress, string Bik, string telephone, string Kpp, string ogrnip,string ras_schet, string reg_form)
        {
            using (TatExpEntities db = new TatExpEntities())
            {
                Vender vender1 = new Vender();
                Class1.store = null;
                Class1.vender = null;
                //Пользователь
                var user = db.User.FirstOrDefault(u => u.Email == email);

                //Продавец
                vender1 = db.Vender.FirstOrDefault(u => u.Email == email);

                //Владелец ПВЗ
                var pp_owner = db.PP_owner.FirstOrDefault(u => u.Email == email);

                //Сотрудник
                var employe = db.Employee.FirstOrDefault(u => u.Email == email);

                if (user == null && vender1 == null && pp_owner == null && employe == null)
                {
                    Vender vender = new Vender();
                    try
                    {

                        vender.name = name_user.Text;
                        vender.surname = surname_user.Text;
                        vender.patronymic = patronimic_user.Text;
                        vender.Password = pass;
                        vender.Adress = adress;
                        vender.Email = email;
                        vender.БИК = Bik;
                        vender.Telephone = telephone_user.Text;
                        vender.КПП = Kpp;
                        vender.ОГРНИП = ogrnip;
                        vender.Расчетный_счет = ras_schet;
                        vender.Форма_регистрации = reg_form;

                        _context.Vender.Add(vender);
                        _context.SaveChanges();
                        MessageBox.Show("Аккаунт зарегистрирован");
                        this.Hide();
                        a = true;
                        vender = db.Vender.FirstOrDefault(u => u.Email == email);
                        Class1.vender = vender;
                        Store store = new Store();
                        store.id_vender = vender.id;
                        store.Name = "Наименование магазина";
                        store.Description = "Описание магазина";
                        _context.Store.Add(store);
                        _context.SaveChanges();
                        Store store1 = db.Store.FirstOrDefault(u => u.id_vender == store.id_vender);
                        Class1.store = store1;
                        Vender_page vender_Page = new Vender_page();
                        vender_Page.Show();

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Введите все поля!");
                    }

                }
                else
                {
                    MessageBox.Show("Пользователь с таким Email уже существует");
                }
            }
        }
        private void Order_Click(object sender, RoutedEventArgs e)
        {
            string registration_form = "";
            if (reg_form.SelectedItem != null)
            {
                ComboBoxItem selectedItem = (ComboBoxItem)reg_form.SelectedItem;
                registration_form = selectedItem.Content.ToString();
                Reg(email_user.Text, pass_user.Text, name_user.Text, surname_user.Text, patronimic_user.Text, adress.Text, Bik.Text, telephone_user.Text, Kpp.Text, ogrnip.Text, ras_schet.Text, registration_form);
            }
            else
            {
                MessageBox.Show("Введите все поля!");
            }
           
        }
    }
}
