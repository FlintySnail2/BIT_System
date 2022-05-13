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

        public int _clientId { get; set; }
        public string _region { get; set; } //PULL INTO A SESSION LIKE CLIENT_ID....
        public string WeekDay { get; set; }
        public string Skill { get; set; }
        public int _staffId { get; set; }
        public int Rating { get; set; }
        public int _contractorId { get; set; }
        public string _priority { get; set; }
        public string _skillReq { get; set; }
        public string _description { get; set; }
        public DateTime _startDate { get; set; }
        public DateTime _completionDate { get; set; }
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
                "           J.RequestedStartDate AS [Service Day], " +
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
            objParams[0].Value = this._clientId;
            DataTable jobs = _db.ExecuteSQL(sql, objParams);
            return jobs;
        }

        public DataTable AllCompletedJobs()
        {
            string sql = "SELECT" +
        "                   JobId, " +
        "                   C.OrganisationName AS Client," +
        "                   C.FirstName + ' ' + C.LastName AS [Contact Name]," +
        "                   CON.FirstName + ' ' + CON.LastName AS Technician," +
        "                   J.RequestedStartDate AS [Service Day]," +
        "                   J.RequestedCompletionDate AS [Requested Completion]," +
        "                   J.Description" +
        "               FROM" +
        "                   Job AS J," +
        "                   Client AS C," +
        "                   Contractor AS CON" +
        "               WHERE" +
        "                  C.ClientId = J.ClientId" +
        "               AND" +
        "                  J.ContractorId = CON.ContractorId" +
        "               AND" +
        "                  J.Status = 'Completed'" +
        "               AND" +
        "                  CON.ContractorId = @Contractor_Id";
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@Contractor_Id", DbType.Int32);
            objParams[0].Value = this._clientId;
            DataTable completedJobs = _db.ExecuteSQL(sql, objParams);
            return completedJobs;
        }

        public DataTable AllRejectedJobs()
        {
            string sql = "SELECT" +
        "                   JobId, " +
        "                   C.OrganisationName AS Client," +
        "                   C.FirstName + ' ' + C.LastName AS [Contact Name]," +
        "                   CON.FirstName + ' ' + CON.LastName AS Technician," +
        "                   J.RequestedStartDate AS [Service Day]," +
        "                   J.RequestedCompletionDate AS [Requested Completion]," +
        "                   J.Description" +
        "               FROM" +
        "                   Job AS J," +
        "                   Client AS C," +
        "                   Contractor AS CON" +
        "               WHERE" +
        "                  C.ClientId = J.ClientId" +
        "               AND" +
        "                  J.ContractorId = CON.ContractorId" +
        "               AND" +
        "                  J.Status = 'Completed'" +
        "               AND" +
        "                  CON.ContractorId = @Contractor_Id";
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@Contractor_Id", DbType.Int32);
            objParams[0].Value = this._clientId;
            DataTable completedJobs = _db.ExecuteSQL(sql, objParams);
            return completedJobs;
        }

        public string InsertJob()
        {//SESSION ID ALREADY PASSES CLIENT ID?
            string sql = "INSERT INTO JOB(" +
                    "       ClientId," +
                    "       Priority," +
                    "       SkillTitle," +
                    "       Description," +
                    "       RequestedStartDate," +
                    "       RequestedCompletionDate," +
                    "       Staus)" +
                "     VALUES(" +
                    "       @Client_Id,    "        +
                    "       @Priority," +
                    "       @SkillTitle," +
                    "       @Description," +
                    "       @StartDate," +
                    "       @CompletionDate," +
                    "       'Requested')";
            SqlParameter[] objParams = new SqlParameter[6];
            objParams[0] = new SqlParameter("@Priority", DbType.String);
            objParams[0].Value = this._priority;
            objParams[1] = new SqlParameter("@SkillTitle", DbType.String);
            objParams[1].Value = this._skillReq;
            objParams[2] = new SqlParameter("@Description",DbType.String);
            objParams[2].Value = this._description;
            objParams[3] = new SqlParameter("@StartDate", DbType.String);
            objParams[3].Value = this._startDate;
            objParams[4] = new SqlParameter("@CompletionDate", DbType.String);
            objParams[4].Value = this._completionDate;
            objParams[5] = new SqlParameter("@Client_Id", DbType.String);
            objParams[5].Value = this._clientId;
            int rowsAffected = _db.ExecuteNonQuery(sql, objParams);
            if (rowsAffected >= -1)
            {
                return "<script>alert('New Job Request Has been submitted')</script>";
            }
            return "<script>('Some went wrong please try again')</script> ";
        }
        #endregion Public Methodds
    }
}