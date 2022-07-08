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
    public class ContractorAvailability : INotifyPropertyChanged
    {
        #region Private Properties
        private int _contractorId { get; set; }
        private DateTime _availDate { get; set; }
        private SQLHelper _db;

        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        #endregion Private Properties

        #region Public Properties

        public event PropertyChangedEventHandler PropertyChanged;

        public int ContractorId
        {
            get { return _contractorId; }
            set { _contractorId = value; }
        }

        public DateTime AvailDate
        {
            get { return _availDate; }
            set { _availDate = value;
                OnPropertyChanged("AvailabilityDate");
            }
        }
        //READ ONLY FIELD
        public string AvailDateFormat => _availDate.ToShortDateString();

        #endregion Public Properties

        #region Constructor
        public ContractorAvailability()
        {
            _db = new SQLHelper();
        }

        public ContractorAvailability(DataRow dr)
        {
            _db = new SQLHelper();
            ContractorId = Convert.ToInt32(dr["ContractorId"].ToString());
            AvailDate = Convert.ToDateTime(dr["AvailabilityDate"].ToString());
        }

        #endregion Constructor

        #region Public Methods

        public string InsertNewAvailability(int contractorId)
        {
            string sp = "usp_InsertAvailability";
            SqlParameter[] objParmas = new SqlParameter[2];
            objParmas[0] = new SqlParameter("@ContractorId", DbType.Int32);
            objParmas[0].Value = contractorId;
            objParmas[1] = new SqlParameter("@AvailabilityDate", DbType.DateTime);
            objParmas[1].Value = AvailDate;
            int rowsAffected = _db.ExecuteNonQuery(sp, objParmas,true);
            if (rowsAffected >= 1)
            {
                return "Availability Successfully Added ";
            }
            return "Unable to Add Availability, please try again later ";

        }

        public string DeleteAvailability(int contractorId)
        {
            string sp = "usp_DeleteAvailability";
            SqlParameter[] objParmas = new SqlParameter[2];
            objParmas[0] = new SqlParameter("@ContractorId", DbType.Int32);
            objParmas[0].Value = contractorId;
            objParmas[1] = new SqlParameter("@AvailabilityDate", DbType.DateTime);
            objParmas[1].Value = AvailDate;
            int rowsAffected = _db.ExecuteNonQuery(sp, objParmas, true);
            if (rowsAffected >= 1)
            {
                return "Availability Successfully Deleted ";
            }
            return "Unable to Delete Availability, please try again later ";
        }

        #endregion Public Methods
    }
}
