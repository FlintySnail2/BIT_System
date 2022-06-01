using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BIT_DesktopApp.DAL;

namespace BIT_DesktopApp.Models
{
    public class AbsentContractorSkill : List<ContractorSkill>
    {

        public AbsentContractorSkill(int contractorId)
        {
            SQLHelper db = new SQLHelper();

            string sql = @"SELECT distinct 
                            s.SkillTitle
                        From 
                            Skill s where
                            s.SkillTitle not in (select cs.SkillTitle
                        From ContractSkill cs 
                        where cs.ContractorId = @ContractorId)";
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@ContractorId", DbType.Int32);
            objParams[0].Value = contractorId;
            DataTable dataTable = db.ExecuteSQL(sql, objParams);
            foreach (DataRow dr in dataTable.Rows)
            {
                ContractorSkill absentContractorSkill = new ContractorSkill(dr);
                Add(absentContractorSkill);
            }
        }
    }
}
