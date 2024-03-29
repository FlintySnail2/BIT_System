﻿using BIT_DesktopApp.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace BIT_DesktopApp.Models
{
    public class Contractor : INotifyPropertyChanged, IDataErrorInfo
    {
        #region Private Properties

        private int _contractorId { get; set; }
        private string _contractorName { get; set; }
        private string _firstName { get; set; }
        private string _lastName { get; set; }
        private string _address { get; set; }
        private string _street { get; set; }
        private string _suburb { get; set; }
        private string _state { get; set; }
        private string _zip { get; set; }
        private string _phone { get; set; }
        private DateTime _dob { get; set; }
        private string _email { get; set; }
        private string _password { get; set; }
        private string _availabilty { get; set; }
        private string _abn { get; set; }
        private string _licenceNumber { get; set; }
        private decimal _ratOfPay { get; set; }
        private string _contractorRating { get; set; }
        private string _skillTitle { get; set; }
        public SQLHelper _db;
        public event PropertyChangedEventHandler PropertyChanged;
        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();
        public string Error { get { return null; } }
        public string this[string propertyName]
        {
            get
            {
                string result = null;
                switch (propertyName)
                {
                    case "FirstName":
                        if (string.IsNullOrEmpty(FirstName))
                        {
                            result = "Field cannot be left empty";
                        }
                        break;
                    case "LastName":
                        if (string.IsNullOrEmpty(LastName))
                        {
                            result = "Field cannot be left empty";
                        }
                        break;
                    case "Dob":
                        if (Dob == DateTime.MinValue )
                        {
                            result = "Field Cannot be null";
                        }
                        break;
                    case "Phone":
                        if (string.IsNullOrEmpty(Phone))
                        {
                            result = "Field cannot be empty";
                        }
                        break;

                    case "Email":
                        if (string.IsNullOrEmpty(Email))
                        {
                            result = "Field cannot be empty";
                        }
                        break;
                    case "LicenceNumber":
                        if (string.IsNullOrEmpty(LicenceNumber))
                        {
                            result = "Field cannot be empty";
                        }
                        break;
                    case "Password":
                        if (string.IsNullOrEmpty(Password))
                        {
                            result = "Field cannot be empty";
                        }
                        break;
                    case "ABN":
                        if (string.IsNullOrEmpty(ABN))
                        {
                            result = "Field cannot be left empty";
                        }
                        break;
                    case "SkillTitle":
                        if (string.IsNullOrEmpty(SkillTitle))
                        {
                            result = "Field cannot be left empty";
                        }
                        break;

                    case "RateOfPay":
                        if (RateOfPay.Equals(null))
                        {
                            result = "field cannot be empty";
                        }
                        break;
                    case "Street":
                        if (string.IsNullOrEmpty(Street))
                        {
                            result = "Field cannot be left empty";
                        }
                        break;
                    case "Suburb":
                        if (string.IsNullOrEmpty(Suburb))
                        {
                            result = "Field cannot be empty";
                        }
                        break;
                    case "State":
                        if (string.IsNullOrEmpty(State))
                        {
                            result = "Field cannot be empty";
                        }
                        break;
                    case "Zip":
                        if (string.IsNullOrEmpty(Zip))
                        {
                            result = "Field cannot be empty";
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


        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        #endregion Private Properties

        #region Public Properties

        public int ContractorId
        {
            get { return _contractorId; }
            set { _contractorId = value; }
        }

        public string ContractorName
        {
            get { return _contractorName; }
            set
            {
                _contractorName = value;
                OnPropertyChanged("Contractor Name");

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
        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged("Street");
            }
        }

        public string Street
        {
            get { return _street; }
            set
            {
                _street = value;
                OnPropertyChanged("Street");
            }
        }

        public string Suburb
        {
            get { return _suburb; }
            set
            {
                _suburb = value;
                OnPropertyChanged("Suburb");
            }
        }

        public string State
        {
            get { return _state; }
            set
            {
                _state = value;
                OnPropertyChanged("State");
            }
        }

        public string Zip
        {
            get { return _zip; }
            set
            {
                _zip = value;
                OnPropertyChanged("Zip");
            }
        }
        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertyChanged("Phone");

            }
        }

        public DateTime Dob
        {
            get { return _dob; }
            set
            {
                _dob = value;
                OnPropertyChanged("Dob");
            }
        }

        public string DobFormat => _dob.ToShortDateString();

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

        public string ABN
        {
            get { return _abn; }
            set
            {
                _abn = value;
                OnPropertyChanged("ABN");

            }
        }

        public string Availability
        {
            get { return _availabilty; }
            set
            {
                _availabilty = value;
                OnPropertyChanged("Availability");
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
            set
            {
                _contractorRating = value;
                OnPropertyChanged("Contractor Rating");
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
            FirstName = dr["FirstName"].ToString();
            LastName = dr["LastName"].ToString();
            Street = dr["Street"].ToString();
            Suburb = dr["Suburb"].ToString();
            State = dr["State"].ToString();
            Zip = dr["Zip"].ToString();
            Phone = dr["Phone"].ToString();
            Dob = Convert.ToDateTime(dr["Dob"].ToString());
            Email = dr["Email"].ToString();
            ABN = dr["ABN"].ToString();
            LicenceNumber = dr["LicenceNumber"].ToString();
            RateOfPay = Convert.ToDecimal(dr["RateofPay"].ToString());
            ContractorRating = dr["ContractorRating"].ToString();
        }


        #endregion Contructor

        #region Public Methods

        public string InsertContractor()
        {
            string sp = "usp_InsertContractor";
            SqlParameter[] objParams = new SqlParameter[13];
            objParams[0] = new SqlParameter("@FirstName", DbType.String);
            objParams[0].Value = FirstName;
            objParams[1] = new SqlParameter("@LastName", DbType.String);
            objParams[1].Value = LastName;
            objParams[2] = new SqlParameter("@Street", DbType.String);
            objParams[2].Value = Street;
            objParams[3] = new SqlParameter("@Suburb", DbType.Int32);
            objParams[3].Value = Suburb;
            objParams[4] = new SqlParameter("@State", DbType.String);
            objParams[4].Value = State;
            objParams[5] = new SqlParameter("@Zip", DbType.String);
            objParams[5].Value = Zip;
            objParams[6] = new SqlParameter("@Phone", DbType.String);
            objParams[6].Value = Phone;
            objParams[7] = new SqlParameter("@Dob", DbType.Date);
            objParams[7].Value = Dob;
            objParams[8] = new SqlParameter("@Email", DbType.String);
            objParams[8].Value = Email;
            objParams[9] = new SqlParameter("@Password", DbType.String);
            objParams[9].Value = Password;
            objParams[10] = new SqlParameter("@ABN", DbType.String);
            objParams[10].Value = ABN;
            objParams[11] = new SqlParameter("@LicenceNumber", DbType.String);
            objParams[11].Value = LicenceNumber;
            objParams[12] = new SqlParameter("@RateofPay", DbType.Decimal);
            objParams[12].Value = RateOfPay;
            int rowsAffectedContractor = _db.ExecuteNonQuery(sp, objParams, true);


            if (rowsAffectedContractor >= 1)
            {
                return "Contractor Successfully Added";
            }

            return "Unable to add contractor, Please try again later";
        }

        public string RemoveContractor(int contractorId)
        {
            string sp = "usp_RemoveContractor";
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@ContractorId", DbType.Int32);
            objParams[0].Value = contractorId;
            int rowsAffectedContractor = _db.ExecuteNonQuery(sp, objParams, true);
            if (rowsAffectedContractor >= 1)
            {
                return "Contractor Successfully removed ";
            }

            return "Unable to remove contractor, please try again later ";
        }

        public string UpdateContractor(int contractorId)
        {
            string sp = "usp_UpdateContractor";
            SqlParameter[] objParams = new SqlParameter[14];
            objParams[0] = new SqlParameter("@ContractorId", DbType.Int32);
            objParams[0].Value = contractorId;
            objParams[1] = new SqlParameter("@FirstName", DbType.String);
            objParams[1].Value = FirstName;
            objParams[2] = new SqlParameter("@LastName", DbType.String);
            objParams[2].Value = LastName;
            objParams[3] = new SqlParameter("@Dob", DbType.Date);
            objParams[3].Value = Dob;
            objParams[4] = new SqlParameter("@Street", DbType.String);
            objParams[4].Value = Street;
            objParams[5] = new SqlParameter("@Suburb", DbType.String);
            objParams[5].Value = Suburb;
            objParams[6] = new SqlParameter("@State", DbType.String);
            objParams[6].Value = State;
            objParams[7] = new SqlParameter("@Zip", DbType.String);
            objParams[7].Value = Zip;
            objParams[8] = new SqlParameter("@Phone", DbType.String);
            objParams[8].Value = Phone;
            objParams[9] = new SqlParameter("@Email", DbType.String);
            objParams[9].Value = Email;
            objParams[10] = new SqlParameter("@ABN", DbType.String);
            objParams[10].Value = ABN;
            objParams[11] = new SqlParameter("@LicenceNumber", DbType.String);
            objParams[11].Value = LicenceNumber;
            objParams[12] = new SqlParameter("@RateofPay", DbType.Decimal);
            objParams[12].Value = RateOfPay;
            objParams[13] = new SqlParameter("@ContractorRating", DbType.String);
            objParams[13].Value = ContractorRating;
            int rowsAffectedContractor = _db.ExecuteNonQuery(sp, objParams, true);
            if (rowsAffectedContractor >= 1)
            {
                return "Contractor successfully updated ";
            }

            return "Unable to update Contractor, please try again later ";
        }

        public string updateContractorSkills(int contractorId, string skillTitle)
        {
            string sp = "usp_UpdateContractorSkill";
            SqlParameter[] objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@ContractorId", DbType.Int32);
            objParams[0].Value = contractorId;
            objParams[1] = new SqlParameter("@SkillTitle", DbType.String);
            objParams[1].Value = skillTitle;
            int rowsAffectedContractor = _db.ExecuteNonQuery(sp, objParams, true);
            if (rowsAffectedContractor >= 1)
            {
                return "Contractor Skill Successfully Updated";
            }

            return "Unable to update contractor skill, please try again later";

        }

        public string RemoveContractorSkill(int contractorId, string skill)
        {
            string sp = "usp_RemoveContractorSkill";
            SqlParameter[] objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@ContractorId", DbType.Int32);
            objParams[0].Value = contractorId;
            objParams[1] = new SqlParameter("@SkillTitle", DbType.String);
            objParams[1].Value = skill;
            int rowsAffectedContractor = _db.ExecuteNonQuery(sp, objParams, true);
            if (rowsAffectedContractor >= 1)
            {
                return "Contractor Skill Successfully removed";
            }

            return "Unable to remove contractor skill, please try again later";
        }

        #endregion Public Methods
    }
}
