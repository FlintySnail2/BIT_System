using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BIT_WebApplication.Views
{
    public partial class AssignedJobs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["Contractor_Id"] != null)
                {
                    LinkButton logout = (LinkButton)Master.FindControl("lbtnLogout");
                    LinkButton acceptedJobs = (LinkButton)Master.FindControl("lbtnAcceptedJobs");
                    LinkButton rejectionHistory = (LinkButton)Master.FindControl("lbtnRejectedJobHistory");
                    logout.Visible = true; 
                    acceptedJobs.Visible = true;
                    rejectionHistory.Visible = true;
                    Contractor currentContractor = new Contractor();
                    currentContractor.ContractorId = Convert.ToInt32(Session["Contractor_Id"].ToString());
                    RefreshGrid(currentContractor);

                }
                else
                {
                    Response.Redirect("Homepage.aspx");
                }
            }

           
        }
        private void RefreshGrid(Contractor currentContractor)
        {
            gvAssignedJobs.DataSource = currentContractor.AllAssignedJobs().DefaultView;
            gvAssignedJobs.DataBind();

        }

        protected void gvAssignedJobs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Contractor currentContractor = new Contractor();
            currentContractor.ContractorId = Convert.ToInt32(Session["Contractor_Id"].ToString());
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvAssignedJobs.Rows[rowIndex];
            TextBox textbox = (TextBox)(row.Cells[2].FindControl("txtComment"));
            if (e.CommandName == "Accept")
            {
                currentContractor.AcceptJob(Convert.ToInt32(row.Cells[3].Text));
            }
            else if (e.CommandName == "Reject")
            {
                currentContractor.RejectJob(Convert.ToInt32(row.Cells[3].Text), textbox.Text);
            }
            RefreshGrid(currentContractor);
        }
    }
}