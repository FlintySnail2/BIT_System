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
    public class SystemSkills : List<SystemSkill>
    {
        private SQLHelper _db;


        public SystemSkills(string skillName)
        {
            SQLHelper db = new SQLHelper();

            string sql = @"SELECT
                            SkillTitle
                        FROM
                            Skill
                        WHERE
                            SkillTitle = @Skill";
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@Skill", DbType.String);
            objParams[0].Value = skillName;
            DataTable dataTable = db.ExecuteSQL(sql, objParams);
            foreach (DataRow dr in dataTable.Rows)
            {
                SystemSkill systemSkill = new SystemSkill(dr);
                Add(systemSkill);
            }
        }


        public SystemSkills()
        {
            _db = new SQLHelper();

            string sql = @"SELECT
                            SkillTitle
                        FROM
                            Skill";
            DataTable dataTable = _db.ExecuteSQL(sql);
            foreach (DataRow dr in dataTable.Rows)
            {
                SystemSkill newSystemSkill = new SystemSkill(dr);
                this.Add(newSystemSkill);
            }
        }
        

    }
}
