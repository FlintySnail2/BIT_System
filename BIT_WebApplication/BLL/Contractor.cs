using BIT_WebApplication.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BIT_WebApplication.BLL
{
    public class Contractor
    {
        public int _contractorId { get; set; }
        
        private SQLHelper _db;


        public Contractor()
        {
            _db = new SQLHelper();
        }

        #region Public Methods

        public DataTable AllAssignedJobs()
        {
            string sql = "SELECT" +
                "            JobId," +
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
                "           CON.ContractorId = @Contractor_Id" + //WORKS IN SQL WHEN THIS LINE IS REMOVED
                "         AND" +
                "          J.Status LIKE '%Assigned%'"; //NOT EXECTUING CORRECTLY ???
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@Contractor_Id", DbType.Int32);
            objParams[0].Value = this._contractorId;
            DataTable contractorJobs = _db.ExecuteSQL(sql, objParams);
            return contractorJobs;
        }

        //PULL ALL ASSIGNED JOBS TO THE CONTRACTOR SESSION
        public DataTable AllAcceptedJobs()
        {
            string sql = "SELECT" +
                    "            JobId," +
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
                    "           J.Status = 'Accepted'";
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@Contractor_Id", DbType.Int32);
            objParams[0].Value = this._contractorId;
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
      
        public int RejectJob(int jobId, string comment)
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
            SqlParameter[] objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@Comment", DbType.Int32);
            objParams[0].Value = comment;
            objParams[1] = new SqlParameter("@JobId", DbType.Int32);
            objParams[1].Value = jobId;
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
                "           JobId = @JobId"; ;
            SqlParameter[] objParams = new SqlParameter[3];
            objParams[0] = new SqlParameter("@Kilometres", DbType.Int32);
            objParams[0].Value = kilometers;
            objParams[1] = new SqlParameter("@Comment", DbType.Int32);
            objParams[1].Value = kilometers;
            objParams[2] = new SqlParameter("@JobId", DbType.Int32);
            objParams[2].Value = jobId;
            returnValue = _db.ExecuteNonQuery(sql, objParams);
            return returnValue;
        }



        #endregion Public Methods
    }

   
}