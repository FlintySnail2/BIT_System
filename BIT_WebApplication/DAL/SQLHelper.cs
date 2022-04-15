using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BIT_WebApplication.DAL
{
    public class SQLHelper
    {
        private string _conn;

        public SQLHelper()
        {
            _conn = ConfigurationManager.ConnectionStrings["BIT"].ConnectionString;
        }

        public DataTable ExecuteSQL(String sql, SqlParameter[] parameters = null, bool storedProcedure = false)
        {
            DataTable dataTable = new DataTable();
            SqlConnection dbConnection = new SqlConnection(_conn);
            SqlCommand dbCommand = new SqlCommand(sql, dbConnection);

            dbConnection.Open();
            if (storedProcedure == true)
            {
                dbCommand.CommandType = CommandType.StoredProcedure;
            }
            if (parameters != null)
            {
                AddParameters(dbCommand, parameters);
            }
            //Generates some exceptions

            SqlDataReader drResults = dbCommand.ExecuteReader(CommandBehavior.CloseConnection);

            dataTable.Load(drResults);
            dbConnection.Close();
            return dataTable;
        }

        public int ExecuteNonQuery(string sql, SqlParameter[] parameters = null, bool storedProcedure = false)
        {
            int returnValue =-1;
            SqlConnection dbConnection = new SqlConnection(_conn);
            SqlCommand dbCommand = new SqlCommand(sql, dbConnection);

            if (storedProcedure == true)
            {
                dbCommand.CommandType |= CommandType.StoredProcedure;
            }
            if (parameters != null)
            {
                AddParameters(dbCommand, parameters);
            }

            dbConnection.Open();
            returnValue = dbCommand.ExecuteNonQuery();
            dbConnection.Close();
            return returnValue;
        }
    }
}