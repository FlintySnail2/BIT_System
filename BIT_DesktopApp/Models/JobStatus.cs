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
    public class JobStatus : INotifyPropertyChanged
    {
        #region Properties

        private int _jobId;
        private string _status;
        private SQLHelper _db;
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        public int JobId
        {
            get { return _jobId; }
            set { _jobId = value; }
        }

        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged("Status");
            }
        }

        #endregion Properties

        #region Constructor

        public JobStatus()
        {
            _db = new SQLHelper();  
        }

        public JobStatus(DataRow dr)
        {
            _db = new SQLHelper();
            Status = dr["Status"].ToString();
        }

        #endregion Constructor

        #region Public Methods


        #endregion Public Methods
    }
}
