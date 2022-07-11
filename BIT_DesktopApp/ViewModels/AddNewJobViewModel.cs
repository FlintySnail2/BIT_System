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
    public class AddNewJobViewModel : INotifyPropertyChanged
    {

        #region Private Properties

        private Job _newJob;
        private Client _clientName;
        private Client _selectedClient;
        private ObservableCollection<Client> _clientList;
        private Region _regionName;
        private Region _selectedRegion;
        private ObservableCollection<Region> _regionList;
        private SystemSkill _skill;
        private SystemSkill _selectedSystemSkill;
        private ObservableCollection<SystemSkill> _systemSkills;
        private RelayCommand _confirmCommand;

        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        #endregion Private Properties

        public event PropertyChangedEventHandler PropertyChanged;

        #region Priority




        #endregion Priority

        #region Client

        public Client ClientName
        {
            get { return _clientName; }
            set
            {
                _clientName = value;
                OnPropertyChanged("ClientName");
            }
        }

        public ObservableCollection<Client> ClientList
{
            get { return _clientList; }
            set
            {
                _clientList = value;
                OnPropertyChanged("SelectedClients");
            }
        }

        public Client SelectedClient
        {
            get { return _selectedClient; }
            set
            {
                _selectedClient = value;
                OnPropertyChanged("SelectedClient");
                SelectedRegion = new Region()
                {
                    RegionName = SelectedClient.Region
                };
            }
        }
        #endregion Client

        #region Region

        public ObservableCollection<Region> RegionList
        {
            get { return _regionList; }
            set
            {
                _regionList = value;
                OnPropertyChanged("RegionList");
            }
        }

        public Region SelectedRegion
        {
            get { return _selectedRegion; }
            set
            {
                _selectedRegion = value;
                OnPropertyChanged("SelectedRegion");
            }
        }

        public Region RegionName
        {
            get { return _regionName; }
            set
            {
                _regionName = value;
                OnPropertyChanged("RegionName");
            }
        }

        #endregion Region

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

        public SystemSkill SelectedSystemSkill
        {
            get { return _selectedSystemSkill; }
            set
            {
                _selectedSystemSkill = value;
                OnPropertyChanged("SelectedSystemSkill");
            }
        }
        #endregion System Skills

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
            NewJob.OrganisationName = SelectedClient.OrganisationName.ToString();
            NewJob.SkillReq = SelectedSystemSkill.SkillName.ToString();
            NewJob.Location = SelectedRegion.RegionName.ToString();
            string message = NewJob.InsertNewJob();
            MessageBox.Show(message);
        }

        #endregion Add Command

        #region Constructor

        public Job NewJob
        {
            get { return _newJob; }
            set
            {
                _newJob = value;
                OnPropertyChanged("NewJob");
            }
        }

        public AddNewJobViewModel()
        {
            NewJob = new Job();
            SystemSkills newSystemSkills = new SystemSkills();
            SystemSkill = new ObservableCollection<SystemSkill>(newSystemSkills);
            Clients newClients = new Clients();
            ClientList = new ObservableCollection<Client>(newClients);
            Regions newRegion = new Regions();
            RegionList = new ObservableCollection<Region>(newRegion);

        }

        #endregion Constructor
    }
}

