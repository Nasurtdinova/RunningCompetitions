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
using System.Collections.ObjectModel;

namespace RunningCompetitions
{
    /// <summary>
    /// Логика взаимодействия для page_login.xaml
    /// </summary>
    public partial class page_login : Page
    {
        public static ObservableCollection<ado.user> users { get; set; }
        public static ObservableCollection<ado.Sponsor> sponsor { get; set; }
        public page_login()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            users = new ObservableCollection<ado.user>(bd_connection.connection.user.ToList());
            sponsor = new ObservableCollection<ado.Sponsor>(bd_connection.connection.Sponsor.ToList());
            var z = users.Where(a => a.login == txt_login.Text && a.password==txt_password.Password).FirstOrDefault();
            var k = sponsor.Where(a => a.E_mail == txt_login.Text && a.Password == txt_password.Password).FirstOrDefault();
            if (z != null)
            {
                if (z.level=="Sponsor")
                {
                    NavigationService.Navigate(new page_sponsor(z.name,k.ID_sponsor));
                }
                else
                {
                    NavigationService.Navigate(new page_admin(z.name));
                }             
            }
            else
            {
                MessageBox.Show("Login or password is not correct", "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void registr_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new page_registr());
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new page_main());
        }
    }
}
