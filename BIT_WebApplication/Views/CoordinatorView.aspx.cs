using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BIT_WebApplication.Views
{
    public partial class CoordinatorVies : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Staff_Id"] != null)
            {
                LinkButton staffNav = (LinkButton)Master.FindControl("lbtnStaff");
                LinkButton clientNav = (LinkButton)Master.FindControl("lbtnClient");
                clientNav.Visible = false;
                staffNav.Visible = true;

               

            }

        }
    }
}