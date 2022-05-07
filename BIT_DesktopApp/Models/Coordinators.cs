﻿using BIT_DesktopApp.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIT_DesktopApp.Models
{
    public class Coordinators : List<Coordinator>
    {
        private SQLHelper _db;

        public Coordinators()
        {
            _db = new SQLHelper();
            string sql = "SELECT" +
                "           Staff_Id," +
                "           First_Name + Last_Name AS EmployeeName," +
                "           Dob," +
                "           Street + ' ' + Suburb + ', ' + State + ', ' + CAST(Zip AS NVARCHAR) AS Address," +
                "           Phone," +
                "           Email," +
                "           Password" +
                "       FROM" +
                "           Staff";
            DataTable datatable = _db.ExecuteSQL(sql);
            foreach (DataRow dr in datatable.Rows)
            {
                Coordinator newCoordinator = new Coordinator(dr);
                this.Add(newCoordinator);
            }
        }

        public Coordinators(string searchText)
        {
            _db = new SQLHelper();
            string sql = "SELECT" +
                "           First_Name," +
                "           Last_Name," +
                "        FROM" +
                "           Staff" +
                "        WHERE" +
                "           First_Name LIKE '%" + searchText + "%'" +
                "           Last_Name LIKE '%" + searchText + "%'";
            DataTable dataTable = _db.ExecuteSQL(sql);
            foreach (DataRow dr in dataTable.Rows)
            {
                Coordinator newCoordinator = new Coordinator();
                this.Add(newCoordinator);
            }
        }
    }
}
