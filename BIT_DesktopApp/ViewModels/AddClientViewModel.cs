using BIT_DesktopApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BIT_DesktopApp.Logger;

namespace BIT_DesktopApp.ViewModels
{
    public class AddClientViewModel : INotifyPropertyChanged
    {

      
        private Client _newClient;
        private RelayCommand _confirmCommand;
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        public Client NewClient
        {
            get { return _newClient; }
            set
            {
                _newClient = value;
                OnPropertyChanged("NewClient");
            }
        }

        #region Add Method


        public void AddMethod()
        {
            string message = NewClient.InsertClient();
            MessageBox.Show(message);

            string log = "Client Added" + DateTime.Now;
            LogHelper.Log(LogHelper.LogTarget.File, log); //Customised File logger
        }

        public RelayCommand ConfirmCommand
        {
            get
            {
                if (_confirmCommand == null)
                {
                    _confirmCommand = new RelayCommand(this.AddMethod, true);
                }
                return _confirmCommand;
            }
            set { _confirmCommand = value; }
        }

        #endregion Add Method


       


        public AddClientViewModel()
        {
            NewClient = new Client();
        }

    }
}
