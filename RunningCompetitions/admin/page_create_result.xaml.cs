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
    /// Логика взаимодействия для page_create_result.xaml
    /// </summary>
    public partial class page_create_result : Page
    {
        ado.Result_competition a = null;
        public page_create_result()
        {
            InitializeComponent();
            a = new ado.Result_competition();
        }

        private void btn_Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btn_Create_Click(object sender, RoutedEventArgs e)
        {
            a.ID_competition = Convert.ToInt32(IDcompet_txt.Text);
            a.ID_command = Convert.ToInt32(IDcommand_txt.Text);
            a.Rank = Convert.ToInt32(Rank_txt.Text);
            bd_connection.connection.Result_competition.Add(a);
            bd_connection.connection.SaveChanges();
            MessageBox.Show("done");
        }
    }
}
