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
                "           CON.ContractorId = @Contractor_Id";
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@Contractor_Id", DbType.Int32);
            objParams[0].Value = this._contractorId;
            DataTable contractorJobs = _db.ExecuteSQL(sql, objParams);
            return contractorJobs;
        }
    }
}