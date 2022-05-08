using BIT_DesktopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BIT_DesktopApp.ViewModels
{
    public class AddNewJobViewModel
    {
        #region Properties
        private Job _newJob;
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



        public Job NewJob
        {
            get { return _newJob; }
            set { _newJob = value; }
        }

        #endregion Properties

        #region Constructor
        public AddNewJobViewModel()
        {
            NewJob = new Job();
        }
            #endregion

            #region Publc Method

            public void AddMethod()
        {
            //string message = NewJob.InsertClient();
            MessageBox.Show("Derp");
        }

        #endregion Public Method
    }
}

