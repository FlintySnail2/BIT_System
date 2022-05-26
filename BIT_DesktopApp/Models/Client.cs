﻿using BIT_DesktopApp.DAL;
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
                if (result == null && !ErrorCollection.ContainsKey(propertyName))
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
            ContactName = dr["ContactName"].ToString();
            Phone = dr["Phone"].ToString();
            Email = dr["Email"].ToString();
            Address = dr["Address"].ToString();
            Region = dr["Region"].ToString();
        }

        #endregion Constructor

        #region Public Methods

        public string InsertClient()
        {
            string sql1 = "INSERT INTO" +
                "               Client(" +
                "               OrganisationName," +
                "               FirstName," +
                "               LastName," +
                "               Phone" +
                "               Email" +
                "               Password," +
                "               AccountStatus)" +
                "       VALUES(" +
                "               @OrganisationName," +
                "               @FirstName," +
                "               @LastName" +
                "               @Phone," +
                "               @Email," +
                "               @Password," +
                "               'Active'";

            string sql2 = "INSERT INTO" +
                          "         Location(" +
                          "         Region," +
                          "         Street," +
                          "         Suburb," +
                          "         State," +
                          "         Zip)" +
                          "          VALUES(" +
                          "        @Region," +
                          "        @Street," +
                          "        @Suburb," +
                          "        @State," +
                          "        @Zip";
            SqlParameter[] objParams = new SqlParameter[5];
            objParams[0] = new SqlParameter("@OrganisationName", DbType.String);
            objParams[0].Value = this.OrganisationName;
            objParams[1] = new SqlParameter("@FirstName" + "@LastName", DbType.String);
            objParams[1].Value = this.ContactName;
            objParams[2] = new SqlParameter("@Phone", DbType.String);
            objParams[2].Value = this.Phone;
            objParams[3] = new SqlParameter("@Email", DbType.String);
            objParams[3].Value = this.Email;
            objParams[4] = new SqlParameter("@Password", DbType.String);
            SqlParameter[] objParams2 = new SqlParameter[5];
            objParams2[0] = new SqlParameter("@Region", DbType.String);
            objParams2[0].Value = Region;
            objParams2[1] = new SqlParameter("@Street", DbType.String);
            objParams2[1].Value = Street;
            objParams2[2] = new SqlParameter("@Suburb", DbType.String);
            objParams2[2].Value = Suburb;
            objParams2[3] = new SqlParameter("@State", DbType.String);
            objParams2[3].Value = State;
            objParams2[4] = new SqlParameter("@Zip", DbType.String);
            objParams2[4].Value = Zip;

            int rowsAffectedClient = _db.ExecuteNonQuery(sql1, objParams);
            int rowsAffectedRegion = _db.ExecuteNonQuery(sql2, objParams);
            if (rowsAffectedClient >= 1 && rowsAffectedRegion >= 1)
            {
                return "New Client & Location Successfully Added";
            }
            else if (rowsAffectedClient >= 1)
            {
                return "New Client Added, Error when adding location";
            }
            else if (rowsAffectedRegion >= 1)
            {
                return "New Location Add, Error when adding Client";
            }

            return "An error occured, please try again later";
        }

        #endregion Public Methods
        public string UpdateClient(int clientId)
        {
            string updateSql1 = "UPDATE" +
                                "   Client" +
                                "    SET" +
                                "   OrganisationName = @OrganisationName," +
                                "   FirstName = @FirstName," +
                                "   LastName = @LastName," +
                                "   Phone = @Phone," +
                                "   Email = @Email";
            string updateSql2 = "UPDATE" +
                                "   Location" +
                                " SET      "  +
                                "   Region = @Region" +
                                "   Street = @Street," +
                                "   Suburb = @Suburb," +
                                "   State = @State," +
                                "   Zip = @Zip";
            SqlParameter[] objParams = new SqlParameter[4];
            objParams[0] = new SqlParameter("@OrganisationName", DbType.String);
            objParams[0].Value = OrganisationName;
            objParams[1] = new SqlParameter("@FirstName + @LastName", DbType.String);
            objParams[1].Value = ContactName;
            objParams[2] = new SqlParameter("@Email", DbType.String);
            objParams[2].Value = Email;
            objParams[3] = new SqlParameter("@Phone", DbType.String);
            objParams[3].Value = Phone;
            SqlParameter[] objParams2 = new SqlParameter[5];
            objParams2[0] = new SqlParameter("@Region", DbType.String);
            objParams2[0].Value = Region;
            objParams2[1] = new SqlParameter("@Street", DbType.String);
            objParams2[1].Value = Street;
            objParams2[2] = new SqlParameter("@Suburb", DbType.String);
            objParams2[2].Value = Suburb;
            objParams2[3] = new SqlParameter("@State", DbType.String);
            objParams2[3].Value = State;
            objParams2[4] = new SqlParameter("@Zip", DbType.String);
            objParams2[4].Value = Zip;
            int rowsAffectedClient = _db.ExecuteNonQuery(updateSql1, objParams);
            int rowsAffectedLocation = _db.ExecuteNonQuery(updateSql2, objParams2);

            if (rowsAffectedClient >= 1 && rowsAffectedLocation >= 1)
            {
                return "Client successfully updated";
            }
            if (rowsAffectedLocation >= 1)
            {
                return "Client Location Successfully Updated";
            }
            if (rowsAffectedClient >= 1)
            {
                return "Client Details Succesfully Updated";
            }

            return "An error has Occurred, please try again later";
        }

        public string RemoveClient(int clientId)
        {
            string removeSql = "UPDATE " +
                               "    Client" +
                               "SET" +
                               "    AccountStatus = 'Inactive" +
                               "WHERE" +
                               "    ClientId = @ClientId";
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@ClientId", DbType.Int32);
            objParams[0].Value = clientId;
            int rowsAffectedClient = _db.ExecuteNonQuery(removeSql, objParams);
            if (rowsAffectedClient >= 1)
            {
                return "Client Successfully removed ";
            }

            return "Unable to remove client, please try again later ";
        }

    }
}

