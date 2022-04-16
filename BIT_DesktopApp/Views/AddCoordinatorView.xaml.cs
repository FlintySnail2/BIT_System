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
    /// Interaction logic for AddCoordinatorView.xaml
    /// </summary>
    public partial class AddCoordinatorView : Page
    {
        public AddCoordinatorView()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you'd like to cancel ",
                     "Cancel? ",
                     MessageBoxButton.YesNo,
                     MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                NavigationService.Navigate(new Uri("Views/CoordinatorView.xaml", UriKind.Relative));
            }
            else
            {
                NavigationService.Navigate(new Uri("Views/AddCoordinatorView.xaml", UriKind.Relative));
            }
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you wish to continue? ",
                     "Coordinator Added",
                     MessageBoxButton.YesNo,
                     MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                NavigationService.Navigate(new Uri("Views/CoordinatorView.xaml", UriKind.Relative));
            }
            else
            {
                NavigationService.Navigate(new Uri("Views/AddCoordinatorView.xaml", UriKind.Relative));
            }
        }
    }
}
