using BIT_DesktopApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIT_DesktopApp.ViewModels
{
    public class ContractorViewModel
    {
        private ObservableCollection<Contractor> _contractors;
        private Contractor _selectedContractor;

        private ObservableCollection<ContractorSkill> _contractorSkills;
        private ContractorSkill _selectedSkill;
        private ContractorSkill _ContractorSkill; 

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
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
            set { _selectedContractor = value;
                OnPropertyChanged("SelectedContractor");
                ContractorSkills allSkills = new ContractorSkills(SelectedContractor.ContractorID);
                this.ContractorSkills = new ObservableCollection<ContractorSkill>(allSkills);
            }
        }

        #endregion Contractor Constructor 

        

        public ObservableCollection<ContractorSkill> ContractorSkills
        {
            get { return _contractorSkills; }
            set { _contractorSkills = value;
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

        public ContractorViewModel()
        {
            Contractors allContractors = new Contractors();
            this.Contractors = new ObservableCollection<Contractor>(allContractors);
            this.ContractorSkill = new ContractorSkill();
        }

    }
}
