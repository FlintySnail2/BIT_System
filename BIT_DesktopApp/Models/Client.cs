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
    public class Client : INotifyPropertyChanged
    {
        #region Properties
        private int _clientId;
        private string _organisationName;
        private string _contactName;
        private int _phone;
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

        public int Phone
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
            ClientId = Convert.ToInt32(dr["Client_Id"].ToString());
            OrganisationName = dr["Oragnisation_Name"].ToString();
            ContactName = dr["ContactName"].ToString();
            Phone = Convert.ToInt32(dr["Phone"].ToString());
            Email = dr["Email"].ToString();
            Password = dr["Password"].ToString();
            RegionName = dr["Region_Name"].ToString();
            Location = dr["Location"].ToString() ;
            LocationNumber = Convert.ToInt32(dr["LocationNum"].ToString());

        }

        #endregion Constructor
    }
}

