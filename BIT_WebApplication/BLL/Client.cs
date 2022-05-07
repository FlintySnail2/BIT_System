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
        {
            string sql = "SELECT" +
                "           J.Job_id AS Job," +
//                "           CON.FirstName + CON.LastName AS Contractor," +
//                "           J.CompletionDate," +
                "           J.Description," +
                "           J.Priority," +
                "           J.Status" +
                "         FROM" +
                "           Client AS C," +
                "           Job AS J," +
                "           Location AS L" +
                //"           Contractor AS CON" +
                "         WHERE" +
//                "           CON.Contractor_id = C.Contractor_id" +
//                "         AND" +
                "           C.Client_id = J.Client_id" +
                "         AND" +
                "           C.Client_id = L.Client_id" +
                "         AND" +
                "           J.Client_Id = @ClientId";

            SqlParameter[] objParams = new SqlParameter[6];
            objParams[0] = new SqlParameter("@ClientId", DbType.Int32);
            objParams[0].Value = this.ClientId;
            objParams[1] = new SqlParameter("@JobId", DbType.Int32);
            objParams[1].Value = this.JobId;
            //objParams[2] = new SqlParameter("@Contractor", DbType.String);
            //objParams[2].Value = this.FirstName;
            objParams[2] = new SqlParameter("@LocationNumber", DbType.Int32);
            objParams[2].Value = this.LocationNumber;
            //TRIM TIME WITH TOSHORTDATESTRING();
            //objParams[4] = new SqlParameter("@CompletionDate", DbType.DateTime);
            //objParams[4].Value = this.CompletionDate;
            objParams[3] = new SqlParameter("@Priority", DbType.String);
            objParams[3].Value = this.Priority;
            objParams[4] = new SqlParameter("@Description", DbType.String);
            objParams[4].Value = this.Description;
            objParams[5] = new SqlParameter("@Status", DbType.String);
            objParams[5].Value = this.Status;
            DataTable jobs = _db.ExecuteSQL(sql, objParams);
            return jobs;
        }
    }
}