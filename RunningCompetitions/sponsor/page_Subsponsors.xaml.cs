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
    /// Логика взаимодействия для page_Subsponsors.xaml
    /// </summary>
    public partial class page_Subsponsors : Page
    {
        public static ObservableCollection<ado.Sponsor_command> sponCom { get; set; }
        public static ObservableCollection<ado.Sponsor> sponsor { get; set; }
        public static ObservableCollection<ado.Command> command { get; set; }
        public static SponsorCommand path;
        public static IEnumerable<SponsorCommand> result { get; set; }
        public page_Subsponsors(int id, string name)
        {
            InitializeComponent();
            sponCom = new ObservableCollection<ado.Sponsor_command>(bd_connection.connection.Sponsor_command.ToList());
            sponsor = new ObservableCollection<ado.Sponsor>(bd_connection.connection.Sponsor.ToList());
            command = new ObservableCollection<ado.Command>(bd_connection.connection.Command.ToList());
            result = from f in sponCom
                     join t in sponsor on f.ID_sponsor equals t.ID_sponsor
                     join k in command on f.ID_command equals k.ID_command
                     where id == f.ID_sponsor
                     select new SponsorCommand {NameCommand = k.Name, contract = (int)f.Team_of_the_contract, amount=(int)f.Amount_per_year };
            this.DataContext = this;
        }

        private void btn_Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            path = (sender as ListView).SelectedItem as SponsorCommand;
            NavigationService.Navigate(new page_redak());
        }
    }
}
