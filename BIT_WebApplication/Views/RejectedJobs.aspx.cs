﻿using BIT_WebApplication.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BIT_WebApplication.Views
{
    public partial class RejectedJobs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                if (Session["Staff_Id"] != null)
                {

                    LinkButton logout = (LinkButton)Master.FindControl("lbtnLogout");
                    LinkButton completedJobs = (LinkButton)Master.FindControl("lbtnAllCompletedJobs");
                    LinkButton requestedJobs = (LinkButton)Master.FindControl("lbtnAllRequestedJobs");
                    logout.Visible = true;
                    completedJobs.Visible = true;
                    requestedJobs.Visible = true;

                    Job allCompletedJobs = new Job();
                    allCompletedJobs.StaffId = Convert.ToInt32(Session["Staff_Id"].ToString());
                    gvRejectedJobs.DataSource = allCompletedJobs.AllRejectedJobs().DefaultView;
                    gvRejectedJobs.DataBind();

                }
                else
                {
                    Response.Redirect("Homepage.aspx");
                }
            }

        }

        protected void gvRejectedJobs_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "ReAssign")
            {
                Job reassignJob = new Job();
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvRejectedJobs.Rows[rowIndex];
                int jobId = Convert.ToInt32(row.Cells[1].Text);
                string skill = row.Cells[6].Text;  
                DateTime completionDate = Convert.ToDateTime(row.Cells[8].Text); 
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
                Response.Write("<script>alert('No Contractors are available at thi time')</script>");
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
