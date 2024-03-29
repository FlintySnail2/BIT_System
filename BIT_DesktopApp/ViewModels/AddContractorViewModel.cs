﻿using BIT_DesktopApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BIT_DesktopApp.Logger;

namespace BIT_DesktopApp.ViewModels
{
    public class AddContractorViewModel : INotifyPropertyChanged
    {

        #region Private Properties

        private Contractor _newContractor;
        private RelayCommand _addCommand;

        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        #endregion Private Properties

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
            MessageBox.Show(message);

            string log = "Contractor Added" + DateTime.Now;
            LogHelper.Log(LogHelper.LogTarget.File, log); //Customised File logger

        }

        #endregion Add Method

        #region Constructor

        public event PropertyChangedEventHandler PropertyChanged;

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

        #endregion Constructor

    }
}
