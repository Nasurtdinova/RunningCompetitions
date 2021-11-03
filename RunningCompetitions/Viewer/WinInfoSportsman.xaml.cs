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
using System.Collections.ObjectModel;

namespace RunningCompetitions
{
    /// <summary>
    /// Логика взаимодействия для WinInfoSportsman.xaml
    /// </summary>
    public partial class WinInfoSportsman : Page
    {
        public static ObservableCollection<ado.Sportsman> infoSportsman { get; set; }
        public static ObservableCollection<ado.Command> infoCommand { get; set; }

        ado.Sportsman a = null;
        public WinInfoSportsman(ado.Sportsman info)
        {
            InitializeComponent();
            a = new ado.Sportsman();
            a = info;
            this.DataContext = this;
            surnameName_txt.Text = $"{info.Surname} {info.Name}";
            yearbirth_txt.Text = info.Year_birth.ToString();
            cost.Text = info.Cost.ToString();
            height_txt.Text = info.Height.ToString();
            command_name.Text = info.Command.Name;
            title_txt.Text = info.Title.Name;
            imgSport.Source = new BitmapImage(new Uri(info.image,UriKind.RelativeOrAbsolute));
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
