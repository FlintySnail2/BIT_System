using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BIT_DesktopApp.DAL;

namespace BIT_DesktopApp.Models
{
    public class Region : INotifyPropertyChanged
    {
        #region Private Properties

        private string _region;
        private SQLHelper _db;
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        #endregion Private Properties

        #region Public Properties

        public string RegionName
        {
            get { return _region; }
            set
            {
                _region = value; 
                OnPropertyChanged("RegionName");
            }
        }

        #endregion Public Properties


        #region Constructors

        public Region()
        {
            _db = new SQLHelper();
        }
        public Region(DataRow dr)
        {
            _db = new SQLHelper();
            RegionName = dr["Region"].ToString();
        }

        public Region(string regionName)
        {
            this.RegionName = regionName;
        }


        #endregion
    }
}
