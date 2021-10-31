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
        public WinInfoSportsman(ado.Sportsman info)
        {
            InitializeComponent();
            tb.Text = $"{info.Surname}"+ info.Name + Environment.NewLine + $"Year birth: {Convert.ToDateTime(info.Year_birth).ToString("dd.MM.yyyy")}" + Environment.NewLine 
            + $"Height: {info.Height}" + Environment.NewLine + $"Cost: {info.Cost}";
            imgSport.Source = new BitmapImage(new Uri(info.image,UriKind.RelativeOrAbsolute));
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
