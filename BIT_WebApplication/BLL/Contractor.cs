using BIT_WebApplication.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


    public class Contractor
    {

        #region Properties
        public int ContractorId { get; set; }
        public int StaffId { get; set; }
        public string Skill { get; set; }
        public string Availability { get; set; }
        private SQLHelper _db;

        #endregion Properties

        public Contractor()
        {
            _db = new SQLHelper();
        }


        #region Public Methods

        public DataTable AllAssignedJobs()
        {
            string sql = "SELECT" +
                "            J.JobId," +
                "            C.OrganisationName AS Client," +
                "            C.FirstName + ' ' + C.LastName AS [Contact Name]," +
                "            C.Phone," +
                "            J.RequestedStartDate AS [Service Day]," +
                "            J.RequestedCompletionDate AS [Requested Completion]," +
                "            J.Priority," +
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
                "           CON.ContractorId = @Contractor_Id" + 
                "         AND" +
                "          J.Status = 'Assigned'"; 
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@Contractor_Id", DbType.Int32);
            objParams[0].Value = this.ContractorId;
            DataTable contractorJobs = _db.ExecuteSQL(sql, objParams);
            return contractorJobs;
        }



        


        public DataTable AllAcceptedJobs()
        {
            string sql = "SELECT" +
                    "            J.JobId," +
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
                    "           J.Status = 'Accepted'";
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@Contractor_Id", DbType.Int32);
            objParams[0].Value = this.ContractorId;
            DataTable contractorJobs = _db.ExecuteSQL(sql, objParams);
            return contractorJobs;
        }

      

        public int AcceptJob(int jobId)
        {
            int returnValue = 0;
            string sql = "UPDATE" +
                "               Job" +
                "         SET" +
                "           Status = 'Accepted'" +
                "         WHERE" +
                "           JobId = @JobId";
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@JobId", DbType.Int32);
            objParams[0].Value = jobId;
            returnValue = _db.ExecuteNonQuery(sql, objParams);
            return returnValue;
        }

        public int RejectJob(int jobId)
        {
            int returnValue = 0;
            string sql = "UPDATE" +
                "               Job" +
                "         SET" +
                "           Status = 'Rejected'" +
                "         WHERE" +
                "           JobId = @JobId" +
                "       " +
                "         UPDATE" +
                "               RejectedJob" +
                "         SET" +
                "           Comment = @Comment" +
                "         WHERE" +
                "           JobId = @JobId";
        SqlParameter[] objParams = new SqlParameter[1];
        objParams[0] = new SqlParameter("@JobId", DbType.Int32);
        objParams[0].Value = jobId;
        //objParams[1] = new SqlParameter("@Comment", DbType.Int32);
        //objParams[1].Value = comment;
        returnValue = _db.ExecuteNonQuery(sql, objParams);
        return returnValue;

        }

        public int CompleteJob(int jobId, int kilometers, string comment)
        {
            int returnValue = 0;
            string sql = "UPDATE " +
                "           Job " +
                "         SET " +
                "           Status = 'Completed'," +
                "           DistanceTravelled = @Kilometres" +
                "       WHERE " +
                "           JobId = @JobId" +
                   "       " +
                "         UPDATE" +
                "               RejectedJob" +
                "         SET" +
                "           Comment = @Comment" +
                "         WHERE" +
                "           JobId = @JobId" +
                "         UPDATE" +
                "           Feedback" +
                "         SET " +
                "           Comment = @Comment" +
                "         WHERE" +
                "           JobId = @JobId"; 
                
             
            SqlParameter[] objParams = new SqlParameter[3];
            objParams[0] = new SqlParameter("@Kilometres", DbType.Int32);
            objParams[0].Value = kilometers;
            objParams[1] = new SqlParameter("@Comment", DbType.Int32);
            objParams[1].Value = comment;
            objParams[2] = new SqlParameter("@JobId", DbType.Int32);
            objParams[2].Value = jobId;
            returnValue = _db.ExecuteNonQuery(sql, objParams);
            return returnValue;
        }

        public int FinaliseJob(int jobId, string updateStatus)
        {
            int returnValue = 0;
            string sql = "UPDATE" +
                "               Job" +
                "           SET" +
                "               Status = @UpdateStatus" +
                "           WHERE" +
                "               JobId = @JobId";
            SqlParameter[] objParmas = new SqlParameter[2];
            objParmas[0] = new SqlParameter("@JobId",DbType.Int32);
            objParmas [0].Value = jobId;
            objParmas[1] = new SqlParameter("@UpdateStatus",DbType.String);
            objParmas [1].Value = updateStatus;
            returnValue = _db.ExecuteNonQuery(sql, objParmas);
            return returnValue;
        }

        #endregion Public Methods
    }

   

