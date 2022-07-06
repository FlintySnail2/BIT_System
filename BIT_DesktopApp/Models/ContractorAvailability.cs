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
        private int _contractorId { get; set; }
        private DateTime _availDate { get; set; }
        public string AvailDateFormat => _availDate.ToShortDateString();


        private SQLHelper _db;


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

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

       public string InsertNewAvailability(int contractorId)
        {
            string insertSql = @"SET DATEFORMAT DMY
                                INSERT INTO Availability(
                                        ContractorId,
                                        AvailabilityDate)
                                 VALUES(
                                        @ContractorId,
                                        @AvailabilityDate)";
            SqlParameter[] objParmas = new SqlParameter[2];
            objParmas[0] = new SqlParameter("@ContractorId", DbType.Int32);
            objParmas[0].Value = contractorId;
            objParmas[1] = new SqlParameter("@AvailabilityDate", DbType.DateTime);
            objParmas[1].Value = AvailDate;
            int rowsAffected = _db.ExecuteNonQuery(insertSql, objParmas);
            if (rowsAffected >= 1)
            {
                return "Availability Successfully Added ";
            }
            return "Unable to Add Availability, please try again later ";

        }

        public string DeleteAvailability(int contractorId)
        {
            string insertSql = @"DELETE FROM
                                        Availability
                                WHERE
                                    ContractorId = @ContractorId
                                AND
                                    AvailabilityDate = @AvailabilityDate";
            SqlParameter[] objParmas = new SqlParameter[2];
            objParmas[0] = new SqlParameter("@ContractorId", DbType.Int32);
            objParmas[0].Value = contractorId;
            objParmas[1] = new SqlParameter("@AvailabilityDate", DbType.DateTime);
            objParmas[1].Value = AvailDate;
            int rowsAffected = _db.ExecuteNonQuery(insertSql, objParmas);
            if (rowsAffected >= 1)
            {
                return "Availability Successfully Deleted ";
            }
            return "Unable to Delete Availability, please try again later ";
        }
    }
}
