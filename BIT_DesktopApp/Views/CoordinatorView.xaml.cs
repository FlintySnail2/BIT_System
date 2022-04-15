using BIT_DesktopApp.ViewModels;
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
    /// Interaction logic for CoordinatorView.xaml
    /// </summary>
    public partial class CoordinatorView : Page
    {
        static CoordinatorViewModel vm;
        public CoordinatorView()
        {
            InitializeComponent();
            vm = new CoordinatorViewModel();
            this.DataContext = vm;
        }
    }
}
