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
    public class Clients : List<Client>
    {
        private SQLHelper _db;

        #region Constructor
        public Clients()
        {
            _db = new SQLHelper();

            string sp = "usp_GetAllClients";
            DataTable dataTable = _db.ExecuteSQL(sp);
            foreach (DataRow dr in dataTable.Rows)
            {
                Client newClient = new Client(dr);
                this.Add(newClient);
            }
        }

        public Clients(string searchText)
        {
            _db = new SQLHelper();
            string sp = "usp_SearchClients";
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@searchText", DbType.String);
            objParams[0].Value = searchText;
            DataTable dataTable = _db.ExecuteSQL(sp, objParams, true);
            foreach (DataRow dr in dataTable.Rows)
            {
                Client newClient = new Client(dr);
                this.Add(newClient);
            }
        }
        #endregion Constructor

    }
}
