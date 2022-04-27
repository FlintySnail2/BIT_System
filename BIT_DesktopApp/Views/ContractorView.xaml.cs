﻿using BIT_DesktopApp.ViewModels;
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

namespace BIT_DesktopApp.Views
{
    /// <summary>
    /// Interaction logic for ContractorView.xaml
    /// </summary>
    public partial class ContractorView : Page
    {
        //static ContractorViewModel vm;

        public ContractorView()
        {
            InitializeComponent();
            new ContractorViewModel();
            this.DataContext = new ContractorViewModel();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Views/AddContractorView.xaml", UriKind.Relative));
        }

        private void btnAssignJob_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Views/AssignJobView.xaml", UriKind.Relative));
        }

        private void dgSkills_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {

        }
    }
}
