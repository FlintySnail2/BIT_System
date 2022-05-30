﻿using BIT_DesktopApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BIT_DesktopApp.ViewModels
{
    public class ContractorViewModel : INotifyPropertyChanged
    {

        #region Private Properties

        private ObservableCollection<Contractor> _contractors;

        private Contractor _selectedContractor;

        private ObservableCollection<ContractorSkill> _contractorSkills;
        private ContractorSkill _selectedSkill;
        private ContractorSkill _contractorSkill;

        private string _searchText;
        private RelayCommand _searchCommand;
        private RelayCommand _updateCommand;
        private RelayCommand _deleteCommand;
        private RelayCommand _updateSkill;

        public event PropertyChangedEventHandler PropertyChanged;



        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        #endregion Private Properties

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
            Contractors allContractors = new Contractors(SearchText);
            this.Contractors = new ObservableCollection<Contractor>(allContractors);
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

        #region Delete Method

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
            string returnValue = SelectedContractor.RemoveContractor(SelectedContractor.ContractorId);
            MessageBox.Show(returnValue);
        }

        #endregion Delete Mthod

        #region Update Method

        public RelayCommand UpdateSkill
        {
            get
            {
                if (_updateSkill == null)
                {
                    _updateSkill = new RelayCommand(this.UpdateMethod, true);
                }

                return _updateSkill;

            }
            set { _updateSkill = value; }
        }

        public void UpdateContractorSkill()
        {
            string returnValue =  SelectedContractor.UpdateContractor(SelectedContractor.ContractorId);
            MessageBox.Show(returnValue);

        }

        #region Update SKill

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
            string returnValue = SelectedContractor.UpdateContractor(SelectedContractor.ContractorId);
            MessageBox.Show(returnValue);

        }


        #endregion Update Skill



        #endregion Update Method

        #region Contractor Skills

        public ObservableCollection<ContractorSkill> ContractorSkills
        {
            get { return _contractorSkills; }
            set
            {
                _contractorSkills = value;
                OnPropertyChanged("ContractorSkills");
            }
        }

        public ContractorSkill SelectedSkill
        {
            get { return _selectedSkill; }
            set
            {
                _selectedSkill = value;
                OnPropertyChanged("SelectedSkill");

            }
        }

        public ContractorSkill ContractorSkill
        {
            get { return _contractorSkill; }
            set
            {
                _contractorSkill = value;
                OnPropertyChanged("ContractorSkill");
            }
        }

        #endregion contractor Skills

        #region Contractors

        public ObservableCollection<Contractor> Contractors
        {
            get { return _contractors; }
            set
            {
                _contractors = value;
                OnPropertyChanged("Contractors");
            }
        }

        public Contractor SelectedContractor
        {
            get { return _selectedContractor; }
            set
            {
                _selectedContractor = value;
                OnPropertyChanged("SelectedContractor");
                ContractorSkills allSkills = new ContractorSkills(SelectedContractor.ContractorId);
                this.ContractorSkills = new ObservableCollection<ContractorSkill>(allSkills);
            }
        }

        #endregion Contractors





        public ContractorViewModel()
        {
           Contractors allContractors = new Contractors();
            Contractors = new ObservableCollection<Contractor>(allContractors); 
            ContractorSkill = new ContractorSkill();
            //GetContractors();

        }

        //public virtual ObservableCollection<Contractor> GetContractors()
        //{
        //    Contractors allContractors = new Contractors();
        //    return new ObservableCollection<Contractor>(allContractors);
        //}

    }
}
