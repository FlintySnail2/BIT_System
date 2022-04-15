using BIT_WebApplication.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BIT_WebApplication.Views
{
    public partial class ClientView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ClientID"] != null)
            {
                Client currentClient = new Client();
                currentClient.ClientId = Convert.ToInt32( Session["ClientId"].ToString());
                gvBookings.DataSource = currentClient.AllClientJobs().DefaultView;
                gvBookings.DataBind();

            }
            else
            {
                Response.Redirect("Homepage.aspx");
            }

        }
    }
}