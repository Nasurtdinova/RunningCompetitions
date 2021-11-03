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
    /// Логика взаимодействия для page_admin_create_sportsman.xaml
    /// </summary>
    public partial class page_admin_create_sportsman : Page
    {
        ado.Sportsman a = null;
        public page_admin_create_sportsman()
        {
            InitializeComponent();
            a = new ado.Sportsman();
        }

        private void btn_Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btn_Create_Click(object sender, RoutedEventArgs e)
        {
            a.Name = Name_txt.Text;
            a.Surname = Surname_txt.Text;
            a.Year_birth = Convert.ToDateTime(YearBirth_txt.Text);
            a.Id_title = Convert.ToInt32(IDtitle_txt.Text);
            a.Height = Convert.ToInt32(Height_txt.Text);
            a.Cost = Convert.ToInt32(Cost_txt.Text);
            a.ID_command = Convert.ToInt32(IDcommand_txt.Text);
            a.image = Image_txt.Text;
            bd_connection.connection.Sportsman.Add(a);
            bd_connection.connection.SaveChanges();
            MessageBox.Show("Done");
        }
    }
}
