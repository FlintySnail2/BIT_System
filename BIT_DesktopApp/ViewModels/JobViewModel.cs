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
    public class JobViewModel
    {
        private ObservableCollection<Job> _jobs;
        private Job _SelectedJob;

        private ObservableCollection<JobStatus> _jobsStatus;
        private JobStatus _selectedJobStatus;
        private JobStatus _jobStatus;
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
        //************ SEARCH METHOD **********
        public void SearchMethod()
        {
            Jobs allJobs = new Jobs(SearchText);
            this.Jobs = new ObservableCollection<Job>(allJobs);
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
            set { _jobStatus = value;}
        }

        public JobViewModel()
        {
            //Jobs allJobs = new Jobs();
            //this.Jobs = new ObservableCollection<Job>(allJobs);
            JobsStatus allStatus = new JobsStatus();
            this.JobsStatus = new ObservableCollection<JobStatus>(allStatus);
            GetJobs();
            
        }

        public virtual ObservableCollection<Job> GetJobs()
        {
            Jobs allJobs = new Jobs();
            return new ObservableCollection<Job>(allJobs);
        }
    }
}
