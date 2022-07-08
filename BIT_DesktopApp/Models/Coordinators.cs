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
    public class Coordinators : List<Coordinator>
    {
        private SQLHelper _db;

        public Coordinators()
        {
            _db = new SQLHelper();
            String sp = "usp_GetStaff";
            //string sql = "SELECT" +
            //    "           StaffId," +
            //    "           FirstName,"+
            //    "           LastName," +
            //    "           Dob," +
            //    "           Phone," +
            //    "           Email," +
            //    "           Password" +
            //    "       FROM" +
            //    "           Staff" +
            //    "       WHERE" +
            //    "           AccountStatus = 'Active'";
            DataTable datatable = _db.ExecuteSQL(sp);
            foreach (DataRow dr in datatable.Rows)
            {
                Coordinator newCoordinator = new Coordinator(dr);
                this.Add(newCoordinator);
            }
        }

        public Coordinators(string searchText)
        {
            _db = new SQLHelper();
            string sp = "usp_SearchStaff";
            //string sql = "SELECT " +
            //             "           StaffId," +
            //             "           FirstName," +
            //             "           LastName," +
            //             "           Dob," +
            //             "           Phone," +
            //             "           Email," +
            //             "           Password " +
            //             "       FROM " +
            //             "           Staff " +
            //             "        WHERE " +
            //             "           AccountStatus = 'Active'" +
            //        "            AND" +
            //        "                FirstName LIKE '%"+ searchText +"%'";
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@SearchText", DbType.String);
            objParams[0].Value = searchText;
            DataTable dataTable = _db.ExecuteSQL(sp, objParams, true);
            foreach (DataRow dr in dataTable.Rows)
            {
                Coordinator newCoordinator = new Coordinator(dr);
                this.Add(newCoordinator);
            }
        }
    }
}
