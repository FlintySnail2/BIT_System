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
            string sp = "usp_GetAllRejectedJobs";
            
            SQLHelper helper = new SQLHelper();
            DataTable dt = helper.ExecuteSQL(sp);
            return dt;
        }
    }
}