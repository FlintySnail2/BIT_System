using BIT_DesktopApp.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIT_DesktopApp.Models
{
    public class ContractorSkills : List<ContractorSkill>
    {
        

        public ContractorSkills(int contractorId)
        {
            SQLHelper db = new SQLHelper();
            string sql = "SELECT" +
                "         ContractorId," +
                "           SkillTitle" +
                "         FROM" +
                "           ContractSkill" +
                "         WHERE" +
                "           ContractorId = @ContractorId";
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@ContractorId", DbType.Int32);
            objParams[0].Value = contractorId;
            DataTable dataTable = db.ExecuteSQL(sql, objParams);
            foreach (DataRow dr in dataTable.Rows)
            {
                ContractorSkill contractorSkill = new ContractorSkill(dr);
                this.Add(contractorSkill);
            }
        }

        public ContractorSkills()
        {
            SQLHelper db = new SQLHelper();
            string sql = "SELECT" +             //Pulling Status from job table 
                "           C.Contractor," +    //Causes a crash "SAD FACE"
                "           J.SkillTitle" +
                "         FROM" +
                "           Job AS J," +
                "           Contractor AS C" +
                "         WHERE " +
                "            C.ContractorId = J.ContractorId";
            DataTable contractorSkills = db.ExecuteSQL(sql);
            foreach (DataRow dr in contractorSkills.Rows)
            {
                ContractorSkill contractorSkill = new ContractorSkill(dr);
                this.Add(contractorSkill);
            }
        }
    }
}
