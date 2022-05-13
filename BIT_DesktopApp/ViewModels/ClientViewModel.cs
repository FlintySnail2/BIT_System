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
    public class ClientViewModel
    {
        private ObservableCollection<Client> _clients;
        private Client _selectedClient;
        public event PropertyChangedEventHandler PropertyChanged;
        private string _searchText;
        private RelayCommand _searchCommand;
        private RelayCommand _updateCommand;

        #region Constructors

        //public RelayCommand UpdateCommand
        //{
        //    get
        //    {
        //        if (_updateCommand == null)
        //        {
        //            _updateCommand = new RelayCommand(this.UpdateMethod, true);
        //        }
        //        return _updateCommand;
        //    }
        //    set { _updateCommand = value; }
        //}

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


        public ObservableCollection<Client> Clients
        {
            get { return _clients; }
            set { _clients = value; }
        }

        public Client SelectedClient
        {
            get { return _selectedClient; }
            set { _selectedClient = value; }
        }

        public ClientViewModel()
        {   
            //COMMENTED OUT AS USING MOQ
            //Clients allClients = new Clients();
            //this.Clients = new ObservableCollection<Client>(allClients);
            GetClients();
        }
        #endregion Constructors

        #region Methods

        public virtual ObservableCollection<Client> GetClients()
        {
            Clients allClients = new Clients();
            return new ObservableCollection<Client>(allClients);
        }

        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
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

        public void SearchMethod()
        {
            Clients allClients = new Clients(SearchText);
            this.Clients = new ObservableCollection<Client>(allClients);
        }

        //public void UpdateMethod()
        //{
        //    int returnValue = SelectedClient.ChangePaymentStatus(SelectedPayment.PaymentStatusId);
        //    if (returnValue > 0)
        //    {
        //        MessageBox.Show("Clients Details Successfully Updated");
        //    }
        //    else
        //    {
        //        MessageBox.Show("Client details could not be updated, please try again");
        //    }
        //    UpdateCompletedBookings();
        //    UpdatePaymentRejectedBookings();
        //}

        #endregion Methods
    }
}
