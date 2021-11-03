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
    /// Логика взаимодействия для page_sponsor_card.xaml
    /// </summary>
    public partial class page_sponsor_card : Page
    {
        ado.Bank_card a = null;
        string name_txt;
        string login_txt;
        string password_txt;
        public page_sponsor_card(string name_txt, string login_txt, string password_txt)
        {
            InitializeComponent();
            a = new ado.Bank_card();
            this.name_txt = name_txt;
            this.login_txt = login_txt;
            this.password_txt = password_txt;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            a.ID_card = Convert.ToInt32(number_txt.Text);
            a.Last_and_first_name_holder = firstLastname_txt.Text;
            a.CVV2 = Convert.ToInt32(cvv2_txt.Text);
            a.Validity_period = period_txt.Text;
            bd_connection.connection.Bank_card.Add(a);
            bd_connection.connection.SaveChanges();
            MessageBox.Show("done");

            var b = new ado.Sponsor();
            b.ID_card = Convert.ToInt32(number_txt.Text);
            b.Name = name_txt;
            b.E_mail = login_txt; ;
            b.Password = password_txt;
            bd_connection.connection.Sponsor.Add(b);
            bd_connection.connection.SaveChanges();

            NavigationService.Navigate(new page_login());
        }
    }
}
