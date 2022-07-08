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
    public class SystemSkill : INotifyPropertyChanged
    {
        #region Private Properties
        private string _skillName;
        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        #endregion Private Properties

        #region Public Properties 

        public SQLHelper _db;

        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();
        public string Error { get { return null; } }
        public string this[string propertyName]
        {
            get
            {
                string result = null;
                switch (propertyName)
                {
                    case "SkillName":
                        if (string.IsNullOrEmpty(SkillName))
                        {
                            result = "Field cannot be empty ";
                        }
                        
                        break;
                }
                if (result != null && !ErrorCollection.ContainsKey(propertyName))
                {
                    ErrorCollection.Add(propertyName, result);
                }
                OnPropertyChanged("ErrorCollection");
                return result;
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        public string SkillName
        {
            get { return _skillName; }
            set
            {
                _skillName = value;
                OnPropertyChanged("SkillTitle");
            }
        }

        #endregion Public Properties

        #region Constructor

        public SystemSkill()
        {
            _db = new SQLHelper();
        }

        public SystemSkill(DataRow dr)
        {
            _db = new SQLHelper();
            SkillName = dr["SkillTitle"].ToString();
        }

        public string InsertSystemSkill()
        {
            string sp = "usp_InsertSystemSkill";
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@Skill", DbType.String);
            objParams[0].Value = SkillName;
            int rowsAffected = _db.ExecuteNonQuery(sp, objParams, true);
            if (rowsAffected >= 1)
            {
                return "Skill Successfully Added";
            }
            return " Unable to to add skill, please try again later";
        }

        #endregion Constructor
    }
}
