using BIT_DesktopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BIT_DesktopApp.ViewModels
{
    internal class AddCoordinatorViewModel
    {
        #region Properties
        private Coordinator _newCoordinator;
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



        public Coordinator NewCoordinator
        {
            get { return _newCoordinator; }
            set { _newCoordinator = value; }
        }

        #endregion Properties

        #region Constructor
        public AddCoordinatorViewModel()
        {
            NewCoordinator = new Coordinator();
        }

        #endregion

        #region Publc Method

        public void AddMethod()
        {
            //string message = NewClient.InsertClient();
            MessageBox.Show("Derp");
        }

        #endregion Public Method
    }
}
