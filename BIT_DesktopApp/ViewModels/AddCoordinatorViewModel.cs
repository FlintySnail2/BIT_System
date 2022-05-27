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
    public class AddCoordinatorViewModel : INotifyPropertyChanged
    {
        
        private Coordinator _newCoordinator;
        private RelayCommand _confirmCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }


        #region Add Command 

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

        public void AddMethod()
        {
            string message = NewCoordinator.InsertCoordinator();
            MessageBox.Show(message);
        }

        #endregion Add Command

        public Coordinator NewCoordinator
        {
            get { return _newCoordinator; }
            set
            {
                _newCoordinator = value;
                OnPropertyChanged("NewCoordinator");

            }
        }

        public AddCoordinatorViewModel()
        {
            NewCoordinator = new Coordinator();
        }
    }
}
