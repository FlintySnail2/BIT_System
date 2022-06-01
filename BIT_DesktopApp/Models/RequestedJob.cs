using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BIT_DesktopApp.DAL;

namespace BIT_DesktopApp.Models
{
    public class RequestedJob: INotifyPropertyChanged
    {
        #region Private Properties

        private int _jobId;
        private int _contractorId;
        private string _OrganisationName;
        private string _contactName;
        private string _skillReq;
        private string _description;
        private string _status;
        private DateTime _requestedCompletion;
        private string _contractorRating;
        public SQLHelper _db;
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
            set
            {
                _jobId = value; 
                OnPropertyChanged("JobId");
            }

        }

        public int ContractorId
        {
            get { return _contractorId; }
            set { _contractorId = value; }
        }
        public string OrganisationName
        {
            get { return _OrganisationName; }
            set
            {
                _OrganisationName = value; 
                OnPropertyChanged("OrganisationName");
            }
        }
        public string ContactName
        {
            get { return _contactName;}
            set
            {
                _contactName = value;
                OnPropertyChanged("ContactName");
            }
        }

        public string SkillReq
        {
            get
            {
                return _skillReq;
            }
            set
            {
                _skillReq = value;
                OnPropertyChanged("SkillReq");
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

        public string Status
        {
            get { return _status; }
            set
            {
                _status = value; 
                OnPropertyChanged("Status");
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

        //public string ReqCompletion => _requestedCompletion.ToShortDateString();

        public string ContractorRating
        {
            get { return _contractorRating; }
            set
            {
                _contractorRating = value;
                OnPropertyChanged("ContractorRating");
            }
        }

        #endregion Public Properties

        #region Consstructor

        public RequestedJob()
        {
            _db = new SQLHelper();
        }


        public RequestedJob(DataRow dr)
        {
            _db = new SQLHelper();
            JobId = Convert.ToInt32(dr["JobId"].ToString());
            OrganisationName = dr["OrganisationName"].ToString();
            ContactName = dr["Contact Name"].ToString();
            SkillReq = dr["SkillReq"].ToString();
            Description = dr["Description"].ToString();
            Status = dr["Status"].ToString();
            RequestedCompletion = Convert.ToDateTime(dr["RequestedCompletion"].ToString());
            ContractorRating = dr["ContractorRating"].ToString();

        }



        #endregion Constructor

        #region Public Methods
        public string FindContractor(int contractorId)
        {
            string findSQL =

                "SELECT" +
                             " CON.ContractorId,  " +
                             "  CON.FirstName," +
                             "  CON.LastName," +
                             "  CS.SkillTitle," +
                             "  A.AvailabilityDate" +
                             " FROM" +
                             "  Contractor AS CON," +
                             "  Availability AS A," +
                             "  ContractSkill AS CS" +
                             " WHERE" +
                             "  CS.ContractorId = CON.ContractorId" +
                             " AND" +
                             "  CON.ContractorId = A.ContractorId" +
                             "AND" +
                             "  CON.ContractorId = @ContractorId";
            SqlParameter[] objParams  = new SqlParameter[1];
            objParams[0] = new SqlParameter("@ContractorId", DbType.Int32);
            objParams[0].Value = contractorId;
            int rowsAffected = _db.ExecuteNonQuery(findSQL, objParams);
            if (rowsAffected >= 1)
            {
                return "Contractors Found";
            }

            return "There are no contractors Available";
        }

        public string AssignJob(int contractorId, int jobId)
        {
            string assignSql = @"UPDATE
                                    Job
                                SET
                                    Status = 'Assigned',
                                    ContractorId = @ContractorId
                                WHERE
                                    JobId = @JobId";

                                   
            SqlParameter[] objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@JobId", DbType.Int32);
            objParams[0].Value = jobId;
            objParams[1] = new SqlParameter("@ContractorId", DbType.Int32);
            objParams[1].Value = contractorId;
            int rowsAffected = _db.ExecuteNonQuery(assignSql, objParams);
            if (rowsAffected >= 1)
            {
                return "Job Assigned Successfully";
            }

            return "Unable to assign job, please try again later";

        }

        #endregion Public Methods
    }
}
