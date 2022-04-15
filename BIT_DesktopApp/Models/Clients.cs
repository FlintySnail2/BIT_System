using BIT_DesktopApp.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIT_DesktopApp.Models
{
    public class Clients : List<Client>
    {
        private SQLHelper _db;

        public Clients()
        {
            _db = new SQLHelper();
            
            string sql = "SELECT " +
                "           C.Client_Id," +
                "           C.Oragnisation_Name," +
                "           C.First_Name," +
                "           C.Last_Name," +
                "           C.Phone," +
                "           C.Email," +
                "           C.Password," +
                "           R.Region_Name," +
                "           L.Street + ' ' + L.Suburb + ', ' + L.State + ', ' + CAST(L.Zip AS NVARCHAR) AS Location" +
                "       FROM" +
                "           Client AS C," +
                "           Location AS L," +
                "           Region AS R" +
                "       WHERE " +
                "           C.Client_Id = L.Client_Id " +
                "       AND " +
                "           L.Region_Name = R.Region_Name";
            DataTable dataTable = _db.ExecuteSQL(sql);
            foreach (DataRow dr in dataTable.Rows)
            {
                Client newClient = new Client(dr);
                this.Add(newClient);
            }
        }
    }
}
