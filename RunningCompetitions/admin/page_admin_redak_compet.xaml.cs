using System;
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
    /// Логика взаимодействия для page_admin_redak.xaml
    /// </summary>
    public partial class page_admin_redak : Page
    {
        ado.Competition a = null;
        ado.Result_competition b = null;
        int i;
        public page_admin_redak(ado.Competition c)
        {
            InitializeComponent();
            a = new ado.Competition();
            b = new ado.Result_competition();
            a = c;
            i = a.ID_competition;
            IDtype_txt.Text = a.ID_type_running.ToString();
            IDvenue_txt.Text = a.ID_venue.ToString();
            name_txt.Text = a.Name;
            date_txt.Text = a.Date_of_the_event.ToString();

            this.DataContext = this;
        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            a.Name = name_txt.Text;
            a.Date_of_the_event = Convert.ToDateTime(date_txt.Text);
            a.ID_venue = Convert.ToInt32(IDvenue_txt.Text);
            a.ID_type_running = Convert.ToInt32(IDtype_txt.Text);
            bd_connection.connection.SaveChanges();
            MessageBox.Show("all");
            NavigationService.GoBack();
        }

        private void btn_Remove_Click(object sender, RoutedEventArgs e)
        {
            b.ID_competition = i;
            a.Name = name_txt.Text;
            a.Date_of_the_event = Convert.ToDateTime(date_txt.Text);
            a.ID_venue = Convert.ToInt32(IDvenue_txt.Text);
            a.ID_type_running = Convert.ToInt32(IDtype_txt.Text);
            if (MessageBox.Show($"Remove {a.Name}?","question",MessageBoxButton.YesNo,MessageBoxImage.Question)==MessageBoxResult.Yes)
            {
                //bd_connection.connection.Result_competition.Remove(b);
                bd_connection.connection.Competition.Remove(a);
                
                bd_connection.connection.SaveChanges();
                MessageBox.Show("all");
                NavigationService.GoBack();
            }            
        }

        private void btn_Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
