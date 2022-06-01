using BIT_DesktopApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BIT_DesktopApp.Logger;

namespace BIT_DesktopApp.ViewModels
{
    public class ContractorViewModel : INotifyPropertyChanged
    {

        #region Private Properties

        private ObservableCollection<Contractor> _contractors;
        private ObservableCollection<ContractorSkill> _absentSkills;
        private ContractorSkill _selectedAbsentSkill;
        private Contractor _selectedContractor;
        private SystemSkill _skill;
        private ObservableCollection<ContractorSkill> _contractorSkills;
        private ObservableCollection<SystemSkill> _systemSkills;
        private ContractorSkill _selectedSkill;
        private ContractorSkill _contractorSkill;
        private string _searchText;
        private RelayCommand _searchCommand;
        private RelayCommand _updateCommand;
        private RelayCommand _deleteCommand;
        private RelayCommand _addSkillCommand;
        private RelayCommand _updateSkill;
        private RelayCommand _removeSkill;

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

        #region Add Skill

        public RelayCommand AddSkillCommand
        {
            get
            {
                if (_addSkillCommand == null)
                {
                    _addSkillCommand = new RelayCommand(this.AddSkillMethod, true);
                }

                return _addSkillCommand;
            }
            set { _updateCommand = value; }
        }

        public void AddSkillMethod()
        {
            string message = SkillName.InsertSystemSkill();
            MessageBox.Show(message);
            AbsentContractorSkill allAbsentSkills = new AbsentContractorSkill(SelectedContractor.ContractorId);
            this.AbsentSkills = new ObservableCollection<ContractorSkill>(allAbsentSkills);

            string log = "Skill Added" + DateTime.Now;
            LogHelper.Log(LogHelper.LogTarget.File, log); //Customised File logger
        }
        #endregion Add Skill

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

            string log = "Contractor Removed" + DateTime.Now;
            LogHelper.Log(LogHelper.LogTarget.File, log); //Customised File logger
        }

        #endregion Delete Mthod

        #region Update Skill

        public RelayCommand UpdateSkill
        {
            get
            {
                if (_updateSkill == null)
                {
                    _updateSkill = new RelayCommand(this.UpdateContractorSkill, true);
                }

                return _updateSkill;

            }
            set { _updateSkill = value; }
        }

        public void UpdateContractorSkill()
        {
            string returnValue =  SelectedContractor.updateContractorSkills(SelectedContractor.ContractorId, SelectedAbsentSkill.Skill );
            MessageBox.Show(returnValue);

            string log = "Skill Updated" + DateTime.Now;
            LogHelper.Log(LogHelper.LogTarget.File, log); //Customised File logger

        }

        #endregion Update Skill

        #region Remove Skill


        public RelayCommand RemoveSkill
        {
            get
            {
                if (_removeSkill == null)
                {
                    _removeSkill = new RelayCommand(this.RemoveContractorSkill, true);
                }

                return _removeSkill;

            }
            set { _removeSkill = value; }
        }

        public void RemoveContractorSkill()
        {
            string returnValue = SelectedContractor.RemoveContractorSkill(SelectedContractor.ContractorId, SelectedSkill.Skill );
            MessageBox.Show(returnValue);

            string log = "Skill Removed" + DateTime.Now;
            LogHelper.Log(LogHelper.LogTarget.File, log); //Customised File logger

        }

        #endregion Remove Skill

        #region Update Method

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

            string log = "Contractor Updated" + DateTime.Now;
            LogHelper.Log(LogHelper.LogTarget.File, log); //Customised File logger

        }

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
                AbsentContractorSkill allAbsentSkills = new AbsentContractorSkill(SelectedContractor.ContractorId);
                this.AbsentSkills = new ObservableCollection<ContractorSkill>(allAbsentSkills);
                if (SelectedContractor != null)
                {
                    SelectedSkill = new ContractorSkill(SelectedContractor.SkillTitle);
                }
            }
        }

        #endregion Contractors

        #region System Skills

        public ObservableCollection<SystemSkill> SystemSkill
        {
            get { return _systemSkills; }
            set
            {
                _systemSkills = value;
                OnPropertyChanged("SystemSkill");
            }
        }

        public SystemSkill SkillName
        {
            get { return _skill; }
            set
            {
                _skill = value;
                OnPropertyChanged("SkillName");
            }
        }
        #endregion System Skills

        #region Absent Skill

        public ContractorSkill SelectedAbsentSkill
        {
            get { return _selectedAbsentSkill; }
            set
            {
                _selectedAbsentSkill = value;
                OnPropertyChanged("SelectedAbsentSkill");
            }
        }

        public ObservableCollection<ContractorSkill> AbsentSkills
        {
            get { return _absentSkills; }
            set
            {
                _absentSkills = value;
                OnPropertyChanged("AbsentSkills");
            }
        }


        #endregion Absent Skill

        public ContractorViewModel()
        {
           Contractors allContractors = new Contractors();
            Contractors = new ObservableCollection<Contractor>(allContractors); 
            ContractorSkill = new ContractorSkill();
            SystemSkills newSystemSkills = new SystemSkills();
            SystemSkill = new ObservableCollection<SystemSkill>(newSystemSkills);
            SkillName = new SystemSkill(); // CATCHES THE VALUE FROM THE TEXTBOX

            this.Contractors = GetContractors();

        }

        public virtual ObservableCollection<Contractor> GetContractors()
        {
            Contractors allContractors = new Contractors();
            return new ObservableCollection<Contractor>(allContractors);
        }

    }
}
