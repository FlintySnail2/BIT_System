using BIT_DesktopApp.Logger;
using BIT_DesktopApp.Views;
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
using static BIT_DesktopApp.Logger.LogHelper;

namespace BIT_DesktopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();


        public MainWindow()
        {
            InitializeComponent();
            contentFrame.Navigate(new JobView());

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Let Login window be draged aaround with the mouse
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }

        }

        //private void btnLogin_Click(object sender, RoutedEventArgs e)
        //{
        //   Window newWindow = new MainWindow();
        //   newWindow.Show();
        //    this.Close();
        //}

        private void btnDashboard_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(new JobView());
        }

        private void btnCoordinator_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(new CoordinatorView());
        }

        private void btnContract_CLick(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(new ContractorView());


        }

        private void btnClients_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(new ClientView());

        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            //StreamWriter CustomLog
            string message = "Logout Successful " + DateTime.Now;
            LogHelper.Log(LogTarget.File, message); //Customised File logger
            logger.Info("Logout Information ");
            Window newWindow = new Logon();
            newWindow.Show();
            this.Close();
        }
    }
}
