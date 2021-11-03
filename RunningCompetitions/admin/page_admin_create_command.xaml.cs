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
    /// Логика взаимодействия для page_admin_create_command.xaml
    /// </summary>
    public partial class page_admin_create_command : Page
    {
        ado.Command a = null;
        public page_admin_create_command()
        {
            InitializeComponent();
            a = new ado.Command();
        }

        private void btn_Create_Click(object sender, RoutedEventArgs e)
        {
            a.Name = name_txt.Text;
            a.ID_city = Convert.ToInt32(IDcity_txt.Text);
            a.image = Image_txt.Text;
            bd_connection.connection.Command.Add(a);
            bd_connection.connection.SaveChanges();
            MessageBox.Show("done");
        }

        private void btn_Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
