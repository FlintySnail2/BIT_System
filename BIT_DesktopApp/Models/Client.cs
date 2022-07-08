 using BIT_DesktopApp.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BIT_DesktopApp.Models
{
    public class Client : INotifyPropertyChanged, IDataErrorInfo
    {

        
        #region Private Properties
        private int _clientId;
        private string _organisationName;
        private string _contactName;
        private string _firstName;
        private string _lastName;
        private string _phone;
        private string _email;
        private string _password;
        private string _region;
        private string _address; 
        private string _street;
        private string _suburb;
        private string _State;
        private string _zip;
        private SQLHelper _db;
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
                    case "OrganisationName":
                        if (string.IsNullOrEmpty(OrganisationName))
                        {
                            result = "Field cannot be empty ";
                        }
                        break;
                    case "ContactName":
                        if (string.IsNullOrEmpty(this.ContactName))
                        {
                            result = "Field cannot be empty ";
                        }
                        break;
                    case "LastName":
                        if (string.IsNullOrEmpty(this.LastName))
                        {
                            result = "Field cannot be empty ";
                        }
                        break;

                    case "Phone":
                        if (string.IsNullOrEmpty(this.Phone))
                        {
                            result = "Field cannot be empty ";
                        }
                        break;
                    case "Email":
                        if (string.IsNullOrEmpty(this.Email))
                        {
                            result = "Field cannot be empty ";
                        }
                        break;
                    case "Password":
                        if (string.IsNullOrEmpty(this.Password))
                        {
                            result = "Field cannot be empty ";
                        }
                        break;
                    case "Region":
                        if (string.IsNullOrEmpty(this.Region))
                        {
                            result = "Field cannot be empty";
                        }
                        break;
                    case "Street":
                        if (string.IsNullOrEmpty(this.Street))
                        {
                            result = "Field cannot be empty ";
                        }
                        break;
                    case "Suburb":
                        if (string.IsNullOrEmpty(this.Suburb))
                        {
                            result = "Field cannot be empty ";
                        }
                        break;
                    case "State":
                        if (string.IsNullOrEmpty(this.State))
                        {
                            result = "Field cannot be empty ";
                        }
                        break;
                    case "Zip":
                         if (string.IsNullOrEmpty(this.Zip))
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
        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        #endregion Private Properties

        #region Public Properties

        public int ClientId
        {
            get { return _clientId; }
            set { _clientId = value;}
        }

        public string OrganisationName
        {
            get { return _organisationName; }
            set
            {
                _organisationName = value;
                OnPropertyChanged("Organisation_Name");

            }
        }

        public string ContactName
        {
            get { return _contactName; }
            set
            {
                _contactName = value;
                OnPropertyChanged("ContactName");
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
        public string Phone
        {
            get { return _phone; }
            set { _phone = value;
                OnPropertyChanged("Phone");
            }
        }

        public string Email
        {
            get { return _email;}
            set { _email = value;
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

        public string Region
        {
            get { return _region;}
            set
            {
                _region = value;
                OnPropertyChanged("Region");
            }
        }

        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged("Address");
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
            get { return _State; }
            set
            {
                _State = value;
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
        #endregion Public Properties

        #region Constructor
        public Client()
        {
            _db = new SQLHelper();
        }

        public Client(DataRow dr)
        {
            _db = new SQLHelper();
            ClientId = Convert.ToInt32(dr["ClientId"].ToString());
            OrganisationName = dr["OrganisationName"].ToString();
            FirstName = dr["FirstName"].ToString();
            LastName = dr["LastName"].ToString();
            Phone = dr["Phone"].ToString();
            Email = dr["Email"].ToString();
            Street = dr["Street"].ToString();
            Suburb = dr["Suburb"].ToString();
            State = dr["state"].ToString();
            Zip = dr["Zip"].ToString();
            Region = dr["Region"].ToString();
        }

        #endregion Constructor

        #region Public Methods

        public string InsertClient()
        {
            string sp = "usp_InsertClient";
            SqlParameter[] objParams = new SqlParameter[11];
            objParams[0] = new SqlParameter("@OrganisationName", DbType.String);
            objParams[0].Value = this.OrganisationName;
            objParams[1] = new SqlParameter("@FirstName", DbType.String);
            objParams[1].Value = this.ContactName.Split(' ')[0];
            objParams[2] = new SqlParameter("@LastName", DbType.String);
            objParams[2].Value = ContactName.Split(' ')[1];
            objParams[3] = new SqlParameter("@Phone", DbType.String);
            objParams[3].Value = this.Phone;
            objParams[4] = new SqlParameter("@Email", DbType.String);
            objParams[4].Value = this.Email;
            objParams[5] = new SqlParameter("@Password", DbType.String);
            objParams[5].Value = this.Password;
            objParams[6] = new SqlParameter("@Region", DbType.String);
            objParams[6].Value = Region;
            objParams[7] = new SqlParameter("@Street", DbType.String);
            objParams[7].Value = Street;
            objParams[8] = new SqlParameter("@Suburb", DbType.String);
            objParams[8].Value = Suburb;
            objParams[9] = new SqlParameter("@State", DbType.String);
            objParams[9].Value = State;
            objParams[10] = new SqlParameter("@Zip", DbType.String);
            objParams[10].Value = Zip;
            int rowsAffectedClient = _db.ExecuteNonQuery(sp, objParams, true);
            if (rowsAffectedClient >= 1)
            {
                return "New Client Successfully Added";
             }

            return "An error occurred, please try again later";
        }

        public string UpdateClient(int clientId)
        {
            string sp = "usp_UpdateClient";
            SqlParameter[] objParams = new SqlParameter[10];
            objParams[0] = new SqlParameter("@ClientId", DbType.Int32);
            objParams[0].Value = clientId;
            objParams[1] = new SqlParameter("@OrganisationName", DbType.String);
            objParams[1].Value = OrganisationName;
            objParams[2] = new SqlParameter("@FirstName", DbType.String);
            objParams[2].Value = FirstName;
            objParams[3] = new SqlParameter("@LastName", DbType.String);
            objParams[3].Value = LastName;
            objParams[4] = new SqlParameter("@Email", DbType.String);
            objParams[4].Value = Email;
            objParams[5] = new SqlParameter("@Phone", DbType.String);
            objParams[5].Value = Phone;
            objParams[6] = new SqlParameter("@Street", DbType.String);
            objParams[6].Value = Street;
            objParams[7] = new SqlParameter("@Suburb", DbType.String);
            objParams[7].Value = Suburb;
            objParams[8] = new SqlParameter("@State", DbType.String);
            objParams[8].Value = State;
            objParams[9] = new SqlParameter("@Zip", DbType.String);
            objParams[9].Value = Zip;
            int rowsAffectedClient = _db.ExecuteNonQuery(sp, objParams, true);
            if (rowsAffectedClient >= 1)
            {
                return "Client successfully updated";
            }
            return "An error has Occurred, please try again later";
        }

        public string RemoveClient(int clientId)
        {
            string sp = "usp_RemoveClient";
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@ClientId", DbType.Int32);
            objParams[0].Value = clientId;
            int rowsAffectedClient = _db.ExecuteNonQuery(sp, objParams, true);
            if (rowsAffectedClient >= 1)
            {
                return "Client Successfully removed ";
            }
            return "Unable to remove client, please try again later ";
        }
        #endregion Public Methods

    }
}

