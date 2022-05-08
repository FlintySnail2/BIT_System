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
    public class Contractor : INotifyPropertyChanged
    {
        #region Private Properties

        private int _contractorId { get; set; }
        private string _contractorName { get; set; }
        private string _address { get; set; }
        private String _phone { get; set; }
        private DateTime _dob { get; set; }
        private string _email { get; set; }
        private string _password { get; set; }
        private string _abn { get; set; }
        private string _skill { get; set; }
        private string _licenceNumber { get; set; }
        private decimal _ratOfPay { get; set; }
        private string _contractorRating { get; set; }
        public SQLHelper _db;
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Private Properties

        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }


        #region Public Properties

        public int ContractorId
        {
            get { return _contractorId; }
            set { _contractorId = value; }
        }
        public string ContractorName
        {
            get { return _contractorName; }
            set { _contractorName = value;
                OnPropertyChanged("Contractor Name");

            }
        }

        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged("Street");
            }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value;
                OnPropertyChanged("Phone");

            }
        }

        public DateTime Dob
        {
            get { return _dob; }
            set { _dob = value;
                OnPropertyChanged("Dob");
            }
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

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        public string Skill
        {
            get { return _skill; }
            set
            {
                _skill = value;
                OnPropertyChanged("Skill");
            }
        }
        public string ABN
        {
            get { return _abn;}
            set { _abn = value;
                OnPropertyChanged("ABN");

            }
        }

        public string LicenceNumber
        {
            get { return _licenceNumber; }
            set
            {
                _licenceNumber = value;
                OnPropertyChanged("Licence Number");
            }
        }

        public decimal RateOfPay
        {
            get { return _ratOfPay; }
            set
            {
                _ratOfPay = value;
                OnPropertyChanged("Rate Of Pay");
            }
        }

        public string ContractorRating
        {
            get { return _contractorRating; }
            set { _contractorRating = value;
                OnPropertyChanged("Contractor Rating");

            }
        }

      

        #endregion Public Properties

        #region Constructor

        public Contractor()
        {
            _db = new SQLHelper();
        }

        public Contractor(DataRow dr)
        {
            _db = new SQLHelper();
            ContractorId = Convert.ToInt32(dr["ContractorId"].ToString());
            ContractorName = dr["ContractorName"].ToString(); 
            Address = dr["Address"].ToString();
            Phone = dr["Phone"].ToString();
            Dob = Convert.ToDateTime(dr["Dob"].ToString());
            Email = dr["Email"].ToString();
            Password = dr["Password"].ToString();
            Skill = dr["SkillTitle"].ToString();
            ABN = dr["ABN"].ToString();
            LicenceNumber = dr["LicenceNumber"].ToString();
            RateOfPay = Convert.ToDecimal(dr["RateofPay"].ToString());
            ContractorRating = dr["ContractorRating"].ToString();
        }

        #endregion Contructor

    }
}
