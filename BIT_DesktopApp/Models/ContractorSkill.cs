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
    public class ContractorSkill : INotifyPropertyChanged, IDataErrorInfo
    {
        #region Private Properties

        private int _contractorId;
        private string _skill;
        private SQLHelper _db;
        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        #endregion Private Properties

        #region Public Properties


        public event PropertyChangedEventHandler PropertyChanged;
        public Dictionary<string,string> ErrorCollection { get; private set; } = new Dictionary<string,string>();
        public string Error { get { return null; } }
        public string this[string propertyName]
        {
            get
            {
                string result = null;
                switch (propertyName)
                {
                    case "Skill":
                        if (string.IsNullOrEmpty(_skill))
                        {
                            result = "cannot be empty";
                        }
                        break;
                }
                if (result == null && !ErrorCollection.ContainsKey(propertyName))
                {
                    ErrorCollection.Add(propertyName, result);
                }
                OnPropertyChanged("ErrorCollection");
                return result;
            }
        }

        
        public int ContractorId { get { return _contractorId; } }
        public string Skill
        {
            get { return _skill; }
            set { _skill = value;
                OnPropertyChanged("Skill");
            }
        }
        #endregion Public Properties

        #region Constructor

        public ContractorSkill()
        {
            _db = new SQLHelper();
        }

        public ContractorSkill(DataRow dr)
        {
            _db = new SQLHelper();
            //ContractorId = Convert.ToInt32(dr["ContractorId"].ToString());
            Skill = dr["SkillTitle"].ToString();
        }

        public ContractorSkill(string contractSkill)
        {
            this.Skill = contractSkill;
        }

        #endregion Constructor

    }
}
