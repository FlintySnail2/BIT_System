using BIT_DesktopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BIT_DesktopApp.ViewModels
{
    public class AddContractorViewModel
    {
        #region Properties
        private Contractor _newContractor;
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



        public Contractor NewContractor
        {
            get { return _newContractor; }
            set { _newContractor = value; }
        }

        #endregion Properties

        #region Constructor
        public AddContractorViewModel()
        {
            NewContractor = new Contractor();
        }

        #endregion

        #region Publc Method

        public void AddMethod()
        {
            //string message = NewContractor.InsertContractor();
            MessageBox.Show("Derp");
        }

        #endregion Public Method
    }
}
