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
        private RelayCommand _addCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }


        #region Add Command 

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
