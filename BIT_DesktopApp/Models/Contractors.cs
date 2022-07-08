using BIT_DesktopApp.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data.SqlClient;

namespace BIT_DesktopApp.Models
{
    public class Contractors : List<Contractor>
    {

        private SQLHelper _db;

        #region Constructor

        public Contractors()
        {
            _db = new SQLHelper();
            string sp = "usp_GetContractors";
            DataTable datatable = _db.ExecuteSQL(sp);
            foreach (DataRow dr in datatable.Rows)
            {
                Contractor newContractor = new Contractor(dr);
                this.Add(newContractor);
            }
		}

        public Contractors(string searchText)
        {
            _db = new SQLHelper();
            string sp = "usp_SearchContractors";
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@SearchText", DbType.String);
            objParams[0].Value = searchText;
            DataTable dataTable = _db.ExecuteSQL(sp, objParams, true);
            foreach (DataRow dr in dataTable.Rows)
            {
                Contractor newContractor = new Contractor(dr);
                this.Add(newContractor);
            }
        }
        #endregion Constructor

    }
}
