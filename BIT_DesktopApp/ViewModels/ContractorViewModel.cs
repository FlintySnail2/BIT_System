using BIT_DesktopApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BIT_DesktopApp.ViewModels
{
    public class ContractorViewModel
    {
        private ObservableCollection<Contractor> _contractors;
        private Contractor _selectedContractor;

        private ObservableCollection<ContractorSkill> _contractorSkills;
        private ContractorSkill _selectedSkill;
        private ContractorSkill _ContractorSkill;

        private string _searchText;
        private RelayCommand _searchCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

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
            set{ _searchCommand = value;}
        }

        

        #region Contractor Contructors
        public ObservableCollection<Contractor> Contractors
        {
            get { return _contractors; }
            set { _contractors = value; }
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
                //foreach (ContractorSkill CS in allSkills)
                //{
                //    MessageBox.Show(CS.Skill);
                //}
            }
        }

        #endregion Contractor Constructor 

        

        public ObservableCollection<ContractorSkill> ContractorSkills
        {
            get { return _contractorSkills; }
            set
            {
                _contractorSkills = value;
                OnPropertyChanged("Skills");
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
            get { return _ContractorSkill; }
            set { _ContractorSkill = value;}
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

        public void SearchMethod()
        {
            Contractors allContractors = new Contractors(SearchText);
            this.Contractors = new ObservableCollection<Contractor>(allContractors);
        }

        public ContractorViewModel()
        {
            Contractors allContractors = new Contractors();
            this.Contractors = new ObservableCollection<Contractor>(allContractors);
            this.ContractorSkill = new ContractorSkill();
        }

    }
}
