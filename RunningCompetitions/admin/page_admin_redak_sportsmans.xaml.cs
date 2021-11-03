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
    /// Логика взаимодействия для page_admin_redak_sportsmans.xaml
    /// </summary>
    public partial class page_admin_redak_sportsmans : Page
    {
        ado.Sportsman a = null;
        public page_admin_redak_sportsmans(ado.Sportsman c)
        {
            InitializeComponent();
            a = new ado.Sportsman();
            a = c;
            Name_txt.Text = a.Name.ToString();
            Surame_txt.Text = a.Surname.ToString();
            YearBirth_txt.Text = a.Year_birth.ToString();
            IDtitle_txt.Text =  a.Id_title.ToString();
            Height_txt.Text = a.Height.ToString();
            Cost_txt.Text=  a.Cost.ToString();
            IDcommand_txt.Text = a.ID_command.ToString();
            Image_txt.Text=  a.image.ToString();
           

            this.DataContext = this;
        }

        private void btn_Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            a.Name = Name_txt.Text;
            a.Surname = Surame_txt.Text;
            a.Year_birth = Convert.ToDateTime(YearBirth_txt.Text);
            a.Id_title = Convert.ToInt32(IDtitle_txt.Text);
            a.Height = Convert.ToInt32(Height_txt.Text);
            a.Cost = Convert.ToInt32(Cost_txt.Text);
            a.ID_command = Convert.ToInt32(IDcommand_txt.Text);
            a.image = Image_txt.Text;
            bd_connection.connection.SaveChanges();
            MessageBox.Show("all");
            NavigationService.GoBack();
        }

        private void btn_Remove_Click(object sender, RoutedEventArgs e)
        {
            a.Name = Name_txt.Text;
            a.Surname = Surame_txt.Text;
            a.Year_birth = Convert.ToDateTime(YearBirth_txt.Text);
            a.Id_title = Convert.ToInt32(IDtitle_txt.Text);
            a.Height = Convert.ToInt32(Height_txt.Text);
            a.Cost = Convert.ToInt32(Cost_txt.Text);
            a.ID_command = Convert.ToInt32(IDcommand_txt.Text);
            a.image = Image_txt.Text;
            if (MessageBox.Show($"Remove {a.Surname} {a.Name}?", "question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                bd_connection.connection.Sportsman.Remove(a);
                bd_connection.connection.SaveChanges();
                MessageBox.Show("Done");
                NavigationService.GoBack();
            }
        }
    }
}
