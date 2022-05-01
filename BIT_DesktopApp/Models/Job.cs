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
        #region Properties
        private int _jobId;
        private string _organisationName; //As Client Name
        private string _contactName;  //Client First Name
        private string _description;
        private string _skillReq;
        private string _priority;
        private int _phone;
        private string _location;
        private decimal _quotedHours;
        private decimal _actualHours;
        private DateTime _requestedCompletion;
        private DateTime _completionDate;
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
                OnPropertyChanged("OrganisationName");
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

        public string Priority
        {
            get { return _priority; }
            set
            {
                _priority = value;
                OnPropertyChanged("Priority");
            }
        }

        public int Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertyChanged("Phone");
            }
        }

        public decimal QuotedHours
        {
            get { return _quotedHours; }
            set
            {
                _quotedHours = value;
                OnPropertyChanged("Quoted Hours");
            }
        }

        public decimal ActualHours
        {
            get { return _actualHours; }
            set
            {
                _actualHours = value;
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

        public DateTime CompletionDate
        {
            get { return _completionDate; }
            set
            {
                _completionDate = value;
                OnPropertyChanged("CompletionDate");
            }
        }

        public string DistanceTravelled
        {
            get { return _distanceTravelled; }
            set
            {
                _distanceTravelled = value;
                OnPropertyChanged("Status");
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
        #endregion Properties

        #region Constructor

        public Job()
        {
            _db = new SQLHelper();
        }

        public Job(DataRow dr)
        {
            _db = new SQLHelper();
            JobId = Convert.ToInt32(dr["Job_Id"].ToString());
            OrganisationName = dr["Oragnisation_Name"].ToString();
            ContactName = dr["Contact_Name"].ToString();
            Description = dr["Description"].ToString();
            SkillReq = dr["Skill_Title"].ToString();
            Priority = dr["Priority"].ToString();
            Phone = Convert.ToInt32(dr["Phone"].ToString());
            Location = dr["Location"].ToString();
            QuotedHours = Convert.ToDecimal(dr["QuotedHours"].ToString());
            ActualHours = Convert.ToDecimal(dr["ActualHours"].ToString());
            RequestedCompletion = Convert.ToDateTime(dr["RequestedCompletionDate"].ToString());
            CompletionDate = Convert.ToDateTime(dr["CompletionDate"].ToString());
            DistanceTravelled = dr["DistanceTravelled"].ToString();
        }

        #endregion Constructor

    }
}
