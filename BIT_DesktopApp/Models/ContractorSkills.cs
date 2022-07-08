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
        #region Constructor

        public ContractorSkills(int contractorId)
        {
            SQLHelper db = new SQLHelper();
            string sp = "usp_GetContractorSkillsById";
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@ContractorId", DbType.Int32);
            objParams[0].Value = contractorId;
            DataTable dataTable = db.ExecuteSQL(sp, objParams, true);
            foreach (DataRow dr in dataTable.Rows)
            {
                ContractorSkill contractorSkill = new ContractorSkill(dr);
                this.Add(contractorSkill);
            }
        }

        public ContractorSkills()
        {
            SQLHelper db = new SQLHelper();
            string sp = "usp_GetContractorSkills";
            DataTable contractorSkills = db.ExecuteSQL(sp);
            foreach (DataRow dr in contractorSkills.Rows)
            {
                ContractorSkill contractorSkill = new ContractorSkill(dr);
                this.Add(contractorSkill);
            }
        }

        #endregion Constructor
    }
}
