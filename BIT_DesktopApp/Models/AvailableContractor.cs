using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BIT_DesktopApp.DAL;

namespace BIT_DesktopApp.Models
{
    public class AvailableContractor : INotifyPropertyChanged
    {
        private int _contractorId;
        private string _firstName;
        private string _lastName;
        private string _skillTitle;
        private string _availabilityDate;
        private string _contractorRating;
        public SQLHelper _db;
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
            set
            {
                _contractorId = value;

            }
            
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        public string SkillTitle
        {
            get { return _skillTitle; }
            set
            {
                _skillTitle = value; 
                OnPropertyChanged("SkillTitle");
            }
        }

        public string AvailabilityDate
        {
            get { return _availabilityDate; }
            set
            {
                _availabilityDate = value;
                OnPropertyChanged("AvailabilityDate");
            }
        }

        public string ContractorRating
        {
            get { return _contractorRating; }
            set
            {
                _contractorRating = value;
                OnPropertyChanged("ContractorRating");
            }
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
            ContractorRating = dr["ContractorRating"].ToString();

        }

        
    }
}
