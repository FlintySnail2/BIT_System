using BIT_DesktopApp.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIT_DesktopApp.Models
{
    public class Jobs : List<Job>
    {
        private SQLHelper _db;

        public Jobs()
        {
            _db = new SQLHelper();
            string sql = "SELECT DISTINCT" +
                "           J.JobId," +
                "           C.OrganisationName AS [Organisation Name]," +
                "           C.FirstName + ' ' + C.LastName as [Contact Name]," +
                "           J.Description," +
                "           J.SkillTitle AS [Skill Title]," +
                "           J.Priority," +
                "           S.Status," +
                "           C.Phone," +
                "           J.HoursOnJob," +
                "           FORMAT(J.RequestedCompletionDate, 'dd-MM-yyyy') AS [Requested Completion]," +
                "           J.DistanceTravelled," +
                "           L.Street + ' ' + L.Suburb + ', ' + L.State + ', ' + CAST(L.Zip AS NVARCHAR) AS Location" +
                "       FROM" +
                "           Job AS J," +
                "           Client AS C," +
                "           Location AS L," +
                "           Status AS S" +
                "       WHERE" +
                "           J.ClientId = C.ClientId" +
                "       AND J.Region = L.Region" +
                "       AND J.Status = S.status";

            DataTable datatable = _db.ExecuteSQL(sql);
            foreach (DataRow dr in datatable.Rows)
            {
                Job newJob = new Job(dr);
                this.Add(newJob);
            }        
        }

        public Jobs(string searchText)
        {
            _db = new SQLHelper();
            string sql = "SELECT" +
                "               Priority," +
                "               Status," +
                "               SkillTitle" +
                "       FROM" +
                "           Job" +
                "       WHERE" +
                "           Priority LIKE '%" + searchText + "%'";
                //"       OR" +
                //"           Status LIKE '%" + searchText + "%'" +
                //"       OR " +
                //"           SkillTitle LIKE '%" + searchText + "%'";
            DataTable dataTable = _db.ExecuteSQL(sql);
            foreach (DataRow dr in dataTable.Rows)
            {
                Job newJob = new Job(dr);
                this.Add(newJob);
            }
        }
    }
}
