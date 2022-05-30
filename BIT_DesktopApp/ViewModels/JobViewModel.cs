﻿using BIT_DesktopApp.Models;
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
    public class JobViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Job> _jobs;
        private Job _SelectedJob;

        private ObservableCollection<JobStatus> _jobsStatus;
        private JobStatus _selectedJobStatus;
        private JobStatus _jobStatus;

        private ObservableCollection<RequestedJob> _requestedJobs;
        private ObservableCollection<RejectedJob> _rejectedJobs;
        private RequestedJob _selectedRequestedJob;

        private ObservableCollection<AvailableContractor> _availableContractors;

        private string _searchText;
        private RelayCommand _searchCommand;
        private RelayCommand _updateCommand;
        private RelayCommand _findCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

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

        #region Assign Job
        #endregion Assign Job

        #region FindContractor

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
            this.AvailableContractors = new ObservableCollection<AvailableContractor>(allAvailableContractors);
        }


        #endregion Find Contractor



        #region Reassign Job
        #endregion Reassign Job

        public ObservableCollection<Job> Jobs
        {
            get { return _jobs; }
            set { _jobs = value;
                OnPropertyChanged("Jobs");
            }
        }

        public Job SelectedJob
        {
            get { return _SelectedJob; }
            set { _SelectedJob = value;
                OnPropertyChanged("SelectedJobStatus");
            }
        }

        public ObservableCollection<AvailableContractor> AvailableContractors
        {
            get { return _availableContractors; }
            set { _availableContractors = value; }
        }

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
        public ObservableCollection<RejectedJob> RejectedJobs
        {
            get { return _rejectedJobs; }
            set
            {
                _rejectedJobs = value;
                OnPropertyChanged("SelectedRejectedJobs");
            }
        }

        //ITEMS SOURCE (FOR REFERENCE)
        public ObservableCollection<JobStatus> JobsStatus
        {
            get { return _jobsStatus; }
            set { _jobsStatus = value;
                OnPropertyChanged("JobsStatus");
            }
        }

        
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
            //SelectedRequestedJob = new RequestedJob();
            //

            //GetJobs();

        }

        //public virtual ObservableCollection<Job> GetJobs()
        //{
        //    Jobs allJobs = new Jobs();
        //    return new ObservableCollection<Job>(allJobs);
        //}
    }
}
