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
                "           Password = @Password";
            SqlParameter[] objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@username", DbType.String);
            objParams[0].Value = email;
            objParams[1] = new SqlParameter("@Password", DbType.String);
            objParams[1].Value = password;
            DataTable dt = db.ExecuteSQL(sql, objParams);
            string userType = dt.Rows[0][0].ToString();  //What if null
            if (userType == "Coordinator")
            {
                return true;
            }
            return false;
        }

        public static bool IsAdmin(string email, string password)
        {
            string sql = "SELECT " +
                "               StaffType " +
                "        FROM " +
                "           Staff " +
                "        WHERE " +
                "           Email = @Username " +
                "        AND" +
                "           Password = @Password ";
            SQLHelper db = new SQLHelper();
            SqlParameter[] objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@username", DbType.String);
            objParams[0].Value = email;
            objParams[1] = new SqlParameter("@Password", DbType.String);
            objParams[1].Value = password;
            DataTable dt = db.ExecuteSQL(sql, objParams);
            string userType = dt.Rows[0][0].ToString();
            if (userType == "Administrator")
            {
                return true;
            }
            return false;
        }
    }
}
