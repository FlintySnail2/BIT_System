using BIT_DesktopApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BIT_DesktopApp.ViewModels
{
    public class RosterViewModel : INotifyPropertyChanged
    {
        #region Private Proerties

        private ObservableCollection<Contractor> _contractors;
        private ObservableCollection<ContractorAvailability> _availableDates;

        private ContractorAvailability _availableDate;
        private Contractor _selectedContractor;
        private ContractorAvailability _selectedContractorAvailability;

        public event PropertyChangedEventHandler PropertyChanged;

        private string _searchText;
        private RelayCommand _searchCommand;
        private RelayCommand _addAvailabilityCommand;
        private RelayCommand _removeAvailabilityCommand;

        public RelayCommand RemoveAvailabilityCommand
        {
            get 
                {
                if (_removeAvailabilityCommand == null)
                {
                    _removeAvailabilityCommand = new RelayCommand(this.RemoveAvailability, true);
                }
                return _removeAvailabilityCommand;
                }
            set {  _removeAvailabilityCommand = value; }
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
            Contractors allContractors = new Contractors(SearchText);
            this.Contractors = new ObservableCollection<Contractor>(allContractors);
        }

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                OnPropertyChanged("SearchText");
            }
        }

        public void RemoveAvailability()
        {
            string message = SelectedAvailableContractor.DeleteAvailability(SelectedContractor.ContractorId);
            MessageBox.Show(message);
        }


        public RelayCommand AddAvailabilityCommand
        {
            get
            {
                if (_addAvailabilityCommand == null)
                {
                    _addAvailabilityCommand = new RelayCommand(this.AddAvailability, true);
                }
                return _addAvailabilityCommand;
            }
            set { _addAvailabilityCommand = value; }
        }

        public void AddAvailability()
        {
            string message = AvailableDate.InsertNewAvailability(SelectedContractor.ContractorId);
            MessageBox.Show(message);

            if (SelectedAvailableContractor != null)
            {
                MessageBox.Show("Triggered");
            }
        }


        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        #endregion Private Properties
         
        public ContractorAvailability AvailableDate
        {
            get { return _availableDate; }
            set { _availableDate = value;
                OnPropertyChanged("AvailableDate");
            }
        }
        public ObservableCollection<ContractorAvailability> AvailableDates
        {
            get { return _availableDates; }
            set { _availableDates = value;
                OnPropertyChanged("AvailableDates");
            }
        }

        public ContractorAvailability SelectedAvailableContractor
        {
            get { return _selectedContractorAvailability; }
            set
            {
                _selectedContractorAvailability = value;
                OnPropertyChanged("SelectedAvailableContractor");
            }
        }

        public ContractorAvailability selectedContractorAvailability
        {
            get { return _selectedContractorAvailability; }
            set { _selectedContractorAvailability = value;
                OnPropertyChanged("SelectedContractorAvailability");
            }
        }
        public ObservableCollection<Contractor> Contractors
        {
            get { return _contractors; }
            set {_contractors = value;
                OnPropertyChanged("Contractors");
            }
        }

        public Contractor SelectedContractor
        {
            get { return _selectedContractor; }
            set { _selectedContractor = value;
                OnPropertyChanged( "SelectedContractor");

                ContractorAvailabilities allDates = new ContractorAvailabilities(SelectedContractor.ContractorId);
                this.AvailableDates = new ObservableCollection<ContractorAvailability>(allDates);
                }
        }

        public RosterViewModel()
        {
            Contractors allContractors = new Contractors();
            this.Contractors = new ObservableCollection<Contractor>(allContractors);
            AvailableDate = new ContractorAvailability();
        }

    }
}
