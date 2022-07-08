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
    public class Jobs : List<Job>
    {
        private SQLHelper _db;

        public Jobs()
        {
            _db = new SQLHelper();
            string sp = "usp_GetJobs";
            DataTable datatable = _db.ExecuteSQL(sp);
            foreach (DataRow dr in datatable.Rows)
            {
                Job newJob = new Job(dr);
                this.Add(newJob);
            }        
        }

        public Jobs(string searchText)
        {
            _db = new SQLHelper();
            string sp = "usp_SearchJobs";
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@SearchText", DbType.String);
            objParams[0].Value = searchText;
            DataTable dataTable = _db.ExecuteSQL(sp, objParams,true);
            foreach (DataRow dr in dataTable.Rows)
            {
                Job newJob = new Job(dr);
                this.Add(newJob);
            }
        }
    }
}
