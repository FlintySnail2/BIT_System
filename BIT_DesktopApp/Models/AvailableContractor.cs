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
        private DateTime _availabilityDate;
        private string _contractorRating;
        private Decimal _rateOfPay;
        private string _phone;
        private string _email;
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

        public DateTime AvailabilityDate
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

        public decimal RateOPay
        {
            get { return _rateOfPay; }
            set { _rateOfPay = value;
                OnPropertyChanged("RateOfPay");
            }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value;
            OnPropertyChanged("Phone");}
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
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
            AvailabilityDate = Convert.ToDateTime(dr["AvailabilityDate"].ToString());
            ContractorRating = dr["ContractorRating"].ToString();
            RateOPay = Convert.ToDecimal(dr["RateOfPay"].ToString());
            Phone = dr["Phone"].ToString();
            Email = dr["Email"].ToString();

        }

        
    }
}
