using BIT_WebApplication.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BIT_WebApplication.Views
{
    public partial class RejectedJobHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                if (Session["Contractor_Id"] != null)
                {

                    LinkButton logout = (LinkButton)Master.FindControl("lbtnLogout");
                    LinkButton assignedJobs = (LinkButton)Master.FindControl("lbtnAssignedJobs");
                    LinkButton acceptedJobs = (LinkButton)Master.FindControl("lbtnAcceptedJobs");
                    logout.Visible = true;
                    assignedJobs.Visible = true;
                    acceptedJobs.Visible = true;


                    Job allRejectedJobs = new Job();
                    allRejectedJobs.StaffId = Convert.ToInt32(Session["Contractor_Id"].ToString());
                    gvRejectedJobs.DataSource = allRejectedJobs.AllRejectedJobs().DefaultView;
                    gvRejectedJobs.DataBind();

                }
                else
                {
                    Response.Redirect("Homepage.aspx");
                }
            }

        }
    }
}