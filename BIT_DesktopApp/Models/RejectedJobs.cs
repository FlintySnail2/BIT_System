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

        #region Constructors

        private SQLHelper _db;

        public RejectedJobs()
        {
            _db = new SQLHelper();
            string sp = "usp_GetRejectedJobs";
            DataTable dt = _db.ExecuteSQL(sp);
            foreach (DataRow dataRow in dt.Rows )
            {
                RejectedJob newRejectedJob = new RejectedJob(dataRow);
                Add(newRejectedJob);

            }

        }

        #endregion Constructors
    }
}
