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
    /// Логика взаимодействия для page_admin.xaml
    /// </summary>
    public partial class page_admin : Page
    {
        public static ObservableCollection<ado.Competition> infoCompet { get; set; }
        public page_admin(string name)
        {
            InitializeComponent();
            tbZdr.Text = $"Вы зашли как админ {name}";
            infoCompet = new ObservableCollection<ado.Competition>(bd_connection.connection.Competition.ToList());
        }

        private void btn_show_Click(object sender, RoutedEventArgs e)
        {

        }

        private void competition_click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new page_admin_compet());
        }

        private void sportsman_click(object sender, RoutedEventArgs e)
        {

        }

        private void date_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void type_run_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void city_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void command_click(object sender, RoutedEventArgs e)
        {

        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new page_main());
        }
    }
}
