using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для page_sponsor_sponsorstvo.xaml
    /// </summary>
    public partial class page_sponsor_sponsorstvo : Page
    {
        public static ObservableCollection<ado.Sponsor_command> infoSponsorCommand { get; set; }

        public static IEnumerable<SponsorCommand> result { get; set; }
        public static ObservableCollection<ado.Command> Command { get; set; }
        public static ObservableCollection<ado.Sponsor> Sponsor { get; set; }
        int i { get; set; }
        int k { get; set; }
        public page_sponsor_sponsorstvo(int id)
        {
            InitializeComponent();
            Command = new ObservableCollection<ado.Command>(bd_connection.connection.Command.ToList());
            Sponsor = new ObservableCollection<ado.Sponsor>(bd_connection.connection.Sponsor.ToList());
            infoSponsorCommand = new ObservableCollection<ado.Sponsor_command>(bd_connection.connection.Sponsor_command.ToList());
            k = id;
            this.DataContext = this;          
        }

        private void command_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = (sender as ComboBox).SelectedItem as ado.Command;
            i = a.ID_command;
        }

        private void btn_Fund_Click(object sender, RoutedEventArgs e)
        {
            var a = new ado.Sponsor_command();
            a.Amount_per_year = Convert.ToInt32(amount_txt.Text);
            a.ID_command = i;
            a.ID_sponsor = k;
            a.Team_of_the_contract = Convert.ToInt32(contract_txt.Text);
            bd_connection.connection.Sponsor_command.Add(a);
            bd_connection.connection.SaveChanges();
            MessageBox.Show("all");
            NavigationService.GoBack();
        }

        public class SponsorCommand
        {
            public int IDSponsor { get; set; }
        }
    }
}
