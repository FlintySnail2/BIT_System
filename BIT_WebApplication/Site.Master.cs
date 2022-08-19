using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BIT_WebApplication
{
    public partial class SiteMaster : MasterPage
    {
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    lblCopyrightYear.Text = DateTime.Today.Year.ToString();
        //}

        protected void lbtnRejectedJobHistory_Click(object sender, EventArgs e)
        {
            Response.Redirect("RejectedJobHistory.aspx");
        }

        protected void lbtnAssignedJobs_Click(object sender, EventArgs e)
        {
            Response.Redirect("AssignedJobs.aspx");
        }
        protected void lbtnAcceptedJobs_Click(object sender, EventArgs e)
        {
            Response.Redirect("AcceptedJobs.aspx");
        }

        protected void lbtnClientJobHistory_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClientJobHistory.aspx");
        }

        protected void lbtnNewJobRequest_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewJobRequest.aspx");
        }
        protected void lbtnAllRequestedJobs_Click(object sender, EventArgs e)
        {
            Response.Redirect("RequestedJobs.aspx");
        }

        protected void lbtnAllCompletedJobs_Click(object sender, EventArgs e)
        {
            Response.Redirect("CompletedJobs.aspx");
        }

        protected void lbtnAllRejectedJobs_Click(object sender, EventArgs e)
        {
            Response.Redirect("RejectedJobs.aspx");
        }

        protected void lbtnLogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("Homepage.aspx");
        }
    }
}