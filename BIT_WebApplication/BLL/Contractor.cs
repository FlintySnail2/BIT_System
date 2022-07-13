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
            string sp = "usp_GetAllAssignedJobs"; 
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@Contractor_Id", DbType.Int32);
            objParams[0].Value = this.ContractorId;
            DataTable contractorJobs = _db.ExecuteSQL(sp, objParams, true);
            return contractorJobs;
        }



        


        public DataTable AllAcceptedJobs()
        {
            string sp = "usp_GetAllAcceptedJobs";
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@Contractor_Id", DbType.Int32);
            objParams[0].Value = this.ContractorId;
            DataTable contractorJobs = _db.ExecuteSQL(sp, objParams, true);
            return contractorJobs;
        }

      

        public int AcceptJob(int jobId)
        {
            int returnValue = 0;
            string sp = "usp_AcceptJob";
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@JobId", DbType.Int32);
            objParams[0].Value = jobId;
            returnValue = _db.ExecuteNonQuery(sp, objParams, true);
            return returnValue;
        }

        public int RejectJob(int jobId, string comment)
        {
            int returnValue = 0;
            string sp = "usp_RejectJob";
            SqlParameter[] objParams = new SqlParameter[3];
            objParams[0] = new SqlParameter("@JobId", DbType.Int32);
            objParams[0].Value = jobId;
            objParams[1] = new SqlParameter("@ContractorId", DbType.Int32);
            objParams[1].Value = ContractorId;
            objParams[2] = new SqlParameter("@Comment", DbType.String);
            objParams[2].Value = comment;
        _db.ExecuteNonQuery(sp, objParams, true);
        return returnValue;

        }

        public int CompleteJob(int jobId, int kilometers, decimal hours, string comment)
        {

        int returnValue = 0;
        string sp = "usp_CompleteJob";
        SqlParameter[] objParams = new SqlParameter[3];
        objParams[0] = new SqlParameter("@Distance", DbType.Int32);
        objParams[0].Value = kilometers;
        objParams[1] = new SqlParameter("@Hours", DbType.Decimal);
        objParams[1].Value = hours;
        objParams[2] = new SqlParameter("@JobId", DbType.Int32);
        objParams[2].Value = jobId;
        objParams[3] = new SqlParameter("@Comment", DbType.String);
        objParams[3].Value = comment;
        _db.ExecuteNonQuery(sp, objParams, true);
        return returnValue;
    }
        #endregion Public Methods
}

   

