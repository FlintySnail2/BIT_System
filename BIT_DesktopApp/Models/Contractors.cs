using BIT_DesktopApp.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Added by Peter P
using System.Diagnostics;

namespace BIT_DesktopApp.Models
{
    public class Contractors : List<Contractor>
    {

        private SQLHelper _db;

        public Contractors()
        {
            _db = new SQLHelper();
            string sql = "SELECT " +
                "           C.ContractorId," +
                "           C.FirstName," +
                "           C.LastName, " +            
                "           C.Dob," +
                "           C.Street," +
                "           C.Suburb, " +
                "           C.State, " +
                "           C.Zip," +
                "           C.Phone," +
                "           C.Email,    " +
                "           C.ABN," +
                "           C.LicenceNumber," +
                "           C.RateofPay," +
                "           C.ContractorRating" +
                "       FROM" +
                "           Contractor AS C" +
                "       WHERE " +
                "          AccountStatus = 'Active'";
            DataTable datatable = _db.ExecuteSQL(sql);
            foreach (DataRow dr in datatable.Rows)
            {
                Contractor newContractor = new Contractor(dr);
                this.Add(newContractor);
            }

		}

        public Contractors(string searchText)
        {
            _db = new SQLHelper();
            string sql = "SELECT DISTINCT" +
                "           C.ContractorId," +
                "           C.FirstName," +
                "           C.LastName, " +
                "           c.dob," +
                "           c.street," +
                "           c.suburb, " +
                "           c.state, " +
                "           c.zip," +
                "           c.phone," +
                "           c.email,    " +
                "           c.abn," +
                "           c.licencenumber," +
                "           c.rateofpay," +
                "           C.ContractorRating, " +
            "               S.SkillTitle " +
                "           FROM" +
                "               ContractSkill AS S," +
                "               Contractor AS C" +
                "           WHERE" +
                "               S.ContractorId = C.ContractorId" +
                "           AND     " +
                "               C.FirstName  LIKE '%" + searchText + "%' ";
            DataTable dataTable = _db.ExecuteSQL(sql);
            foreach (DataRow dr in dataTable.Rows)
            {
                Contractor newContractor = new Contractor(dr);
                this.Add(newContractor);
            }

        }

    }
}
