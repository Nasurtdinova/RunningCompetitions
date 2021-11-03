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
    /// Логика взаимодействия для page_admin_commands.xaml
    /// </summary>
    public partial class page_admin_commands : Page
    {
        public static ObservableCollection<ado.Command> infoCommand { get; set; }

        public page_admin_commands()
        {
            InitializeComponent();
            infoCommand = new ObservableCollection<ado.Command>(bd_connection.connection.Command.ToList());
            this.DataContext = this;
        }

        private void btn_create_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new page_admin_create_command());
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var info = (sender as ListView).SelectedItem as ado.Command;
            NavigationService.Navigate(new page_redak_remove_admin(info));
        }
    }
}
