﻿using BIT_DesktopApp.DAL;
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
                "           C.ContractorId," +
                "           C.FirstName + ' ' + C.LastName AS ContractorName," +
                "           C.Dob," +
                "           C.Street + ' ' + C.Suburb + ', ' + C.State + ', ' + CAST(C.Zip AS NVARCHAR) AS Address," +
                "           A.Weekday AS Availability," +
                "           C.Phone," +
                "           C.Email,    " +
                "           C.Password," +
                "           J.SkillTitle," +
                "           C.ABN," +
                "           C.LicenceNumber," +
                "           C.RateofPay," +
                "           C.ContractorRating" +
                "       FROM" +
                "           Contractor AS C," +
                "           Job AS J," +
                "           Availability AS A" +
                "       WHERE" +
                "           C.ContractorId = J.ContractorId" +
                "       AND" +
                "           C.ContractorId = A.ContractorId;";
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
            string sql = "SELECT" +
                "               C.ContractorId," +
                "               C.FirstName," +
                "               C.LastName," +
                "               C.Contractor_Rating," +
                "               S.SkillTitle" +
                "           FROM" +
                "               Skill AS S," +
                "               Contractor AS C" +
                "           WHERE" +
                "               S.SkillTitle = C.SkillTitle" +
                "           AND     " +
                "               C.FirstName LIKE '%" + searchText + "%' " +
                "           AND" +
                "               C.LastName  LIKE '%" + searchText + "%' " +
                "           AND" +
                "               C.ContractorRating  LIKE '%" + searchText + "%'" +
                "           AND " +
                "               S.SkillTitle  LIKE '%" + searchText + "%' ";
            DataTable dataTable = _db.ExecuteSQL(sql);
            foreach (DataRow dr in dataTable.Rows)
            {
                Contractor newContractor = new Contractor(dr);
                this.Add(newContractor);
            }

        }

    }
}
