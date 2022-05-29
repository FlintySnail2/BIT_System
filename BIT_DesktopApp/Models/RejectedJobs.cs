using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BIT_DesktopApp.DAL;

namespace BIT_DesktopApp.Models
{
    public class RejectedJobs : List<RejectedJob>
    {


        private SQLHelper _db;

        public RejectedJobs()
        {
            _db = new SQLHelper();
            string sql = "SELECT" +
                         "           J.JobId," +
                         "           C.OrganisationName," +
                         "           C.FirstName + ' ' + C.LastName as [Contact Name]," +
                         "           CON.FirstName AS ContractorName," +
                         "           J.Description," +
                         "           J.SkillTitle AS [SkillReq]," +
                         "           J.Priority," +
                         "           S.Status," +
                         "           CONVERT(NVARCHAR, J.RequestedCompletionDate, 6) AS [RequestedCompletion]" +
                         "       FROM" +
                         "           Job AS J," +
                         "           Client AS C," +
                         "           Status AS S," +
                         "           Contractor AS CON" +
                         "       WHERE" +
                         "           J.ClientId = C.ClientId" +
                         "       AND J.Status = S.Status" +
                         "           AND CON.ContractorId = J.ContractorId" +
                         "       AND J.Status = 'Rejected'";
            DataTable dt = _db.ExecuteSQL(sql);
            foreach (DataRow dataRow in dt.Rows )
            {
                RejectedJob newRejectedJob = new RejectedJob(dataRow);
                Add(newRejectedJob);

            }

        }
    }
}
