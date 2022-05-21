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
                "            CONVERT(NVARCHAR, J.RequestedCompletionDate, 6) AS [Requested Completion]," +
                "            J.SkillTitle AS [Skill Required]," +
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
                    "            CONVERT(NVARCHAR, J.RequestedCompletionDate, 6) AS [Requested Completion]," +
                    "            J.SkillTitle AS [Skill Required]," +
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
                    "           J.Status = 'Accepted'" +
                    "         AND" +
                    "           CON.ContractorId = @Contractor_Id";
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

        public int RejectJob(int jobId, string comment)
        {
            int returnValue = 0;
            string updatesql = "UPDATE" +
                         "               Job" +
                         "         SET" +
                         "           Status = 'Rejected'" +       
                         "         WHERE" +
                         "           JobId = @JobId" +
                         "       ";
            SqlParameter[] objParams1 = new SqlParameter[1];
            objParams1[0] = new SqlParameter("@JobId", DbType.Int32);
            objParams1[0].Value = jobId;
            _db.ExecuteNonQuery(updatesql, objParams1);

        string insertSql = "         INSERT INTO  RejectedJob(" +
                               "              JobId," +
                               "              ContractorId, " +
                               "              Comment)" +
                               "         VALUES(" +
                               "           @JobId," +
                               "           @ContractorId," +
                               "           @Comment)";
        SqlParameter[] objParams2 = new SqlParameter[3];
        objParams2[0] = new SqlParameter("@JobId", DbType.Int32);
        objParams2[0].Value = jobId;
        objParams2[1] = new SqlParameter("@ContractorId",DbType.Int32);
        objParams2[1].Value = ContractorId;
        objParams2[2] = new SqlParameter("@Comment", DbType.String);
        objParams2[2].Value = comment;
        returnValue = _db.ExecuteNonQuery(insertSql, objParams2);
        return returnValue;

        }

        public int CompleteJob(int jobId, int kilometers, decimal hours, string comment)
        {

        int returnValue = 0;
        string updatesql = "UPDATE" +
                           "               Job" +
                           "         SET" +
                           "           Status = 'Completed'," +
                           "            DistanceTravelled = @Distance," +
                        "                HoursOnJob = @Hours    "  +     
                           "         WHERE" +
                           "           JobId = @JobId" +
                           "       ";
        SqlParameter[] objParams1 = new SqlParameter[3];
        objParams1[0] = new SqlParameter("@Distance", DbType.Int32);
        objParams1[0].Value = kilometers;
        objParams1[1] = new SqlParameter("@Hours", DbType.Decimal);
        objParams1[1].Value = hours;
        objParams1[2] = new SqlParameter("@JobId", DbType.Int32);
        objParams1[2].Value = jobId;
        _db.ExecuteNonQuery(updatesql, objParams1);

        string insertSql = "         INSERT INTO  Feedback(" +
                           "              JobId," +
                           "              Comment)" +
                           "         VALUES(" +
                           "           @JobId," +
                           "           @Comment)";
        SqlParameter[] objParams2 = new SqlParameter[2];
        objParams2[0] = new SqlParameter("@JobId", DbType.Int32);
        objParams2[0].Value = jobId;
        objParams2[1] = new SqlParameter("@Comment", DbType.String);
        objParams2[1].Value = comment;
        returnValue = _db.ExecuteNonQuery(insertSql, objParams2);
        return returnValue;
    }
        #endregion Public Methods
}

   

