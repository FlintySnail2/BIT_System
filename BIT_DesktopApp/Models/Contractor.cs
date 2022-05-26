using BIT_DesktopApp.DAL;
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
        private string _availabilty {get; set;}
        private string _abn { get; set; }
        private string _licenceNumber { get; set; }
        private decimal _ratOfPay { get; set; }
        private string _contractorRating { get; set; }
        public SQLHelper _db;
        public event PropertyChangedEventHandler PropertyChanged;
        public Dictionary<string,string> ErrorCollection { get; private set; }
        public string Error { get { return null; } }
        public string this[string propertyName]
        {
            get
            {
                string result = null;
                switch (propertyName)
                {
                    case "ContractorName":
                        if (string.IsNullOrEmpty(ContractorName))
                        {
                            result = "Field cannot be left empty";
                        }
                        break;
                    case "Address":
                        if (string.IsNullOrEmpty(Address))
                        {
                            result = "Field cannot be left empty";
                        }
                        break;
                    case "Phone":
                        if (string.IsNullOrEmpty(Phone))
                        {
                            result = "Field cannot be empty";
                        }
                        break;
                    case "Dob":
                        if (Dob.Year > 1945)
                        {
                            result = "You are to old to work here";
                        }
                        break;
                    case "Email":
                        if (string.IsNullOrEmpty(Email))
                        {
                            result = "Field cannot be empty";
                        }
                        break;
                    case "Availability":
                        if (string.IsNullOrEmpty(Availibility))
                        {
                            result = "Field cannot be left empty";
                        }
                        break;
                    case "ABN":
                        if (string.IsNullOrEmpty(ABN))
                        {
                            result = "Field cannot be left empty";
                        }
                        break;
                    case "LicenceNumber":
                        if (string.IsNullOrEmpty(ABN))
                        {
                            result = "Field cannot be empty";
                        }
                        break;
                    case "RateOfPay":
                        if (int.TryParse(ABN, out int test))
                        {
                            result = "field cannot be empty";
                        }
                        break;
                    case "ContractorRating":
                        if (string.IsNullOrEmpty(ContractorRating))
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

        public string FirstName
        {
            get { return _firstName;}
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

        public string ABN
        {
            get { return _abn;}
            set { _abn = value;
                OnPropertyChanged("ABN");

            }
        }

        public string Availibility
        {
            get { return _availabilty; }
            set
            {
                _availabilty = value;
                OnPropertyChanged("Availibility");
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
            Availibility = dr["Availability"].ToString();
            ABN = dr["ABN"].ToString();
            LicenceNumber = dr["LicenceNumber"].ToString();
            RateOfPay = Convert.ToDecimal(dr["RateofPay"].ToString());
            ContractorRating = dr["ContractorRating"].ToString();
        }


        #endregion Contructor

        #region Public Methods

        public string InsertContractor()
        {
            string insertSql = "INSERT INTO " +
                               "    Contractor(" +
                               "    FirstName," +
                               "    LastName," +
                               "    Street," +
                               "    Suburb," +
                               "    State," +
                               "    Zip," +
                               "    Phone," +
                               "    Dob," +
                               "    Email," +
                               "    Password," +
                               "    ABN," +
                               "    LicenceNumber," +
                               "    RateofPay," +
                               "    ContractorRating," +
                               "    AccountStatus)" +
                               "VALUES(" +
                               "    @FirstName," +
                               "    @LastName," +
                               "    @Street," +
                               "    @Suburb," +
                               "    @State," +
                               "    @Zip," +
                               "    @Phone," +
                               "    @Dob," +
                               "    @Email," +
                               "    @Password," +
                               "    @ABN," +
                               "    @LicenceNumber," +
                               "    @RateofPay," +
                               "    '0'," + //A NEW CONTRACTOR STARTS WITH A RATING OF ZERO (HASNT BEEN RATED YET)
                               "    'Active')";
            string insertSql2 = "INSERT INTO " +
                                "   ContractSkill(" +
                                "       SkillTitle)" +
                                "VALUES(" +
                                "       @SkillTitle)" +
                                "WHERE" +
                                "   ContractorId = @ContractorId";
            SqlParameter[] objParams = new SqlParameter[15];
            objParams[0] = new SqlParameter("FirstName", DbType.String);
            objParams[0].Value = ContractorName.Split(' ')[0];
            objParams[1] = new SqlParameter("@LastName", DbType.String);
            objParams[1].Value = ContractorName.Split(' ')[1];
            objParams[2] = new SqlParameter("@Street", DbType.String);
            objParams[2].Value = Street;
            objParams[3] = new SqlParameter("@State", DbType.String);
            objParams[3].Value = State;
            objParams[4] = new SqlParameter("@Zip", DbType.String);
            objParams[4].Value = Zip;
            objParams[5] = new SqlParameter("@Phone", DbType.String);
            objParams[5].Value = Phone;
            objParams[6] = new SqlParameter("@Email", DbType.String);
            objParams[6].Value = Email;
            objParams[7] = new SqlParameter("@Password", DbType.String);
            objParams[7].Value = Password;
            objParams[8] = new SqlParameter("@ABN", DbType.String);
            objParams[8].Value = ABN;
            objParams[9] = new SqlParameter("@LicenceNumber", DbType.String);
            objParams[9].Value = LicenceNumber;
            objParams[10] = new SqlParameter("@RateofPay", DbType.String);
            objParams[10].Value = RateOfPay;
            int rowsAffectedContractor = _db.ExecuteNonQuery(insertSql, objParams);




            int Ro
            if (rowsAffected >= 1 && ContractorSkill >=1)
            {
                return "Coordinator Successfully Added";
            }
            //CONDITION FOR IF ONE OR THE OTHER DOESN'T PASS ROW

            return "Unable to add coordinator, please try again later";
        }

        #endregion Public Methods
    }
}
