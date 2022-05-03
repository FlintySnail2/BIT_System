using BIT_WebApplication.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BIT_WebApplication.BLL
{
    public class User
    {

        #region Private Properties
        public string Email { get; set; }
        public string Password { get; set; }

        #endregion Private Properties

        public SQLHelper _db;

        public User()
        {
            _db = new SQLHelper();
        }

        public int CheckCLient()
        {
            string sql = "SELECT" +
                "           Client_Id" +
                "         FROM" +
                "           Client" +
                "         WHERE" +
                "           Email = @Email" +
                "         AND" +
                "           Password = @Password ";
            SqlParameter[] objParmas = new SqlParameter[2];
            objParmas[0] = new SqlParameter("@Email", DbType.String);
            objParmas[0].Value = Email;
            objParmas[1] = new SqlParameter("@Password", DbType.String);
            objParmas[1].Value = Password;
            DataTable dt = _db.ExecuteSQL(sql, objParmas);
            int id = -1;
            if (dt.Rows.Count > 0)
            {
                id = Convert.ToInt32(dt.Rows[0][0]);

            }
            return id;
        }

        public int CheckContractor()
        {
            string sql = "SELECT" +
                "           Contractor_Id" +
                "         FROM" +
                "           Contractor" +
                "         WHERE" +
                "           Email = @Email" +
                "         AND" +
                "           Password = @Password ";
            SqlParameter[] objParmas = new SqlParameter[2];
            objParmas[0] = new SqlParameter("@Email", DbType.String);
            objParmas[0].Value = Email;
            objParmas[1] = new SqlParameter("@Password", DbType.String);
            objParmas[1].Value = Password;
            DataTable dt = _db.ExecuteSQL(sql, objParmas);
            int id = -1;
            if (dt.Rows.Count > 0)
            {
                id = Convert.ToInt32(dt.Rows[0][0]);

            }
            return id;
        }
    }
}