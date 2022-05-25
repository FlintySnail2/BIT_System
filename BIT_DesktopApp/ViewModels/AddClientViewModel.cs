using BIT_DesktopApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BIT_DesktopApp.ViewModels
{
    public class AddClientViewModel 
    {

      
        private Client _newClient;
        private RelayCommand _addCommand;

        public RelayCommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new RelayCommand(this.AddMethod, true);
                }
                return _addCommand;
            }
            set { _addCommand = value; }
        }

    



        public void AddMethod()
        {
            //string message = NewClient.InsertClient();
            MessageBox.Show("Derp");
        }

        public Client NewClient
        {
            get { return _newClient; }
            set { _newClient = value; }
        }


        public AddClientViewModel()
        {
            NewClient = new Client();
        }

    }
}
