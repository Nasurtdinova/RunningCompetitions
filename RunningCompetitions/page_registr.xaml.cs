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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RunningCompetitions
{
    /// <summary>
    /// Логика взаимодействия для page_registr.xaml
    /// </summary>
    public partial class page_registr : Page
    {
        public page_registr()
        {
            InitializeComponent();
        }

        private void registr_Click(object sender, RoutedEventArgs e)
        {
            var a = new ado.user();
            a.name = name_txt.Text;
            a.login = login_txt.Text;
            a.password = password_txt.Text;
            a.level = cmb_User.Text;
            bd_connection.connection.user.Add(a);
            bd_connection.connection.SaveChanges();
            MessageBox.Show("all");
            NavigationService.Navigate(new page_login());
        }

        private void revers_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void registr_MouseDown(object sender, MouseButtonEventArgs e)
        {
            App.Current.MainWindow.Close();
        }
    }
}
