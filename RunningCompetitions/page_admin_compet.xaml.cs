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
    /// Логика взаимодействия для page_admin_compet.xaml
    /// </summary>
    public partial class page_admin_compet : Page
    {
        public static ObservableCollection<ado.Competition> infoCompet { get; set; }
        public static ObservableCollection<ado.Venue> infoVenue { get; set; }
        public static ObservableCollection<ado.Type_running> infoType { get; set; }

        public static IEnumerable<CompetVenue> result { get; set; }

        public page_admin_compet()
        {
            InitializeComponent();
            infoCompet = new ObservableCollection<ado.Competition>(bd_connection.connection.Competition.ToList());
            infoVenue = new ObservableCollection<ado.Venue>(bd_connection.connection.Venue.ToList());
            infoType = new ObservableCollection<ado.Type_running>(bd_connection.connection.Type_running.ToList());

            result = from f in infoCompet
                     join t in infoVenue on f.ID_venue equals t.ID_venue
                     join k in infoType on f.ID_type_running equals k.ID_type_runnong
                     select new CompetVenue { Name = f.Name, NameType = k.Name, Date_of_the_event = f.Date_of_the_event.ToString(), venue = t.Name, Number_home = (int)t.Number_home, Street = t.Street };
            this.DataContext = this;
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        public class CompetVenue
        {
            public string Name { get; set; }
            public string NameType { get; set; }
            public string Date_of_the_event { get; set; }
            public string venue { get; set; }
            public string Street { get; set; }
            public int Number_home { get; set; }
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var info = (sender as DataGrid).SelectedItem as ado.Competition;
            if (MessageBox.Show($"Удалить {info.Name}?","question",MessageBoxButton.YesNo,MessageBoxImage.Question)==MessageBoxResult.Yes)
            {
                bd_connection.connection.Competition.Remove(info);
                bd_connection.connection.SaveChanges();
            }
        }
    }
}
