using BIT_DesktopApp.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIT_DesktopApp.Models
{
    public class ContractorSkill : INotifyPropertyChanged
    {
        #region Properties

        private int _contractorId;
        private string _skill;
        private SQLHelper _db;
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        public int ContractorId
        {
            get { return _contractorId; }
            set { _contractorId = value; }
        }

        public string Skill
        {
            get { return _skill; }
            set { _skill = value;
                OnPropertyChanged("Skill");
            }
        }
        #endregion Properties

        #region Constructor

        public ContractorSkill()
        {
            _db = new SQLHelper();
        }

        public ContractorSkill(DataRow dr)
        {
            _db = new SQLHelper();
            ContractorId = Convert.ToInt32(dr["ContractorId"].ToString());
            Skill = dr["SkillTitle"].ToString();
        }

        #endregion Constructor

        #region Public Methods

        public int InsertNewSkill(int contractorId)
        {
            int returnValue = 0;
            string sql = "INSERT INTO" +
                "               ContractSkill" +
                "         VALUES(" +
                "               @ContractorId, @Skill ";
            SqlParameter[] objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@ContractorId", DbType.Int32);
            objParams[0].Value = contractorId;
            objParams[1] = new SqlParameter("Skill", DbType.String);
            objParams[1].Value = this.Skill;
            returnValue = _db.ExecuteNonQuery(sql, objParams);
            return returnValue;

            

        }

        public int DeleteSkill(int contractorId)
        {
            int returnValue = 0;
            string sql = "DELETE FROM" +
                "               Contract_Skill" +
                "         WHERE" +
                "               ContractorId = @ContractorId" +
                "         AND   " +
                "               Skill_Title = @Skill";
            SqlParameter[] objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@ContractorId", DbType.Int32);
            objParams[0].Value = contractorId;
            objParams[1] = new SqlParameter("@Skill", DbType.String);
            objParams[1].Value= this.Skill;
            returnValue = _db.ExecuteNonQuery(sql, objParams);
            return returnValue;

        }

        #endregion Public Methods

    }
}
