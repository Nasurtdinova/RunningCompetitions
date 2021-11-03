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
    /// Логика взаимодействия для page_command.xaml
    /// </summary>
    public partial class page_command : Page
    {
        public static ObservableCollection<ado.Command> command { get; set; }
        public static ObservableCollection<ado.City> city { get; set; }

        public static IEnumerable<CommandCity> result { get; set; }
        public page_command()
        {
            InitializeComponent();
            command = new ObservableCollection<ado.Command>(bd_connection.connection.Command.ToList());
            city = new ObservableCollection<ado.City>(bd_connection.connection.City.ToList());

            result = from f in command
                     join t in city on f.ID_city equals t.ID_city
                     
                     select new CommandCity {NameCommand=f.Name,NameCity=t.Name,Image=f.image};
            this.DataContext = this;
        }

        public class CommandCity
        {
            public string NameCommand { get; set; }
            public string NameCity { get; set; }
            public string Image { get; set; }
        }

            private void btn_Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
