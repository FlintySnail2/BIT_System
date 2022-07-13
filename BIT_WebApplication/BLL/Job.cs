using BIT_WebApplication.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BIT_WebApplication.BLL
{
    public class Job
    {
        #region Private Properties

        public int ClientId { get; set; }
        public int ContractorId { get; set; }
        public int JobId { get; set; }
        public string Region { get; set; } 
        public string WeekDay { get; set; }
        public string Skill { get; set; }
        public int StaffId { get; set; }
        public int Rating { get; set; }
        public string Priority { get; set; }
        public string SkillReq { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CompletionDate { get; set; }
        private SQLHelper _db;

        #endregion Private Properties

        #region Constructor

        public Job()
        {
            _db = new SQLHelper();
        }

        #endregion Constructor

        #region Public Methods
        public DataTable AllClientJobs()
        {
            //CALL CONCAT WITH REGION FOR SELECTED VALUE
            string sp = "usp_GetAllClientJobs";
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@Client_Id", DbType.Int32);
            objParams[0].Value = this.ClientId;
            DataTable jobs = _db.ExecuteSQL(sp, objParams, true);
            return jobs;
        }

        public DataTable AllRequestedJobs()
        {
            string sp = "usp_GetRequestedJob";
            DataTable dt = _db.ExecuteSQL(sp);
            return dt;
        }
        

        public DataTable AvailableContractors(int jobId,string skill,DateTime completionDate)
        {
            string sp = "usp_GetAllAvailableContractors";
            SqlParameter[] objParams = new SqlParameter[3];
            objParams[0] = new SqlParameter("@JobId", DbType.Int32);
            objParams[0].Value = jobId;
            objParams[1] = new SqlParameter("@Skill", DbType.String);
            objParams[1].Value = skill;
            objParams[2] = new SqlParameter("@CompletionDate", DbType.DateTime);
            objParams[2].Value = completionDate;
            DataTable availableContractors = _db.ExecuteSQL(sp, objParams, true);
            return availableContractors;
        }

        public DataTable AllCompletedJobs()
        {
            string sp = "usp_GetAllCompletedJobs";
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@Contractor_Id", DbType.Int32);
            objParams[0].Value = this.ContractorId;
            DataTable contractorJobs = _db.ExecuteSQL(sp, objParams, true);
            return contractorJobs;
        }

        public DataTable AllRejectedJobs()
        {
            string sp = "usp_GetAllRejectedJobs";
            DataTable contractorJobs = _db.ExecuteSQL(sp);
            return contractorJobs;
        }

        public string InsertJob()
        {      
            string sp = "usp_InsertNewClientJob";
            SqlParameter[] objParams = new SqlParameter[7];
            objParams[0] = new SqlParameter("@Region",DbType.String);
            objParams[0].Value = Region;
            objParams[1] = new SqlParameter("@Priority", DbType.String);
            objParams[1].Value = this.Priority;
            objParams[2] = new SqlParameter("@SkillTitle", DbType.String);
            objParams[2].Value = this.SkillReq;
            objParams[3] = new SqlParameter("@Description", DbType.String);
            objParams[3].Value = this.Description;
            objParams[4] = new SqlParameter("@StartDate", DbType.String);
            objParams[4].Value = this.StartDate;
            objParams[5] = new SqlParameter("@CompletionDate", DbType.String);
            objParams[5].Value = this.CompletionDate;
            objParams[6] = new SqlParameter("@Client_Id", DbType.Int32);
            objParams[6].Value = this.ClientId;
            int rowsAffected = _db.ExecuteNonQuery(sp, objParams, true);
            if (rowsAffected >= -1)
            {
                return "<script>alert('New Job Request Has been submitted')</script>";
            }
            return "<script>('Some went wrong please try again')</script> ";
        }

        public int Verified(int jobId)
        {
            int returnValue = 0;
            string sp = "usp_JobVerified";
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@JobId",DbType.Int32);
            objParams[0].Value = jobId;
            returnValue = _db.ExecuteNonQuery(sp, objParams,true);
            return returnValue;   
        }

        public int SendForPayment(int jobId)
        {
            int returnValue = 0;
            string sp = "usp_SendJobForPayment";
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@JobId", DbType.Int32);
            objParams[0].Value = jobId;
            returnValue = _db.ExecuteNonQuery(sp, objParams,true);
            return returnValue;
        }

        public int AssignJob(int jobId, int contractorId)
        {
            int returnValue = 0;
            string sp = "usp_AssignJob";
            SqlParameter[] objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@JobId", DbType.Int32);
            objParams[0].Value =jobId;
            objParams[1] = new SqlParameter("@ContractorId", DbType.Int32);
            objParams[1].Value = contractorId;
            returnValue = _db.ExecuteNonQuery(sp, objParams, true);
            return returnValue;
        }

        #endregion Public Methods
    }
}
