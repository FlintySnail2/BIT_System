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
    public class AddContractorViewModel : INotifyPropertyChanged
    {
        
        private Contractor _newContractor;
        private RelayCommand _addCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }


        #region Add Method
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
            string message = NewContractor.InsertContractor();

        }

        #endregion Add Method

        public Contractor NewContractor
        {
            get { return _newContractor; }
            set
            {
                _newContractor = value;
                OnPropertyChanged("NewContractor");
            }
        }


        public AddContractorViewModel()
        {
            NewContractor = new Contractor();
        }
        
    }
}
