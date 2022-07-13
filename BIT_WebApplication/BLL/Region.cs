using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BIT_WebApplication.DAL;

namespace BIT_WebApplication.BLL
{
    public static class Region
    {
        public static DataTable GetAllRegion()
        {
            string sp = "usp_GetAllClientRegions";
;
            SQLHelper _db = new SQLHelper();
            DataTable region = _db.ExecuteSQL(sp);
            return region;
        }
    }
}