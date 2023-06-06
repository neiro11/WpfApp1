using System.Linq;
using System.Windows;
using System.Windows.Controls;
namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class UserControl3 : UserControl
    {
        public UserControl3()
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Class1.vender = null;
            Pages.Authorization authorization = new Pages.Authorization();
            authorization.Show();
            Application.Current.Windows.OfType<System.Windows.Window>().Except(new[] { authorization }).ToList().ForEach(w => w.Close());

        }
    }
}
