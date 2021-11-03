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
    /// Логика взаимодействия для page_create_compet.xaml
    /// </summary>
    public partial class page_create_compet : Page
    {
        ado.Competition a = null;
        public page_create_compet()
        {
            InitializeComponent();
            a = new ado.Competition();
        }

        private void btn_Create_Click(object sender, RoutedEventArgs e)
        {
            a.Name = name_txt.Text;
            a.Date_of_the_event = Convert.ToDateTime(date_txt.Text);
            a.ID_venue = Convert.ToInt32(IDvenue_txt.Text);
            a.ID_type_running = Convert.ToInt32(IDtype_txt.Text);
            bd_connection.connection.Competition.Add(a);
            bd_connection.connection.SaveChanges();
            MessageBox.Show("done");
        }

        private void btn_Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
