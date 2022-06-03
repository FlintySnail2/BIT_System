using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BIT_DesktopApp.DAL;

namespace BIT_DesktopApp.Models
{
    public class RequestedJobs : List<RequestedJob>
    {
        private SQLHelper _db;

        public RequestedJobs()
        {
            _db = new SQLHelper();
            string sql = "SELECT" +
                         "           J.JobId," +
                         "           C.OrganisationName," +
                         "           C.FirstName + ' ' + C.LastName as [Contact Name]," +
                         "           J.Description," +
                         "           J.SkillTitle AS [SkillReq]," +
                         "           J.Priority," +
                         "           S.Status," +
                         "           CONVERT(NVARCHAR, J.RequestedCompletionDate, 6) AS [RequestedCompletion]" +

                         "       FROM" +
                         "           Job AS J," +
                         "           Client AS C," +
                         "           Status AS S" +
                         "       WHERE" +
                         "           J.ClientId = C.ClientId" +
                         "       AND J.Status = S.Status" +
                         "       AND J.Status = 'Pending'";
            DataTable dt = _db.ExecuteSQL(sql);
            foreach (DataRow dataRow in dt.Rows)
            {
                RequestedJob newRequestedJob = new RequestedJob(dataRow);
                Add(newRequestedJob);
            }
        }
    }
}
