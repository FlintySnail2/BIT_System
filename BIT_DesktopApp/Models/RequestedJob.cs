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

        public int JobId
        {
            get { return _jobId; } set { _jobId = value; }

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

        public string ReqCompletion => _requestedCompletion.ToShortDateString();

        public string ContractorRating
        {
            get { return _contractorRating; }
            set
            {
                _contractorRating = value;
                OnPropertyChanged("ContractorRating");
            }
        }
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
                             "  CON.ContractorId = @C";
            SqlParameter[] objParams  = new SqlParameter[1];
            objParams[0] = new SqlParameter("@ContractorId", DbType.Int32);
            objParams[0].Value = contractorId;
            int rowsAffected = _db.ExecuteNonQuery(findSQL, objParams);
            if (rowsAffected >= 1)
            {
                return "Contractors Found";
            }

            return "Derp";
        }
    }
}
