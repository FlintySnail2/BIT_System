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
    public class Client : INotifyPropertyChanged
    {

        
        #region Private Properties
        private int _clientId;
        private string _organisationName;
        private string _contactName;
        private string _phone;
        private string _email;
        private string _password;
        private string _regionName;
        private string _location;
        private int _locationNum;
        private SQLHelper _db;
        public event PropertyChangedEventHandler PropertyChanged;

        

        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

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
            get { return _contactName;}
            set { _contactName = value;
                OnPropertyChanged("Contact Name");

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
            get { return _password;}
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        public string RegionName
        {
            get { return _regionName;}
            set
            {
                _regionName = value;
                OnPropertyChanged("Region_Name");
            }
        }

        public string Location
        {
            get { return _location;}
            set
            {
                _location = value;
                OnPropertyChanged("Location");
            }
        }

        public int LocationNumber
        {
            get { return _locationNum; }
            set { _locationNum = value;
                OnPropertyChanged("Location");
            }
        }
        #endregion Properties

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
            ContactName = dr["ContactName"].ToString();
            Phone = dr["Phone"].ToString();
            Email = dr["Email"].ToString();
            Password = dr["Password"].ToString();
            RegionName = dr["RegionName"].ToString();
            Location = dr["Location"].ToString() ;
            LocationNumber = Convert.ToInt32(dr["LocationNum"].ToString());

        }

        #endregion Constructor

        //#region Public Methods

        //public int InsertClient(int clientId)
        //{
        //    string sql = "INSERT INTO" +
        //        "               Client(" +
        //        "               Oragnisation_Name," +
        //        "               First_Name," +
        //        "               Last_Name," +
        //        "               Phone" +
        //        "               Email" +
        //        "               Password)" +
        //        "       VALUES(" +
        //        "               @OrganisationName," +
        //        "               @ContactName," + //MAY NOT WORK DUE TO THE CONCATINATION
        //        "               @Phone," +
        //        "               @Email," +
        //        "               @Password";
        //    //2ND INSERT STATEMENT POSSIBLE ???
        //    SqlParameter[] objParams = new SqlParameter[5];
        //    objParams[0] = new SqlParameter("@OrganisationName", DbType.String);
        //    objParams[0].Value = this.OrganisationName;
        //    objParams[1] = new SqlParameter("@FirstName" + "@LastName", DbType.String);
        //    objParams[1].Value = this.ContactName;
        //    objParams[2] = new SqlParameter("@Phone", DbType.String);
        //    objParams[2].Value = this.Phone;
        //    objParams[3] = new SqlParameter("@Email", DbType.String);
        //    objParams[3].Value = this.Email;
        //    objParams[4] = new SqlParameter("@Password", DbType.String);
        //    int rowsAffectd = _db.ExecuteNonQuery(sql, objParams);
        //    if (rowsAffectd >= 1)
        //    {
        //        return "New Client Successfully Added";
        //    }
        //    return "New Client Not Added";
        //}

        //#endregion Public Methods
    }
}

