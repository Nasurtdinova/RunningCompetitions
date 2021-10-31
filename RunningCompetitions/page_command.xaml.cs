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
        public page_command()
        {
            InitializeComponent();
            command = new ObservableCollection<ado.Command>(bd_connection.connection.Command.ToList());
            this.DataContext = this;
        }

        private void btn_Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
