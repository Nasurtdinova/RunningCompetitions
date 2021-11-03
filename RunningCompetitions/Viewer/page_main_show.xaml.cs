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
    /// Логика взаимодействия для page_main_show.xaml
    /// </summary>
    public partial class page_main_show : Page
    {
        public static ObservableCollection<ado.Competition> infoCompet { get; set; }
        public static ObservableCollection<ado.Venue> infoVenue { get; set; }
        public static ObservableCollection<ado.Type_running> infoType { get; set; }
        public static ObservableCollection<ado.Result_competition> infoResult { get; set; }
        public static ObservableCollection<ado.Command> infoCommand { get; set; }

        public static IEnumerable<CompetRes> result { get; set; }
        public static IEnumerable<Command> result2 { get; set; }

        public page_main_show(string type, DateTime date, string nameCompet)
        {
            InitializeComponent();
            infoCompet = new ObservableCollection<ado.Competition>(bd_connection.connection.Competition.ToList());
            infoVenue = new ObservableCollection<ado.Venue>(bd_connection.connection.Venue.ToList());
            infoType = new ObservableCollection<ado.Type_running>(bd_connection.connection.Type_running.ToList());
            infoResult = new ObservableCollection<ado.Result_competition>(bd_connection.connection.Result_competition.ToList());
            infoCommand = new ObservableCollection<ado.Command>(bd_connection.connection.Command.ToList());
            if (type == null && date.ToString() == "01.01.0001 0:00:00" && nameCompet == null)
            {
                result = from f in infoCompet
                         join t in infoResult on f.ID_competition equals t.ID_competition
                         join c in infoType on f.ID_type_running equals c.ID_type_runnong
                         select new CompetRes { idCommand = t.ID_command, NameCompet1 = f.Name, Rank1 = (int)t.Rank };     
            }
            else if (type == null && date.ToString() == "01.01.0001 0:00:00")
            {
                result = from f in infoCompet
                         join t in infoResult on f.ID_competition equals t.ID_competition
                         join c in infoType on f.ID_type_running equals c.ID_type_runnong
                         where nameCompet == f.Name
                         select new CompetRes { idCommand = t.ID_command, NameCompet1 = f.Name, Rank1 = (int)t.Rank };    
            }

            else if (nameCompet == null && date.ToString() == "01.01.0001 0:00:00")
            {
                result = from f in infoCompet
                         join t in infoResult on f.ID_competition equals t.ID_competition
                         join c in infoType on f.ID_type_running equals c.ID_type_runnong
                         where type == c.Name
                         select new CompetRes { idCommand = t.ID_command, NameCompet1 = f.Name, Rank1 = (int)t.Rank };
            }
            else if (type == null && nameCompet == null)
            {
                result = from f in infoCompet
                         join t in infoResult on f.ID_competition equals t.ID_competition
                         join c in infoType on f.ID_type_running equals c.ID_type_runnong
                         where date == f.Date_of_the_event
                         select new CompetRes { idCommand = t.ID_command, NameCompet1 = f.Name, Rank1 = (int)t.Rank };         
            }
            else if (type == null)
            {
                result = from f in infoCompet
                         join t in infoResult on f.ID_competition equals t.ID_competition
                         join c in infoType on f.ID_type_running equals c.ID_type_runnong
                         where nameCompet == f.Name
                         where date == f.Date_of_the_event
                         select new CompetRes { idCommand = t.ID_command, NameCompet1 = f.Name, Rank1 = (int)t.Rank };       
            }
            else if (nameCompet == null)
            {
                result = from f in infoCompet
                         join t in infoResult on f.ID_competition equals t.ID_competition
                         join c in infoType on f.ID_type_running equals c.ID_type_runnong
                         where date == f.Date_of_the_event
                         where type == c.Name
                         select new CompetRes { idCommand = t.ID_command, NameCompet1 = f.Name, Rank1 = (int)t.Rank };   
            }
            else if (date.ToString() == "01.01.0001 0:00:00")
            {
                result = from f in infoCompet
                         join t in infoResult on f.ID_competition equals t.ID_competition
                         join c in infoType on f.ID_type_running equals c.ID_type_runnong
                         where nameCompet == f.Name
                         where type == c.Name
                         select new CompetRes { idCommand = t.ID_command, NameCompet1 = f.Name, Rank1 = (int)t.Rank };       
            }
            else
            {
                result = from f in infoCompet
                         join t in infoResult on f.ID_competition equals t.ID_competition
                         join c in infoType on f.ID_type_running equals c.ID_type_runnong
                         where nameCompet == f.Name
                         where date == f.Date_of_the_event
                         where type == c.Name
                         select new CompetRes { idCommand = t.ID_command, NameCompet1 = f.Name, Rank1 = (int)t.Rank };     
            }
            result2 = from o in infoCommand
                      join t in result on o.ID_command equals t.idCommand
                      select new Command { Name = o.Name, NameCompet = t.NameCompet1, Rank = t.Rank1 };
            this.DataContext = this;
        }
        public class CompetRes
        {
            public int idCompet { get; set; }
            public string NameCompet1 { get; set; }
            public int idCommand { get; set; }
            public int Rank1 { get; set; }
        }
        public class Command
        {           
            public string Name { get; set; }
            public string NameCompet { get; set; }
            public int Rank { get; set; }
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
