using BIT_DesktopApp.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIT_DesktopApp.Models
{


    public class Job : INotifyPropertyChanged
    {
        #region Private Properties
        private int _jobId;
        private string _organisationName; 
        private string _contactName;  
        private string _description;
        private string _skillReq;
        private string _priority;
        private string _status;
        private string _phone;
        private string _location;
        private decimal _hoursOnJob;
        private DateTime _requestedCompletion;
        private string _distanceTravelled;  
        private SQLHelper _db;
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        #endregion Private Properties

        #region Public Properties
        public int JobId
        {
            get { return _jobId; }
            set { _jobId = value; }
        }

        public string OrganisationName
        {
            get { return _organisationName; }
            set
            {
                _organisationName = value;
                OnPropertyChanged("Organisation Name");
            }
        }

        public string ContactName
        {
            get { return _contactName; }
            set
            {
                _contactName = value;
                OnPropertyChanged("Contact Name");
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        public string SkillReq
        {
            get { return _skillReq; }
            set
            {
                _skillReq = value;
                OnPropertyChanged("Skill");
            }
        }

        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged("Status");
            }
        }
        public string Priority
        {
            get { return _priority; }
            set
            {
                _priority = value;
                OnPropertyChanged("Priority");
            }
        }

        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertyChanged("Phone");
            }
        }

        public decimal HoursOnJob
        {
            get { return _hoursOnJob; }
            set
            {
                _hoursOnJob = value;
                OnPropertyChanged("Actual Hours");
            }
        }

        public DateTime RequestedCompletion
        {
            get { return _requestedCompletion; }
            set
            {
                _requestedCompletion = value;
                OnPropertyChanged("RequestedCompletion");
            }
        }

        public string DistanceTravelled
        {
            get { return _distanceTravelled; }
            set
            {
                _distanceTravelled = value;
                OnPropertyChanged("DistanceTravlled");
            }
        }

        public string Location
        {
            get { return _location; }
            set
            {
                _location = value;
                OnPropertyChanged("Location");
            }
        }
        #endregion Public Properties

        #region Constructor

        public Job()
        {
            _db = new SQLHelper();
        }

        public Job(DataRow dr)
        {
            //TEMP VARIABLE FOR TOSHORTDATESTTRING
            _db = new SQLHelper();
            JobId = Convert.ToInt32(dr["JobId"].ToString());
            OrganisationName = dr["Organisation Name"].ToString();
            ContactName = dr["Contact Name"].ToString();
            Description = dr["Description"].ToString();
            Status = dr["Status"].ToString();
            RequestedCompletion = Convert.ToDateTime(dr["Requested Completion"].ToString());
            SkillReq = dr["Skill Title"].ToString();
            Priority = dr["Priority"].ToString();
            Phone = dr["Phone"].ToString();
            Location = dr["Location"].ToString();
            HoursOnJob = Convert.ToDecimal(dr["HoursOnJob"].ToString());
            DistanceTravelled = dr["DistanceTravelled"].ToString();
        }

        #endregion Constructor

    }
}
