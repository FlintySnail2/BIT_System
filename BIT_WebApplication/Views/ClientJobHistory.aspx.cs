using BIT_WebApplication.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BIT_WebApplication.Views
{
    public partial class ClientJobHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Client_Id"] != null)
                {
                    LinkButton logout = (LinkButton)Master.FindControl("lbtnLogout");
                    LinkButton newJobRequest = (LinkButton)Master.FindControl("lbtnNewJobRequest");
                    newJobRequest.Visible = true;
                    logout.Visible = true;

                    Job currentClient = new Job();
                    currentClient.ClientId = Convert.ToInt32(Session["Client_Id"].ToString());
                    gvJobHistory.DataSource = currentClient.AllClientJobs().DefaultView;
                    gvJobHistory.DataBind();
                }
                else
                {
                    Response.Redirect("Homepage.aspx");
                }
            }

        }

    }
}
