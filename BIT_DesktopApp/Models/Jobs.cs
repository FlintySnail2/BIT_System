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
            string sql = "SELECT" +
                "           J.JobId," +
                "           C.OrganisationName AS [Organisation Name]," +
                "           C.FirstName + ' ' + C.LastName as [Contact Name]," +
                "           J.Description," +
                "           J.SkillTitle AS [Skill Required]," +
                "           J.Priority," +
                "           S.Status," +
                "           C.Phone," +
                "           J.HoursOnJob AS [Hours On Job]," +
                "           CONVERT(NVARCHAR, J.RequestedCompletionDate, 6) AS [Requested Completion]," +
                "           J.DistanceTravelled AS [Distance Travelled]," +
                "           L.Street + ' ' + L.Suburb + ', ' + L.State + ', ' + CAST(L.Zip AS NVARCHAR) AS Location" +
                "       FROM" +
                "           Job AS J," +
                "           Client AS C," +
                "           Location AS L," +
                "           Status AS S" +
                "       WHERE" +
                "           J.ClientId = C.ClientId" +
                "       AND J.ClientId = L.ClientId" +
                "       AND J.Status = S.Status" +
                "       AND J.Status = 'Completed'";

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
