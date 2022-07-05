using BIT_DesktopApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIT_DesktopApp.ViewModels
{
    public class DashboardViewModel 
    {
        #region Private Properties

        private DashboardInfo _dashboardInfo;
        
        #endregion Private Properties

        #region Public Properties
        

        public DashboardViewModel()
        {
            this._dashboardInfo = new DashboardInfo();
        }



        #endregion Public Properties
    }
}
