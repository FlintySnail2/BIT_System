using BIT_WebApplication.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BIT_WebApplication.BLL
{
    public class Client
    {
        public int ClientId { get; set; }
        private int JobId { get; set; }
        private string FirstName { get; set; }
        private int LocationNumber { get; set; }
        private DateTime CompletionDate { get; set; }
        private string Priority { get; set; }
        private string Description { get; set; }
        private string  Status { get; set; }
        private SQLHelper _db;

        public Client()
        {
            _db = new SQLHelper();
        }
        //STILL BROKEN 2ND WEEKEND IN A ROW WASTED ON A QUERY THAT SHOULD NOT HAVE AN ISSUE


        public DataTable AllClientJobs()
        {//REMOVE LOCATION FROM QUERY
            string sql = "SELECT " +
                "           J.JobId AS Job, " +
                "           CON.FirstName + ' ' + CON.LastName AS Contractor, " +
                "           J.RequestedCompletionDate, " +
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
    }
}