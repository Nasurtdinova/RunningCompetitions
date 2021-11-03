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
    /// Логика взаимодействия для page_redak_remove_admin.xaml
    /// </summary>
    public partial class page_redak_remove_admin : Page
    {
        ado.Command a = null;
        public page_redak_remove_admin(ado.Command c)
        {
            InitializeComponent();
            a = new ado.Command();
            a = c;
            IDcity_txt.Text = a.ID_city.ToString();
            name_txt.Text = a.Name.ToString();
            Image_txt.Text = a.image;

            this.DataContext = this;
        }

        private void btn_Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            a.ID_city = Convert.ToInt32(IDcity_txt.Text);
            a.Name = name_txt.Text;
            a.image = Image_txt.Text;
            bd_connection.connection.SaveChanges();
            MessageBox.Show("Done");
            NavigationService.GoBack();
        }

        private void btn_Remove_Click(object sender, RoutedEventArgs e)
        {
            a.ID_city = Convert.ToInt32(IDcity_txt.Text);
            a.Name = name_txt.Text;
            a.image = Image_txt.Text;
            bd_connection.connection.SaveChanges();
            if (MessageBox.Show($"Remove {a.Name}?", "question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                bd_connection.connection.Command.Remove(a);
                bd_connection.connection.SaveChanges();
                MessageBox.Show("Done");
                NavigationService.GoBack();
            }
        }
    }
}
