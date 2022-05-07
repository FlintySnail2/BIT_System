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
        

        public JobsStatus(int jobId)
        {
            SQLHelper db = new SQLHelper();
            string sql = "SELECT" +
                "           Status" +
                "         FROM" +
                "           Job" +
                "         WHERE" +
                "           Job_Id = @JobId";
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@JobId", DbType.Int32);
            objParams[0].Value = jobId;
            DataTable jobsStatus = db.ExecuteSQL(sql, objParams);
            foreach (DataRow dr in jobsStatus.Rows)
            {
                JobStatus status = new JobStatus(dr);
                this.Add(status);
            }
        }

        public JobsStatus()
        {
            SQLHelper db = new SQLHelper();
            string sql = "SELECT" +
                "           Status" +
                "          FROM" +
                "           Job";
            DataTable jobsStatus = db.ExecuteSQL(sql);
            foreach (DataRow dr in jobsStatus.Rows)
            {
                JobStatus jobStatus = new JobStatus(dr);
                this.Add(jobStatus);
            }
        }
    }
}
