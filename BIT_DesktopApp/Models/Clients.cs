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

            string sql = "SELECT" +
                "           C.ClientId, " +
                "           C.OrganisationName," +
                "           C.FirstName + ' ' + C.LastName AS ContactName," +
                "           C.Phone," +
                "           C.Email," +
                "           L.Street + ' ' + L.Suburb + ', ' + L.State + ', ' + CAST(L.Zip AS NVARCHAR) AS Address," +
                "           L.Region" +
                "       FROM" +
                "           Client AS C," +
                "           Location AS L" +
                "       WHERE " +
                "           C.ClientId = L.ClientId " +
                "       ORDER BY C.ClientId ASC";
            DataTable dataTable = _db.ExecuteSQL(sql);
            foreach (DataRow dr in dataTable.Rows)
            {
                Client newClient = new Client(dr);
                this.Add(newClient);
            }
        }

        public Clients(string searchText)
        {
            _db = new SQLHelper();
            string sql = "SELECT" +
                "           OrganisationName," +
                "           FirstName," +
                "           LastName," +
                "       FROM" +
                "           CLient" +
                "       WHERE" +
                "           OrganisationName LIKE '%" + searchText + "%'" +
                "       AND" +
                "           FirstName LIKE '%" + searchText + "%'" +
                "       AND" +
                "           LastName LIKE '% " + searchText + "%'";
            DataTable dataTable = _db.ExecuteSQL(sql);
            foreach (DataRow dr in dataTable.Rows)
            {
                Client newClient = new Client(dr);
                this.Add(newClient);
            }
        }
        
        public Client(string deleteClient)
        {
            string sql = " UPDATE" +
                         "      Client" +
                         " SET" +
                         "      AccountStatus = 'Inactive'" +
                         " WHERE" +
                         "      ClientId = 1";
            DataTable dataTable = _db.ExecuteSQL(sql);
            foreach (DataRow dr in dataTable.Rows)
            {
                Client newClient = new Client(dr);
                this.Add(newClient);
            }

        }

    }
}
