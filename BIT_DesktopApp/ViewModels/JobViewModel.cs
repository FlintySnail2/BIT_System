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
    public class JobViewModel
    {
        private ObservableCollection<Job> _jobs;
        private Job _SelectedJob;

        private ObservableCollection<JobStatus> _jobsStatus;
        private JobStatus _selectedJobStatus;
        private JobStatus _jobStatus;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        public ObservableCollection<Job> Jobs
        {
            get { return _jobs; }
            set { _jobs = value; }
        }

        public Job SelectedJob
        {
            get { return _SelectedJob; }
            set { _SelectedJob = value;
                OnPropertyChanged("SelectedJobStatus");
                JobsStatus allStatus = new JobsStatus(SelectedJobStatus.JobId);
                this.JobsStatus = new ObservableCollection<JobStatus>(allStatus);
            }
        }

        public ObservableCollection<JobStatus> JobsStatus
        {
            get { return _jobsStatus; }
            set { _jobsStatus = value;
                OnPropertyChanged("Status");
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
            set { _jobStatus = value;}
        }

        public JobViewModel()
        {
            Jobs allJobs = new Jobs();
            this.Jobs = new ObservableCollection<Job>(allJobs);
            this.JobStatus = new JobStatus();
        }
    }
}
