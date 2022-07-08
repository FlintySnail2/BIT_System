using BIT_DesktopApp.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIT_DesktopApp.Models
{
    public class JobsStatus : List<JobStatus>
    {

        public JobsStatus()
        {
            SQLHelper db = new SQLHelper();
            string sp = "usp_GetJobStatus";
            DataTable jobsStatus = db.ExecuteSQL(sp);
            foreach (DataRow dr in jobsStatus.Rows)
            {
                JobStatus jobStatus = new JobStatus(dr);
                this.Add(jobStatus);
            }
        }
    }
}
