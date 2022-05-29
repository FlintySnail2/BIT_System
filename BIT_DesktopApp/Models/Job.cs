using BIT_DesktopApp.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIT_DesktopApp.Models
{


    public class Job : INotifyPropertyChanged, IDataErrorInfo
    {
        #region Private Properties
        private int _jobId;
        private string _organisationName; 
        private string _contactName;
        private string _contractorName;
        private string _description;
        private string _skillReq;
        private string _priority;
        private string _status;
        private string _phone;
        private string _street;
        private string _suburb;
        private string _state;
        private string _zip;
        private string _location;
        private decimal _hoursOnJob;
        private DateTime _requestedStartDate;
        private DateTime _requestedCompletion;
        private string _distanceTravelled;  
        private SQLHelper _db;
        public event PropertyChangedEventHandler PropertyChanged;
        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();
        public string Error { get { return null; } }
        public string this[string propertyName]
        {
            get
            {
                string result = null;
                switch (propertyName)
                {
                    case "OrganisationName":
                        if (string.IsNullOrEmpty(OrganisationName))
                        {
                            result = "Field cannot be empty";
                        }
                        break;
                    case ("SkillReq"):
                        if (string.IsNullOrEmpty(SkillReq))
                        {
                            result = "Field cannot be empty";
                        }
                        break;
                    case "Priority":
                        if (string.IsNullOrEmpty(Priority))
                        {
                            result = "Field cannot be empty";
                        }
                        break;
                    case "RequestedCompletion":
                        if (RequestedCompletion < DateTime.Today)
                        {
                            result = "Field cannot be empty";
                        }
                        break;
                    case "Description":
                        if (string.IsNullOrEmpty(Description))
                        {
                            result = "Field cannot be empty";
                        }
                        break;
                    case "Street":
                        if (string.IsNullOrEmpty(Street))
                        {
                            result = "Field cannot be empty";
                        }
                        break;
                    case "Suburb":
                        if (string.IsNullOrEmpty(Suburb))
                        {
                            result = "Field cannot be empty";
                        }
                        break;
                    case "State":
                        if (string.IsNullOrEmpty(State))
                        {
                            result = "Field cannot be empty";
                        }
                        break;
                    case "Zip":
                        if (string.IsNullOrEmpty(Zip))
                        {
                            result = "Field cannot be empty";
                        }
                        break;
                }
                if (result != null && !ErrorCollection.ContainsKey(propertyName))
                {
                    ErrorCollection.Add(propertyName, result);
                }
                OnPropertyChanged("ErrorCollection");
                return result;

            }
        }

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

        public string ContractorName
        {
            get { return _contractorName; }
            set
            {
                _contractorName = value;
                OnPropertyChanged("ContractorName");
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

        public DateTime RequestedStartDate
        {
            get { return _requestedStartDate; }
            set {
                _requestedStartDate = value;
                OnPropertyChanged("RequestedStartDate");
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

        public string CompletionFormat => RequestedCompletion.ToShortDateString();

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

        public string Street
        {
            get { return _street; }
            set
            {
                _street = value;
                OnPropertyChanged("Street");
            }
        }

        public string Suburb
        {
            get { return _suburb; }
            set
            {
                _suburb = value;
                OnPropertyChanged("Suburb");
            }
        }
        public string State
        {
            get { return _state; }
            set
            {
                _state = value;
                OnPropertyChanged("State");
            }
        }

        public string Zip
        {
            get { return _zip; }
            set
            {
                _zip = value;
                OnPropertyChanged("Zip");
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
            _db = new SQLHelper();
            JobId = Convert.ToInt32(dr["JobId"].ToString());
            OrganisationName = dr["Organisation Name"].ToString();
            ContactName = dr["Contact Name"].ToString();
            ContractorName = dr["ContractorName"].ToString();
            Description = dr["Description"].ToString();
            Status = dr["Status"].ToString();
            RequestedCompletion = Convert.ToDateTime(dr["Requested Completion"].ToString());
            SkillReq = dr["Skill Required"].ToString();
            Priority = dr["Priority"].ToString();
            Phone = dr["Phone"].ToString();
            Location = dr["Location"].ToString();
            HoursOnJob = Convert.ToDecimal(dr["Hours On Job"].ToString());
            DistanceTravelled = dr["Distance Travelled"].ToString();
        }

        #endregion Constructor

        #region Public Methods

        public string UpdateJobStatus(int jobId)
        {
            string updateSql = "UPDATE" +
                               "    Job" +
                               "    SET" +
                               "    Status = @JobStatus" +
                               " WHERE " +
                               "    JobId = @JobId";
            SqlParameter[] objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@JobStatus", DbType.String);
            objParams[0].Value = Status;
            objParams[1] = new SqlParameter("JobId", DbType.Int32);
            objParams[1].Value = JobId;
            int rowsAffected = _db.ExecuteNonQuery(updateSql, objParams);
            if (rowsAffected >= 1)
            {
                return "Job Status Successfully Updated";
            }

            return "Unable to update Job Status, please try again later";

        }

        //public string InsertNewJob(int jobId)
        //{
        //    string sql =
        //}

#endregion Public Methods

    }
}
