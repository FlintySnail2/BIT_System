using BIT_DesktopApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIT_DesktopApp.ViewModels
{
    public class CoordinatorViewModel
    {
        private ObservableCollection<Coordinator> _coordinators;
        private Coordinator _selectedCoordinator;

        public ObservableCollection<Coordinator> Coordinators
        {
            get { return _coordinators; }
            set { _coordinators = value; }
        }

        public Coordinator SelectedCoordinator
        {
            get { return _selectedCoordinator; }
            set { _selectedCoordinator = value; }
        }

        public CoordinatorViewModel()
        {
            Coordinators allCoordinators = new Coordinators();
            this.Coordinators = new ObservableCollection<Coordinator>(allCoordinators);
        }
    }
}
