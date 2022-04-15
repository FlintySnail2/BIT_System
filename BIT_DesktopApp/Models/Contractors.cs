using BIT_DesktopApp.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIT_DesktopApp.Models
{
    public class Contractors : List<Contractor>
    {

        private SQLHelper _db;

        public Contractors()
        {
            _db = new SQLHelper();
            string sql = "SELECT" +
                "           C.Contractor_Id," +
                "           C.First_Name + ' ' + C.Last_Name AS ContractorName," +
                "           C.Dob," +
                "           C.Street + ' ' + C.Suburb + ', ' + C.State + ', ' + CAST(C.Zip AS NVARCHAR) AS Address," +
                "           C.Phone," +
                "           C.Email,    " +
                "           C.Password," +
                "           J.Skill_Title," +
                "           C.ABN," +
                "           C.Licence_Number," +
                "           C.Rateof_Pay," +
                "           C.Contractor_Rating" +
                "       FROM" +
                "           Contractor AS C," +
                "           Job AS J" +
                "       WHERE" +
                "           C.Contractor_Id = J.Contractor_Id;";
            DataTable datatable = _db.ExecuteSQL(sql);
            foreach (DataRow dr in datatable.Rows)
            {
                Contractor newContractor = new Contractor(dr);
                this .Add(newContractor);
            }

		}

    }
}
