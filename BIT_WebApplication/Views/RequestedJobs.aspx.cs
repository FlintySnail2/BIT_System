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
    public partial class RequestedJobs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["Staff_Id"] != null)
                {
                    LinkButton logout = (LinkButton)Master.FindControl("lbtnLogout");
                    LinkButton rejectedJobs = (LinkButton)Master.FindControl("lbtnAllRejectedJobs");
                    LinkButton completedJobs = (LinkButton)Master.FindControl("lbtnAllCompletedJobs");
                    logout.Visible = true;
                    rejectedJobs.Visible = true;
                    completedJobs.Visible = true;
                    Job allCompletedJobs = new Job();
                    allCompletedJobs.StaffId = Convert.ToInt32(Session["Staff_Id"].ToString());
                    gvRequestedJobs.DataSource = allCompletedJobs.AllRequestedJobs().DefaultView;
                    gvRequestedJobs.DataBind();
                }
                else
                {
                    Response.Redirect("Homepage.aspx");
                }
            }
        }


        protected void gvRequestedJobs_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Assign")
            {
                Job reassignJob = new Job();
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvRequestedJobs.Rows[rowIndex];
                int jobId = Convert.ToInt32(row.Cells[1].Text);
                string skill = row.Cells[4].Text;
                DateTime completionDate = Convert.ToDateTime(row.Cells[5].Text);
                reassignJob.AvailableContractors(jobId, skill, completionDate);
                DataTable dt = reassignJob.AvailableContractors(jobId, skill, completionDate);
                if (dt.Rows.Count == 0)
                {
                    Response.Write("<script>alert('No Contractors are available at this time')</script>");
                }
                else
                {
                    gvAvailableContractors.DataSource = dt.DefaultView;
                    gvAvailableContractors.DataBind();
                }

            }
            else
            {
                Response.Write("<script>alert('No Contractors are available at this time')</script>");
            }
        }

        protected void gvAvailableContractors_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            Job assignJob = new Job();
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvAvailableContractors.Rows[rowIndex];
            int jobId = Convert.ToInt32(row.Cells[1].Text);
            int contractorId = Convert.ToInt32(row.Cells[2].Text);

            if (e.CommandName == "Assign")

            {
                assignJob.AssignJob(jobId, contractorId);
                Response.Redirect("CompletedJobs.aspx");
            }

        }

    }
}