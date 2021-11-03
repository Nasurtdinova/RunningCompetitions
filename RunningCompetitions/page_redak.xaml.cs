using System;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для page_redak.xaml
    /// </summary>
    public partial class page_redak : Page
    {
        public static SponsorCommand a;
        ado.Sponsor_command b = null;
        public page_redak()
        {
            InitializeComponent();
            a = page_Subsponsors.path;
            tb_team.Text = a.contract.ToString();
            amount.Text = a.amount.ToString();
            b = new ado.Sponsor_command();
            this.DataContext = this;
        }

        private void btn_edit_Click(object sender, RoutedEventArgs e)
        {
            var sponsors = new ObservableCollection<ado.Sponsor_command>(bd_connection.connection.Sponsor_command.ToList());
            var sponsor = sponsors.Where(c => c.Team_of_the_contract == a.contract).FirstOrDefault();
            sponsor.Team_of_the_contract = Convert.ToInt32(tb_team.Text);
            sponsor.Amount_per_year = Convert.ToInt32(amount.Text);
            bd_connection.connection.SaveChanges();
            MessageBox.Show("Done");
            NavigationService.GoBack();
        }

        private void btn_remove_Click(object sender, RoutedEventArgs e)
        {
            var sponsors = new ObservableCollection<ado.Sponsor_command>(bd_connection.connection.Sponsor_command.ToList());
            var sponsor = sponsors.Where(c => c.Team_of_the_contract == a.contract).FirstOrDefault();
            sponsor.Team_of_the_contract = Convert.ToInt32(tb_team.Text);
            sponsor.Amount_per_year = Convert.ToInt32(amount.Text);
            if (MessageBox.Show($"Remove {a.NameCommand}?", "question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                bd_connection.connection.Sponsor_command.Remove(sponsor);
                bd_connection.connection.SaveChanges();
                MessageBox.Show("Done");
                NavigationService.GoBack();
            }
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
