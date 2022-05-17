using BIT_WebApplication.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BIT_WebApplication.BLL
{
    public class RejectedJobs
    {
        public DataTable AllRejectedJobs()
        {
            string sql = "SELECT" +
        "                   J.JobId, " +
        "                   C.OrganisationName AS Client," +
        "                   C.FirstName + ' ' + C.LastName AS [Contact Name]," +
        "                   CON.FirstName + ' ' + CON.LastName AS Technician," +
        "                   R.Comment AS Reason," +
        "                   J.RequestedStartDate AS [Service Day]," +
        "                   J.RequestedCompletionDate AS [Requested Completion]," +
        "                   J.Description" +
        "               FROM" +
        "                   Job AS J," +
        "                   Client AS C," +
        "                   Contractor AS CON," +
        "                   RejectedJob AS R" +
        "               WHERE" +
        "                  C.ClientId = J.ClientId" +
        "               AND" +
        "                  J.ContractorId = CON.ContractorId" +
        "               AND" +
        "                  R.JobId = J.JobId" +
        "               AND" +
        "                  J.Status = 'Rejected'";
            
            SQLHelper helper = new SQLHelper();
            DataTable dt = helper.ExecuteSQL(sql);
            return dt;
        }
    }
}