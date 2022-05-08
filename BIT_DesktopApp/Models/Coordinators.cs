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
                "           StaffId," +
                "           FirstName + ' ' + LastName AS EmployeeName," +
                "           Dob," +
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
                "           FirstName," +
                "           LastName," +
                "        FROM" +
                "           Staff" +
                "        WHERE" +
                "           FirstName LIKE '%" + searchText + "%'" +
                "           LastName LIKE '%" + searchText + "%'";
            DataTable dataTable = _db.ExecuteSQL(sql);
            foreach (DataRow dr in dataTable.Rows)
            {
                Coordinator newCoordinator = new Coordinator();
                this.Add(newCoordinator);
            }
        }
    }
}
