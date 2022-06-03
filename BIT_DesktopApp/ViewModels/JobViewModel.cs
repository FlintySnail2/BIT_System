using BIT_DesktopApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BIT_DesktopApp.Logger;

namespace BIT_DesktopApp.ViewModels
{
    public class JobViewModel : INotifyPropertyChanged
    {
        #region Private Properties



        private ObservableCollection<Job> _jobs;
        private Job _selectedJob;

        private ObservableCollection<JobStatus> _jobsStatus;
        private JobStatus _selectedJobStatus;
        private JobStatus _jobStatus;

        private AvailableContractor _selectedContractor;
        private ObservableCollection<RequestedJob> _requestedJobs;
        private ObservableCollection<RejectedJob> _rejectedJobs;
        private RequestedJob _selectedRequestedJob;
        private RejectedJob _selectedRejectedJob;

        private ObservableCollection<AvailableContractor> _availableContractors;

        private string _searchText;
        private RelayCommand _searchCommand;
        private RelayCommand _updateCommand;
        private RelayCommand _findCommand;
        private RelayCommand _assignCommand;
        private RelayCommand _reassignCommand;
        private RelayCommand _findComandRejected;

        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        #endregion Private Properties

        public event PropertyChangedEventHandler PropertyChanged;

        

        #region Update Command

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
            string returnValue = SelectedJob.UpdateJobStatus(SelectedJob.JobId);
            MessageBox.Show(returnValue);

            string log = "Job Status Updated" + DateTime.Now;
            LogHelper.Log(LogHelper.LogTarget.File, log); //Customised File logger
        }


        #endregion Update Command

