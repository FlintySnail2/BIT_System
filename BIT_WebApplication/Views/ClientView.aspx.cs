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
            if (Session["Client_Id"] != null)
            {
                //LinkButton clientNav = (LinkButton)Master.FindControl("lbtnClient");
                //LinkButton staffNav = (LinkButton)Master.FindControl("lbtnStaff");
                //LinkButton logout = (LinkButton)Master.FindControl("lbtnLogout");
                //clientNav.Visible = true;
                //logout.Visible = true;
                //staffNav.Visible = false;
                

                Client currentClient = new Client();
                currentClient.ClientId = Convert.ToInt32( Session["Client_Id"].ToString());
                gvJobs.DataSource = currentClient.AllClientJobs().DefaultView;
                gvJobs.DataBind();

            }
            else
            {
                Response.Redirect("Homepage.aspx");
            }

        }
    }
}