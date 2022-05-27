using BIT_DesktopApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Dynamic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using NLog;

namespace BIT_DesktopApp.ViewModels
{
    public class CoordinatorViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Coordinator> _coordinators;
       public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Coordinator> Coordinators
        {
            get { return _coordinators; }
            set
            {
                _coordinators = value;
                OnPropertyChanged("Coordinators");
            }
        }

        private Coordinator _selectedCoordinator;


        private string _searchText;
        private RelayCommand _searchCommand;
        private RelayCommand _updateCommand;
        private RelayCommand _deleteCommand;

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
            string returnValue = SelectedCoordinator.UpdateStaffDetails(SelectedCoordinator.StaffId);
            MessageBox.Show(returnValue);
            //if (returnValue != null)
            //{
            //    MessageBox.Show("She works boys, she actually doesn't shes clapped harder than dads dome");
            //}
            //else
            //{
            //    MessageBox.Show("error");
            //}
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
            string returnValue = SelectedCoordinator.RemoveCoordinator(SelectedCoordinator.StaffId);
            MessageBox.Show(returnValue);
            //if (returnValue > 0)
            //{
            //    MessageBox.Show("Coordinator has been deleted");
            //}
            //else
            //{
            //    MessageBox.Show("error ");
            //}
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





        public Coordinator SelectedCoordinator
        {
            get { return _selectedCoordinator; }
            set
            {
                _selectedCoordinator = value; 
                OnPropertyChanged("SelectedCoordinator");
            }
        }

        //public Coordinator NewCoordinator
        //{
        //    get { return _newCoordinator; }
        //    set
        //    {
        //        _newCoordinator = value; 
        //        OnPropertyChanged("NewCoordinator");
        //    }
        //}

        public CoordinatorViewModel()
        {
            Coordinators allCoordinators = new Coordinators();
            this.Coordinators = new ObservableCollection<Coordinator>(allCoordinators);
        }
    }
}
