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
    /// Логика взаимодействия для page_admin.xaml
    /// </summary>
    public partial class page_admin : Page
    {
        public static ObservableCollection<ado.Type_running> type { get; set; }
        public static ObservableCollection<ado.Competition> competi { get; set; }
        int i { get; set; }
        string Type;
        DateTime Date;
        string nameCompet;
        string nameSpon;
        public page_admin(string name)
        {
            InitializeComponent();
            tbZdr1.Text = $"You logged as admin, {name}!";
            nameSpon = name;
            type = new ObservableCollection<ado.Type_running>(bd_connection.connection.Type_running.ToList());
            competi = new ObservableCollection<ado.Competition>(bd_connection.connection.Competition.ToList());
            this.DataContext = this;
        }

        private void btn_show_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new page_main_show(Type, Date, nameCompet));
        }

        private void competition_click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new page_admin_compet());
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new page_main());
        }

        private void resCompet_click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new page_admin_result());
        }

        private void date_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = (sender as ComboBox).SelectedItem as ado.Competition;
            i = a.ID_competition;
            Date = Convert.ToDateTime(a.Date_of_the_event);
        }

        private void compet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = (sender as ComboBox).SelectedItem as ado.Competition;
            i = a.ID_competition;
            nameCompet = a.Name;
        }

        private void type_run_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = (sender as ComboBox).SelectedItem as ado.Type_running;
            i = a.ID_type_runnong;
            Type = a.Name;
        }

        private void sportsman_click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new page_admin_sportsmans());
        }

        private void command_click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new page_admin_commands());
        }
    }
}