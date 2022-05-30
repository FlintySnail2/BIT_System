using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BIT_DesktopApp.DAL;

namespace BIT_DesktopApp.Models
{
    public class AvailableContractor
    {
        private int _contractorId;
        private string _firstName;
        private string _lastName;
        private string _skillTitle;
        private string _availabilityDate;
        public SQLHelper _db;

        public int ContractorId
        {
            get { return _contractorId; }
            set { _contractorId = value; }

        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string SkillTitle
        {
            get { return _skillTitle; }
            set { _skillTitle = value; }
        }

        public string AvailabilityDate
        {
            get { return _availabilityDate; }
            set { _availabilityDate = value; }
        }

        public AvailableContractor()
        {
            _db = new SQLHelper();
        }

        public AvailableContractor(DataRow dr)
        {
            _db = new SQLHelper();
            ContractorId = Convert.ToInt32(dr["ContractorId"].ToString());
            FirstName = dr["FirstName"].ToString();
            LastName = dr["LastName"].ToString();
            SkillTitle = dr["SkillTitle"].ToString();
            AvailabilityDate = dr["AvailabilityDate"].ToString();

        }

        
    }
}
