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
            string sql = "SELECT " +
                "           J.JobId AS Job, " +
                "           CON.FirstName + ' ' + CON.LastName AS [Technician] ," +
                "           CONVERT(NVARCHAR, J.RequestedStartDate, 6)  AS [Service Date], " + //Not applying convert
                "           J.Description, " +
                "           J.Priority, " +
                "           J.Status" +
                    " FROM  " +
                    "       Client AS C, " +
                    "       Job AS J,  " +
                    "       Location AS L, " +
                    "       Contractor AS CON" +
                    " WHERE " +
                    "       CON.ContractorId = J.ContractorId" +
                    " AND " +
                    "       C.ClientId = J.ClientId" +
                    " AND " +
                    "       C.ClientId = L.ClientId" +
                    " AND " +
                    "       C.ClientId = @Client_Id";

            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@Client_Id", DbType.Int32);
            objParams[0].Value = this.ClientId;
            DataTable jobs = _db.ExecuteSQL(sql, objParams);
            return jobs;
        }

        public DataTable AllCompletedJobs()
        {
            string sql = "SELECT" +
                    "            JobId," +
                    "            C.OrganisationName AS Client," +
                    "            C.FirstName + ' ' + C.LastName AS [Contact Name]," +
                    "            CON.FirstName + ' ' + CON.LastName AS Contractor," +
                    "            J.RequestedStartDate AS [Service Day]," +
                    "            J.RequestedCompletionDate AS [Requested Completion]," +
                    "            J.Status," +
                    "            J.Description" +
                    "         FROM" +
                    "           Job AS J," +
                    "           Client AS C," +
                    "           Contractor AS CON" +
                    "         WHERE" +
                    "           C.ClientId = J.ClientId" +
                    "         AND" +
                    "           J.ContractorId = CON.ContractorId" +
                    "         AND" +
                    "           J.Status = 'Completed'";
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@Contractor_Id", DbType.Int32);
            objParams[0].Value = this.ContractorId;
            DataTable contractorJobs = _db.ExecuteSQL(sql, objParams);
            return contractorJobs;
        }

        public DataTable AllRejectedJobs()
        {
            string sql = "SELECT" +
                    "            J.JobId," +
                    "            C.OrganisationName AS Client," +
                    "            C.FirstName + ' ' + C.LastName AS [Contact Name]," +
                    "            CON.FirstName + ' ' + CON.LastName AS Contractor," +
                    "            R.Comment AS Reason," +
                    "            J.RequestedStartDate AS [Service Day]," +
                    "            J.RequestedCompletionDate AS [Requested Completion]," +
                    "            J.Status," +
                    "            J.Description" +
                    "         FROM" +
                    "           Job AS J," +
                    "           Client AS C," +
                    "           Contractor AS CON," +
                    "           RejectedJob AS R" +
                    "         WHERE" +
                    "           C.ClientId = J.ClientId" +
                    "         AND" +
                    "           J.ContractorId = CON.ContractorId" +
                    "         AND" +
                    "           J.JobId = R.JobId" +
                    "         AND" +
                    "           J.Status = 'Rejected'";
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@Contractor_Id", DbType.Int32);
            objParams[0].Value = this.ContractorId;
            DataTable contractorJobs = _db.ExecuteSQL(sql, objParams);
            return contractorJobs;
        }

        public string InsertJob()
        {
            string sql = "INSERT INTO JOB(" +
                    "       ClientId," +
                    "       Priority," +
                    "       SkillTitle," +
                    "       Description," +
                    "       RequestedStartDate," +
                    "       RequestedCompletionDate," +
                    "       Status)" +
                "     VALUES(" +
                    "       @Client_Id,    " +
                    "       @Priority," +
                    "       @SkillTitle," +
                    "       @Description," +
                    "       @StartDate," +
                    "       @CompletionDate," +
                    "       'Requested')";
                    
            //INSERT REGION NAME INTO ABOVE QUERY (ANOTHER TABLE)
            SqlParameter[] objParams = new SqlParameter[6];
            objParams[0] = new SqlParameter("@Priority", DbType.String);
            objParams[0].Value = this.Priority;
            objParams[1] = new SqlParameter("@SkillTitle", DbType.String);
            objParams[1].Value = this.SkillReq;
            objParams[2] = new SqlParameter("@Description", DbType.String);
            objParams[2].Value = this.Description;
            objParams[3] = new SqlParameter("@StartDate", DbType.String);
            objParams[3].Value = this.StartDate;
            objParams[4] = new SqlParameter("@CompletionDate", DbType.String);
            objParams[4].Value = this.CompletionDate;
            objParams[5] = new SqlParameter("@Client_Id", DbType.String);
            objParams[5].Value = this.ClientId;
            int rowsAffected = _db.ExecuteNonQuery(sql, objParams);
            if (rowsAffected >= -1)
            {
                return "<script>alert('New Job Request Has been submitted')</script>";
            }
            return "<script>('Some went wrong please try again')</script> ";
        }

        public int Verified(int jobId)
        {
            int returnValue = 0;
            string sql = "UPDATE" +
                "           Job" +
                "         SET" +
                "           Status = 'Verified'" +
                "         WHERE  " +
                "           JobId = @JobId";
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@JobId",DbType.Int32);
            objParams[0].Value = jobId;
            returnValue = _db.ExecuteNonQuery(sql, objParams);
            return returnValue;   
        }

        public int SendForPayment(int jobId)
        {
            int returnValue = 0;
            string sql = "UPDATE" +
                "           Job" +
                "         SET" +
                "           Status = 'Send For Payment'" +
                "         WHERE  " +
                "           JobId = @JobId";
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@JobId", DbType.Int32);
            objParams[0].Value = jobId;
            returnValue = _db.ExecuteNonQuery(sql, objParams);
            return returnValue;
        }




        #endregion Public Methods
    }
}
