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
        public page_login()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            users = new ObservableCollection<ado.user>(bd_connection.connection.user.ToList());
            var z = users.Where(a => a.login == txt_login.Text && a.password==txt_password.Password).FirstOrDefault();
            if (z != null)
            {
                if (z.level=="Спонсор")
                {
                    NavigationService.Navigate(new page_sponsor(z.name));
                }
                else
                {
                    NavigationService.Navigate(new page_admin(z.name));
                }             
            }
            else
            {
                MessageBox.Show("логин или пароль не верные", "error", MessageBoxButton.OK, MessageBoxImage.Error);
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
