using BIT_DesktopApp.Logger;
using BIT_DesktopApp.Models;
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

namespace BIT_DesktopApp.Views
{
    /// <summary>
    /// Interaction logic for Logon.xaml
    /// </summary>
    public partial class Logon : Window
    {
        public static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

    public Logon()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Let Login window be draged aaround with the mouse
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }


        }

        private void btnLogon_Click(object sender, RoutedEventArgs e)
        {
            //StreamWriter CustomLog
            string message = "Login Successful " + DateTime.Now;
            LogHelper.Log(LogTarget.File, message); //Customised File logger
            logger.Info("Login Information ");

            //string username = txtUsername.Text;
            //string password = txtPassword.Text;

            //if (LoginHelper.IsCoordinator(username, password))
            //{
            //    var mainwindow = (MainWindow)Window.GetWindow(this);
            //    mainwindow.UpdateButtons("coordinator");

            //    //CLOSE CURRENT LOGIN WINDOW
            //    Window newLoginWindow = new MainWindow();
            //    newLoginWindow.Show();
            //    this.Close();

            //}
            //if (LoginHelper.IsAdmin(username, password))
            //{
            //    var mainwindow = (MainWindow)Window.GetWindow(this);
            //    mainwindow.UpdateButtons("Administrator");

            //    //CLOSE CURRENT LOGIN WINDOW
            //    Window newLoginWindow = new MainWindow();
            //    newLoginWindow.Show();
            //    this.Close();

            //}
            //else
            //{
            //    MessageBox.Show("Invalid Credentials");
            //}
            Window newWindow = new MainWindow();
            newWindow.Show();
            this.Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
