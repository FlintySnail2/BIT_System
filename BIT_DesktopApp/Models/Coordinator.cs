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
    public class Coordinator
    {
        #region Properties

        private int _staffId { get; set; }
        private string _employeeName { get; set; }
        private DateTime _dob { get; set; }
        private string _address { get; set; }
        private int _phone { get; set; }
        private string _email { get; set; }
        private string _password { get; set; }
        private SQLHelper _db;
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        public int StaffId
        {
            get { return _staffId; }
            set { _staffId = value; }
        }

        public string EmployeeName
        {
            get { return _employeeName; }
            set { _employeeName = value;
                OnPropertyChanged("Employee Name");

            }
        }
        public DateTime Dob
        {
            get { return _dob; }
            set
            {
                _dob = value;
                OnPropertyChanged("DOB");
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

        public int Phone
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
        #endregion Properties

        #region Constructor

        public Coordinator()
        {
            _db = new SQLHelper();
        }

        public Coordinator(DataRow dr)
        {
            _db = new SQLHelper();
            StaffId = Convert.ToInt32(dr["Staff_Id"].ToString());
            EmployeeName = dr["EmployeeName"].ToString();
            Dob = Convert.ToDateTime(dr["Dob"].ToString());
            Address = dr["Address"].ToString();
            Phone = Convert.ToInt32(dr["Phone"].ToString());
            Email = dr["Email"].ToString();
            Password = dr["Password"].ToString();
        }

        #endregion Constructor


    }
}
