using BIT_DesktopApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BIT_DesktopApp.ViewModels
{
    public class CoordinatorViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Coordinator> _coordinators;
        private Coordinator _selectedCoordinator;


        private string _searchText;
        private Coordinator _newCoordinator;
        private RelayCommand _searchCommand;
        private RelayCommand _updateCommand;
        private RelayCommand _deleteCommand;
        

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        #region Update Command

        public RelayCommand UpdateCommand
        {
            get
            {
                if (_updateCommand == null)
                {
                    _updateCommand = new RelayCommand(this.UpdateMethod, true);
                }
                return _updateCommand;
            }
            set { _updateCommand = value; }
        }


        public void UpdateMethod()
        {
            int returnValue = SelectedCoordinator.StaffId;
            if (returnValue > 0)
            {
                MessageBox.Show("She works boys");
            }
            else
            {
                MessageBox.Show("error");
            }
        }

        #endregion Update Command

        #region Delete Command

        public RelayCommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                {
                    _deleteCommand = new RelayCommand(this.DeleteMethod, true);

                }
                return _deleteCommand;
            }
            set { _deleteCommand = value; }
        }

        public void DeleteMethod()
        {
            int returnValue = SelectedCoordinator.StaffId;
            if (returnValue > 0)
            {
                MessageBox.Show("Coordinator has been deleted");
            }
            else
            {
                MessageBox.Show("error ");
            }
        }
        #endregion Delete Command

        #region Search Command


        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                OnPropertyChanged("SearchText");
            }
        }

        public RelayCommand SearchCommand
        {
            get
            {
                if (_searchCommand == null)
                {
                    _searchCommand = new RelayCommand(this.SearchMethod, true);

                }
                return _searchCommand;
            }
            set { _searchCommand = value; }
        }

        public void SearchMethod()
        {
            Coordinators allCoordinators = new Coordinators(SearchText);
            this.Coordinators = new ObservableCollection<Coordinator>(allCoordinators);

        }
        #endregion Search Command




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
        public Coordinator NewCoordinator
        {
            get { return _newCoordinator; }
            set
            {
                _newCoordinator = value; 
                OnPropertyChanged("NewCoordinator");
            }
        }

        public CoordinatorViewModel()
        {
            Coordinators allCoordinators = new Coordinators();
            this.Coordinators = new ObservableCollection<Coordinator>(allCoordinators);
        }
    }
}
