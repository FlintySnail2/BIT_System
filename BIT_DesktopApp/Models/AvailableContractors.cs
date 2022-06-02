using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BIT_DesktopApp.DAL;

namespace BIT_DesktopApp.Models
{
    public class AvailableContractors : List<AvailableContractor>
    {
        private SQLHelper _db;


        public AvailableContractors(string skillReq, DateTime reqCompletion)
        {
            _db = new SQLHelper();

            string findSql = "SELECT" + 
                         " CON.ContractorId,  " +
                     "  CON.FirstName," +
                     "  CON.LastName," +
                     "  CS.SkillTitle," +
                     "  A.AvailabilityDate," + 
                         "CON.ContractorRating " +
                     " FROM" +
                     "  Contractor AS CON," +
                     "  Availability AS A," +
                     "  ContractSkill AS CS" +
                     " WHERE" +
                     "  CS.ContractorId = CON.ContractorId" +
                     " AND" +
                     "  CON.ContractorId = A.ContractorId" +
                    " AND" +
                         " CS.SkillTitle = @Skill" +
                "     AND" +
                         " A.AvailabilityDate = @reqCompletion";
            SqlParameter[] objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@Skill",DbType.String);
            objParams[0].Value = skillReq;
            objParams[1] = new SqlParameter("@reqCompletion", DbType.String);
            objParams[1].Value = reqCompletion;
            DataTable dt = _db.ExecuteSQL(findSql,objParams);
            foreach (DataRow datarow in dt.Rows)
            {
                AvailableContractor newAvailableContractor = new AvailableContractor(datarow);
                Add(newAvailableContractor);
            }


        }
    }
}