        #region Search Method
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
            Jobs allJobs = new Jobs(SearchText);
            this.Jobs = new ObservableCollection<Job>(allJobs);
        }


        #endregion Search Method

        #region Reassign Job

        public RelayCommand reassignCommand
        {
            get
            {
                if (_reassignCommand == null)
                {
                    _reassignCommand = new RelayCommand(this.ReassignMethod, true);
                }
                return _reassignCommand;
            }
            set { _reassignCommand = value; }
        }

        public void ReassignMethod()
        {
            string returnValue = SelectedRejectedJob.ReassignJob(SelectedRejectedJob.JobId, SelectedContractor.ContractorId);
            MessageBox.Show(returnValue);

            string log = "Job Reassigned" + DateTime.Now;
            LogHelper.Log(LogHelper.LogTarget.File, log); //Customised File logger
        }

        #endregion Reassign Job

        #region Assign Job

        public RelayCommand assignCommand
        {
            get
            {
                if (_assignCommand == null)
                {
                    _assignCommand = new RelayCommand(this.AssignMethod, true);
                }
                return _assignCommand;
            }
            set { _assignCommand = value; }
        }

        public void AssignMethod()
        {
            string returnValue = SelectedRequestedJob.AssignJob(SelectedRequestedJob.JobId, SelectedContractor.ContractorId);
            MessageBox.Show(returnValue);

            string log = "Job Assigned" + DateTime.Now;
            LogHelper.Log(LogHelper.LogTarget.File, log); //Customised File logger
        }

        #endregion Assign Job

        #region Find Contractor

        public RelayCommand FindCommand
        {
            get
            {
                if (_findCommand == null)
                {
                    _findCommand = new RelayCommand(this.FindMethod, true);

                }
                return _findCommand;
            }
            set { _findCommand = value; }
        }



        public void FindMethod()
        { 
            AvailableContractors allAvailableContractors = new AvailableContractors(SelectedRequestedJob.SkillReq, SelectedRequestedJob.RequestedCompletion); 
            if (allAvailableContractors.Count > 0)
            {
                this.AvailableContractors = new ObservableCollection<AvailableContractor>(allAvailableContractors);
                MessageBox.Show("Contractor Found");
            }
            else
            {
                this.AvailableContractors = new ObservableCollection<AvailableContractor>(allAvailableContractors);
                MessageBox.Show("No Contractors Available");
            }


            string log = "Queried Available contractors" + DateTime.Now;
            LogHelper.Log(LogHelper.LogTarget.File, log); //Customised File logger
        }


        public RelayCommand FindCommandRejected
        {
            get
            {
                if (_findComandRejected == null)
                {
                    _findComandRejected = new RelayCommand(this.FindMethodRejected, true);

                }
                return _findComandRejected;
            }
            set { _findComandRejected = value; }
        }



        public void FindMethodRejected()
        {
            AvailableContractors allAvailableContractors = new AvailableContractors(SelectedRejectedJob.SkillReq, SelectedRejectedJob.RequestedCompletion);
            if (allAvailableContractors.Count > 0)
            {
                this.AvailableContractors = new ObservableCollection<AvailableContractor>(allAvailableContractors);
                MessageBox.Show("Contractor Found");
            }
            else
            {
                this.AvailableContractors = new ObservableCollection<AvailableContractor>(allAvailableContractors);
                MessageBox.Show("No Contractors Available");
            }
            
        }


        #endregion Find Contractor


        #region Selected Job

        public Job SelectedJob
        {
            get { return _selectedJob; }
            set
            {
                _selectedJob = value;
                OnPropertyChanged("SelectedJob"); //Changed from SelectedJobStatus
            }
        }

        #endregion Selected Job

        #region Available Contractors

        public ObservableCollection<AvailableContractor> AvailableContractors
        {
            get { return _availableContractors; }
            set
            {
                _availableContractors = value;
                OnPropertyChanged("AvailableContractors");
            }
        }



        #endregion Available Contractors

        #region Requested Jobs

        public ObservableCollection<RequestedJob> RequestedJobs
        {
            get { return _requestedJobs; }
            set
            {
                _requestedJobs = value;
                OnPropertyChanged("RequestedJobs");
            }
        }

        public RequestedJob SelectedRequestedJob
        {
            get { return _selectedRequestedJob; }
            set
            {
                _selectedRequestedJob = value;
                OnPropertyChanged("SelectedRequestedJob");
            }
        }

        #endregion Requested Jobs

        #region Rejected Jobs

        public ObservableCollection<RejectedJob> RejectedJobs
        {
            get { return _rejectedJobs; }
            set
            {
                _rejectedJobs = value;
                OnPropertyChanged("SelectedRejectedJobs");
            }
        }

        public RejectedJob SelectedRejectedJob
        {
            get { return _selectedRejectedJob; }
            set
            {
                _selectedRejectedJob = value;
                OnPropertyChanged("SelectedRejectedJob");
            }
        }
        #endregion Rejected Jobs

        #region Job Status

        public JobStatus SelectedJobStatus
        {
            get { return _selectedJobStatus; }
            set
            {
                _selectedJobStatus = value;
                OnPropertyChanged("SelectedJobStatus");
            }
        }
        public JobStatus JobStatus
        {
            get { return _jobStatus; }
            set
            {
                _jobStatus = value;
                OnPropertyChanged("JobStatus");
            }
        }

        //ITEMS SOURCE (FOR REFERENCE)
        public ObservableCollection<JobStatus> JobsStatus
        {
            get { return _jobsStatus; }
            set
            {
                _jobsStatus = value;
                OnPropertyChanged("JobsStatus");
            }
        }

        #endregion Job Status

        public AvailableContractor SelectedContractor
        {
            get { return _selectedContractor; }
            set
            {
                _selectedContractor = value;
                OnPropertyChanged("SelectedContractor");
            }
        }
        #region Assign Job



        #endregion Assign Job


        public ObservableCollection<Job> Jobs
        {
            get { return _jobs; }
            set
            {
                _jobs = value;
                OnPropertyChanged("Jobs");
            }
        }

        



        public JobViewModel()
        {
            Jobs allJobs = new Jobs();
            this.Jobs = new ObservableCollection<Job>(allJobs);
            JobsStatus allStatus = new JobsStatus();
            this.JobsStatus = new ObservableCollection<JobStatus>(allStatus);
            RequestedJobs allRequestedJobs = new RequestedJobs();
            this.RequestedJobs = new ObservableCollection<RequestedJob>(allRequestedJobs);
            RejectedJobs allRejectedJobs = new RejectedJobs();
            this.RejectedJobs = new ObservableCollection<RejectedJob>(allRejectedJobs);
            this.Jobs = GetJobs();

        }

        public virtual ObservableCollection<Job> GetJobs()
        {
            Jobs allJobs = new Jobs();
            return new ObservableCollection<Job>(allJobs);
        }
    }
}
