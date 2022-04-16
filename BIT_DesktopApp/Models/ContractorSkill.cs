using BIT_DesktopApp.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            ContractorId = Convert.ToInt32(dr["Contractor_Id"].ToString());
            Skill = dr["Skill_Title"].ToString();
        }

        #endregion Constructor

    }
}
