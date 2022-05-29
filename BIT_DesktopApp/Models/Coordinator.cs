
using BIT_DesktopApp.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace BIT_DesktopApp.Models
{
    public class Coordinator : INotifyPropertyChanged, IDataErrorInfo
    {
        #region Private Properties

        private int _staffId;
        private string _firstName;
        private string _lastName;
        private DateTime _dob;
        private string _phone;
        private string _email;
        private string _password;
        private SQLHelper _db;
        public event PropertyChangedEventHandler PropertyChanged;

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
                            result = "Field cannot be empty";
                        }
                        break;
                    case "LastName":
                        if (string.IsNullOrEmpty(LastName))
                        {
                            result = "Field cannot be empty";
                        }
                        break;
                    case "Dob":
                        if (Dob.Year <= 1950 )
                        {
                            result = "You are too old to work here";
                        }
                        break ;
                    case "Phone":
                        if (string.IsNullOrEmpty(Phone))
                        {
                            result = "Field cannot be left empty ";
                        }
                        break;
                    case "Email":
                        if (string.IsNullOrEmpty(Email))
                        {
                            result = "Field cannot be left empty";
                        }
                        break;
                    case "Password":
                        if (string.IsNullOrEmpty(Password))
                        {
                            result = "Field cannot be left empty";
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

        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();

        #endregion Private Properties

        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        #region Public Properties

        public int StaffId
        {
            get { return _staffId; }
            set { _staffId = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value;
                OnPropertyChanged("FirstName");

            }
        }

        public string LastName
        {
            get { return _lastName;}
            set
            {
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        public string EmplopyeeName => $"{FirstName} {LastName}";

        public DateTime Dob
        {
            get { return _dob; }
            set
            {
                _dob = value;
                OnPropertyChanged("Dob");
            }
        }

        //THESE ARE READ ONLY 
        public string DobFormat => _dob.ToShortDateString();


        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertyChanged("Phone");
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
        #endregion Public Properties

        #region Constructor

        public Coordinator()
        {
            _db = new SQLHelper();
        }

        public Coordinator(DataRow dr)
        {
            _db = new SQLHelper();
            StaffId = Convert.ToInt32(dr["StaffId"].ToString());
            FirstName = dr["FirstName"].ToString();
            LastName = dr["LastName"].ToString();
            Dob = Convert.ToDateTime(dr["Dob"].ToString());
            Phone = dr["Phone"].ToString();
            Email = dr["Email"].ToString();
            Password = dr["Password"].ToString();
        }

        #endregion Constructor

        #region Public Methods

        public string UpdateStaffDetails(int coordinatorId)
        {
            string updateSql = "UPDATE" +
                               "    Staff" +
                               "       SET" +
                               "       FirstName = @FirstName," +
                               "       LastName = @LastName," +
                               "       Phone = @Phone," +
                               "       Dob = @Dob," +
                               "       Email = @Email," +
                               "       Password =  @Password" +
                               " WHERE" +
                               "    StaffId = @StaffId";
            SqlParameter[] objParams = new SqlParameter[7];
            objParams[0] = new SqlParameter("@StaffId", DbType.Int32);
            objParams[0].Value = coordinatorId; 
            objParams[1] = new SqlParameter("@FirstName", DbType.String);
            objParams[1].Value = FirstName;
            objParams[2] = new SqlParameter("@LastName", DbType.String);
            objParams[2].Value = LastName;
            objParams[3] = new SqlParameter("@Phone", DbType.String);
            objParams[3].Value = Phone;
            objParams[4] = new SqlParameter("@Dob", DbType.DateTime);
            objParams[4].Value = Dob;
            objParams[5] = new SqlParameter("@Email", DbType.String);
            objParams[5].Value = Email;
            objParams[6] = new SqlParameter("Password", DbType.String);
            objParams[6].Value = Password;
            int rowsAffected = _db.ExecuteNonQuery(updateSql, objParams);
            if (rowsAffected >= 1)
            {
                return "Coordinator Successfully Updated ";
            }

            return "Unable to update coordinator, please try again later";
        }

        public string RemoveCoordinator(int staffId)
        {
            string removeSql = " Update" +
                               "    Staff" +
                               " Set" +
                               "    AccountStatus = 'Inactive'" +
                               " WHERE" +
                               "    StaffId = @StaffId";
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@StaffId", DbType.Int32);
            objParams[0].Value = staffId;
            int rowsAffected = _db.ExecuteNonQuery(removeSql, objParams);
            if (rowsAffected >= 1)
            {
                return "Coordinator Successfully Deleted";
            }

            return "Unable to delete coordinator, please try again later";

        }

        public string InsertCoordinator()
        {
            string insertSql = "INSERT INTO Staff(" +
                               "            FirstName," +
                               "            LastName," +
                               "            Phone," +
                               "            Dob," +
                               "            Email," +
                               "            Password," +
                               "            StaffType," +
                               "            AccountStatus)" +
                            "            VALUES(" +
                               "            @FirstName," +
                               "            @LastName," +
                               "            @Phone," +
                               "            @Dob," +
                               "            @Email," +
                               "            @Password," +
                               "            'Coordinator'," +
                               "            'Active')";
            SqlParameter[] objParams = new SqlParameter[6];
            objParams[0] = new SqlParameter("@FirstName", DbType.String);
            objParams[0].Value = this.FirstName;
            objParams[1] = new SqlParameter("@LastName", DbType.String);
            objParams[1].Value = this.LastName;
            objParams[2] = new SqlParameter("@Phone", DbType.String);
            objParams[2].Value = this.Phone;
            objParams[3] = new SqlParameter("@Dob", DbType.DateTime);
            objParams[3].Value = this.Dob;
            objParams[4] = new SqlParameter("@Email", DbType.DateTime);
            objParams[4].Value = this.Email;
            objParams[5] = new SqlParameter("@Password", DbType.String);
            objParams[5].Value = this.Password;
            int rowsAffected = _db.ExecuteNonQuery(insertSql, objParams);
            if (rowsAffected >= 1)
            {
                return "Coordinator Successfully Added";
            }

            return "Unable to add coordinator, please try again later"; 

        }

        #endregion Public  Methods


    }
}
