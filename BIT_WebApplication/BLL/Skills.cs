using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BIT_WebApplication.DAL;

namespace BIT_WebApplication.BLL
{
    public class Skills
    {

        public static DataTable GetAllSkills()
        {
            string sql = "SELECT" +
                         " SkillTitle" +
                         " FROM" +
                         " ContractSkill";
            SQLHelper _db = new SQLHelper();
            DataTable skills = _db.ExecuteSQL(sql);
            return skills;

        }
    }
}