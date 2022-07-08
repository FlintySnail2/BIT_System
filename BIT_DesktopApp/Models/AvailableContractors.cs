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
        #region Constructor

        private SQLHelper _db;


        public AvailableContractors(int contractorId)
        {
            _db = new SQLHelper();
            string sp = "usp_GetAvailableContractors";
            DataTable dt = _db.ExecuteSQL(sp);
            foreach (DataRow dr in dt.Rows)
            {
                AvailableContractor newavailableContractor = new AvailableContractor(dr);
                this.Add(newavailableContractor);
            }
        }

        //FIND AVAILABLE CONTRACTOR BASED ON CONTRACTOR SKILL AND AVAILABILITY
        public AvailableContractors(string skillReq, DateTime reqCompletion)
        {
            _db = new SQLHelper();
            string sp = "usp_FindAvailableContractorBySkill&Id";
            SqlParameter[] objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@Skill",DbType.String);
            objParams[0].Value = skillReq;
            objParams[1] = new SqlParameter("@reqCompletion", DbType.String);
            objParams[1].Value = reqCompletion;
            DataTable dt = _db.ExecuteSQL(sp,objParams, true);
            foreach (DataRow datarow in dt.Rows)
            {
                AvailableContractor newAvailableContractor = new AvailableContractor(datarow);
                Add(newAvailableContractor);
            }
        }

        #endregion Constructor
    }
}
