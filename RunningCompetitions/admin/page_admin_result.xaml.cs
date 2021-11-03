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
    /// Логика взаимодействия для page_admin_result.xaml
    /// </summary>
    public partial class page_admin_result : Page
    {
        public static ObservableCollection<ado.Result_competition> infoResult { get; set; }

        public page_admin_result()
        {
            InitializeComponent();
            infoResult = new ObservableCollection<ado.Result_competition>(bd_connection.connection.Result_competition.ToList());
            this.DataContext = this;
        }

        private void btn_create_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new page_create_result());
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var info = (sender as ListView).SelectedItem as ado.Result_competition;
            NavigationService.Navigate(new page_redak_result_admin(info));
        }
    }
}
