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
            string sp = "usp_GetRequestedJob";
            DataTable dt = _db.ExecuteSQL(sp);
            foreach (DataRow dataRow in dt.Rows)
            {
                RequestedJob newRequestedJob = new RequestedJob(dataRow);
                Add(newRequestedJob);
            }
        }
    }
}
