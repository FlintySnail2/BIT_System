using BIT_WebApplication.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BIT_WebApplication.Views
{
    public partial class ContractorView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Contractor_Id"] != null)
            {
                //Contractor currentContractor = new Contractor();
                //currentContractor.ContractorId = Convert.ToInt32(Session["Contractor_Id"].ToString());

            }
        }
    }
}