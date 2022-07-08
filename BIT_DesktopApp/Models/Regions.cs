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
    public class Regions : List<Region>
    {

        public Regions(int clientId)
        {
            SQLHelper db = new SQLHelper();
            string sp = "usp_GetRegionByClientId";
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@ClientId", DbType.Int32);
            objParams[0].Value = clientId;
            DataTable regionName = db.ExecuteSQL(sp, objParams, true);
            foreach (DataRow dr in regionName.Rows)
            {
                Region region = new Region(dr);
                Add(region);
            }

        }

        public Regions()
        {
            SQLHelper db = new SQLHelper();
            string sp = "usp_GetRegions";
            DataTable regionName = db.ExecuteSQL(sp);
            foreach (DataRow dr  in regionName.Rows)
            {
                Region region = new Region(dr);
                Add(region);
            }
        }
    }
}
