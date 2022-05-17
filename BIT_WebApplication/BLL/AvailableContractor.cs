using BIT_WebApplication.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BIT_WebApplication.BLL
{
    public class AvailableContractor
    {
        public int ContractorId { get; set; }
        public string Availability { get; set; }
        public string Skill { get; set; }
        private SQLHelper _db;

        public AvailableContractor()
        {
            _db = new SQLHelper();
        }
  
        public DataTable GetAllAvailableContractors (string skill, string availability)
        {
            string sql = " SELECT" +
                         "      CON.FirstName + ' ' + CON.LastName As Technician," +
                         "      A.Weekday as available," +
                         "      CS.SkillTitle AS [Skill Title], " +
                         "      CON.ContractorRating AS Rating" +
                         " FROM" +
                         "      Availability as A," +
                         "      Contractor as CON, " +
                         "      ContractSkill as CS" +
                         " WHERE " +
                         "      CON.ContractorId = A.ContractorId" +
                         " AND " +
                         "      CON.ContractorId = CS.ContractorId " +
                         " AND " +
                         "      CON.AccountStatus = 'Active' " +
                         " AND" +
                         "      CS.SkillTitle = @SkillTitle " +
                         " AND" +
                         "      A.Weekday = @Availability " +
                         " ORDER BY" +
                         "      CON.ContractorRating DESC";
            SqlParameter[] objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@SkillTitle", DbType.String);
            objParams[0].Value = skill;
            objParams[1] = new SqlParameter("@Availability", DbType.String);
            objParams[1].Value = availability;
            DataTable availableContractors = _db.ExecuteSQL(sql, objParams);
            return availableContractors;
        }
    }
}