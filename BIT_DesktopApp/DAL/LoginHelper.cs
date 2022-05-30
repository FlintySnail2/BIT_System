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
    public class LoginHelper
    {
        public static bool IsCoordinator(string email, string password)
        {
            SQLHelper db = new SQLHelper();
            string sql = "SELECT" +
                "           StaffType" +
                "       FROM " +
                "           Staff" +
                "       WHERE" +
                "           Email = @Username" +
                "       AND " +
                "           Password = @Password" +
                "       AND " +
                "           StaffType = 'Coordinator'";
            SqlParameter[] objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@Username", DbType.String);
            objParams[0].Value = email;
            objParams[1] = new SqlParameter("@Password", DbType.String);
            objParams[1].Value = password;
            DataTable dt = db.ExecuteSQL(sql, objParams);
            return dt.Rows.Count == 1;

            //int returnValue = db.ExecuteNonQuery(sql, objParams);
            //if (returnValue > 0)
            //{
            //    return true;
            //}
            //return false;
        }

        public static bool IsAdmin(string email, string password)
        {
            SQLHelper db = new SQLHelper();
            string sql = "SELECT " +
                "               StaffType " +
                "        FROM " +
                "           Staff " +
                "        WHERE " +
                "           Email = @Username " +
                "        AND" +
                "           Password = @Password " +
                "       AND " +
                "           StaffType = 'Administrator'";
            
            SqlParameter[] objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@Username", DbType.String);
            objParams[0].Value = email;
            objParams[1] = new SqlParameter("@Password", DbType.String);
            objParams[1].Value = password;
            DataTable dt = db.ExecuteSQL(sql, objParams);
            return dt.Rows.Count == 1;
            //int returnValue = db.ExecuteNonQuery(sql, objParams);
            //if (returnValue > 0)
            //{
            //    return true;
            //}
            //return false;
        }
    }
}
