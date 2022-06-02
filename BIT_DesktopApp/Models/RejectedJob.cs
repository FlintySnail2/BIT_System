using BIT_DesktopApp.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIT_DesktopApp.Models
{
    public class RejectedJob
    {
        private int _jobId;
        private string _OrganisationName;
        private string _contactName;
        private string _skillReq;
        private string _description;
        private string _status;
        private DateTime _requestedCompletion;
        public SQLHelper _db;


        public int JobId
        {
            get { return _jobId; }
            set { _jobId = value; }

        }

        public string OrganisationName
        {
            get { return _OrganisationName; }
            set { _OrganisationName = value; }
        }
        public string ContactName
        {
            get { return _contactName; }
            set { _contactName = value; }
        }

        public string SkillReq
        {
            get
            {
                return _skillReq;
            }
            set { _skillReq = value; }

        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public DateTime RequestedCompletion
        {
            get { return _requestedCompletion; }
            set { _requestedCompletion = value; }
        }

        public string ReqCompletion => _requestedCompletion.ToShortDateString();


        public RejectedJob()
        {
            _db = new SQLHelper();
        }


        public RejectedJob(DataRow dr)
        {
            _db = new SQLHelper();
            JobId = Convert.ToInt32(dr["JobId"].ToString());
            OrganisationName = dr["OrganisationName"].ToString();
            ContactName = dr["Contact Name"].ToString();
            SkillReq = dr["SkillReq"].ToString();
            Description = dr["Description"].ToString();
            Status = dr["Status"].ToString();
            RequestedCompletion = Convert.ToDateTime(dr["RequestedCompletion"].ToString());

        }

        public string ReassignJob(int jobId, int contractorId)
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
        }
    }
