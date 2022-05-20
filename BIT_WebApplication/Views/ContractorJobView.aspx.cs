using BIT_WebApplication.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BIT_WebApplication.Views
{
    public partial class ContractorView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["Contractor_Id"] != null)
                {
                    LinkButton logout = (LinkButton)Master.FindControl("lbtnLogout");
                    logout.Visible = true;
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
            gvAcceptedJobs.DataSource = currentContractor.AllAcceptedJobs().DefaultView;
            gvAssignedJobs.DataBind();
            gvAcceptedJobs.DataBind();
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
                currentContractor.RejectJob(Convert.ToInt32(row.Cells[3].Text),textbox.Text);
            }
            RefreshGrid(currentContractor);
        }



        protected void gvAcceptedJobs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Contractor currentContractor = new Contractor();
            currentContractor.ContractorId = Convert.ToInt32(Session["Contractor_Id"].ToString());
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvAcceptedJobs.Rows[rowIndex];
            TextBox txtKilometres = (TextBox)(row.Cells[1].FindControl(("txtKilometres")));
            TextBox txtHours = (TextBox)(row.Cells[2].FindControl(("txtHours")));
            TextBox txtFeedBack = (TextBox)(row.Cells[3].FindControl("txtFeedBack"));
            if (e.CommandName == "Complete")
            {
             currentContractor.CompleteJob(Convert.ToInt32(Convert.ToInt32(row.Cells[4].Text)),Convert.ToInt32(txtKilometres.Text),Convert.ToDecimal(txtHours.Text), txtFeedBack.Text);
            }
            RefreshGrid(currentContractor);

        }



    }

}
