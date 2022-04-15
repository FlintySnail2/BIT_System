using BIT_WebApplication.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BIT_WebApplication.BLL
{
    public class Client
    {
        public int ClientId { get; set; }
        public string OrganisationName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }   
        public string Password { get; set; }
        private SQLHelper _db;

        public Client()
        {
            _db = new SQLHelper();
        }

        public DataTable AllClientJobs()
        {
            string sql = "SELECT *" +
                "         FROM" +
                "           Client" +
                "         WHERE" +
                "           clientId = @ClientId";
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@ClientId", DbType.Int32);
            objParams[0].Value = this.ClientId;
            DataTable jobs = _db.ExecuteSQL(sql, objParams);
            return jobs;
        }
    }
}