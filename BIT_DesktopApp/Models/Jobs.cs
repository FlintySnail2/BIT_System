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
                "           J.Job_Id," +
                "           C.Oragnisation_Name," +
                "           C.First_Name + ' ' + C.Last_Name as Contact_Name," +
                "           J.Description," +
                "           J.Skill_Title," +
                "           J.Priority," +
                "           C.Phone," +
                "           J.QuotedHours," +
                "           J.ActualHours," +
                "           FORMAT(J.RequestedCompletionDate, 'dd-MM-yyyy') AS RequestedCompletionDate," +
                "           FORMAT(J.CompletionDate, 'dd-MM-yyyy') AS CompletionDate," +
                "           J.DistanceTravelled," +
                "           L.Street + ' ' + L.Suburb + ', ' + L.State + ', ' + CAST(L.Zip AS NVARCHAR) AS Location" +
                "       FROM" +
                "           Job AS J," +
                "           Client AS C," +
                "           Location AS L," +
                "           Region AS R" +
                "       WHERE" +
                "           J.Client_Id = C.Client_Id" +
                "       AND" +
                "           C.Client_Id = L.Client_Id" +
                "       AND " +
                "           L.Region_Name = R.Region_Name";
            DataTable datatable = _db.ExecuteSQL(sql);
            foreach (DataRow dr in datatable.Rows)
            {
                Job newJob = new Job(dr);
                this.Add(newJob);
            }        
        }
    }
}
