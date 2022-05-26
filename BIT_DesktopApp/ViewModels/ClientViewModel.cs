using BIT_DesktopApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BIT_DesktopApp.ViewModels
{
    public class ClientViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Client> _clients;
        private Client _selectedClient;
        public event PropertyChangedEventHandler PropertyChanged;
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
            int returnValue = SelectedClient.ClientId;
            if (returnValue > 0)
            {
                MessageBox.Show("Client has been upodated");
            }
            else
            {
                MessageBox.Show("Error");
            }

        }


        #endregion Update Command

        #region Search Command

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
            Clients allClients = new Clients(SearchText);
            this.Clients = new ObservableCollection<Client>(allClients);
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
        #endregion Search Command

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
            int returnValue = SelectedClient.ClientId;
            if (returnValue > 0)
            {
                MessageBox.Show("Client has been deleted ");
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
        #endregion Delete Command 

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
            // Clients allClients = new Clients();
            //this.Clients = new ObservableCollection<Client>(allClients);
            GetClients();
        }

        public virtual ObservableCollection<Client> GetClients()
        {
            Clients allClients = new Clients();
            return new ObservableCollection<Client>(allClients);
        }


    }

    




}
