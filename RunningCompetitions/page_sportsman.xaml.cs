﻿using System;
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
    /// Логика взаимодействия для page_sportsman.xaml
    /// </summary>
    public partial class page_sportsman : Page
    {
        public static ObservableCollection<ado.Sportsman> infoSportsman { get; set; }
        public page_sportsman()
        {
            InitializeComponent();
            infoSportsman = new ObservableCollection<ado.Sportsman>(bd_connection.connection.Sportsman.ToList());
            this.DataContext = this;
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = (sender as ListView).SelectedItem as ado.Sportsman;
            NavigationService.Navigate(new WinInfoSportsman(a));      
        }
    }
}
