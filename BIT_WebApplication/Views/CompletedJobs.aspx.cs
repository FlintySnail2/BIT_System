using BIT_WebApplication.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BIT_WebApplication.Views
{
    public partial class CompletedJobs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                if (Session["Staff_Id"] != null)
                {

                    LinkButton logout = (LinkButton)Master.FindControl("lbtnLogout");
                    LinkButton rejectedJobs = (LinkButton)Master.FindControl("lbtnAllRejectedJobs");
                    logout.Visible = true;
                    rejectedJobs.Visible = true;

                    Job allCompletedJobs = new Job();
                    allCompletedJobs.StaffId = Convert.ToInt32(Session["Staff_Id"].ToString());
                    gvCompletedJobs.DataSource = allCompletedJobs.AllCompletedJobs().DefaultView; 
                    gvRequestedJobs.DataSource = allCompletedJobs.AllRequestedJobs().DefaultView; 
                    gvCompletedJobs.DataBind();
                    gvRequestedJobs.DataBind();
                }
                else
                {
                    Response.Redirect("Homepage.aspx");
                }
            }

        }

        protected void gvCompletedJobs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Job updateJobStatus = new Job();
            updateJobStatus.JobId = Convert.ToInt32(Session["Staff_Id"].ToString());
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvCompletedJobs.Rows[rowIndex];
            if (e.CommandName == "Verified")
            {
                updateJobStatus.Verified(Convert.ToInt32(row.Cells[2].Text));    
            }
            else if (e.CommandName == "SendForPayment")
            {
                updateJobStatus.SendForPayment(Convert.ToInt32(row.Cells[2].Text));
                   
            }
            gvCompletedJobs.DataSource = updateJobStatus.AllCompletedJobs();
            gvCompletedJobs.DataBind();
        }




         
    }
}