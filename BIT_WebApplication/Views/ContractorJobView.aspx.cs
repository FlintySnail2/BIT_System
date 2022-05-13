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
                    currentContractor._contractorId = Convert.ToInt32(Session["Contractor_Id"].ToString());
                    gvActiveJobs.DataSource = currentContractor.AllAcceptedJobs().DefaultView;
                    gvAssignedJobs.DataSource = currentContractor.AllAssignedJobs().DefaultView;
                    gvAssignedJobs.DataBind();
                    gvActiveJobs.DataBind();
                }
                else
                {
                    Response.Redirect("Homepage.aspx");
                }
            }
        }

        //protected void gvAssignedJobs_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    Contractor currentContractor = new Contractor();
        //    currentContractor._contractorId = Convert.ToInt32(Session["ContractorId"].ToString());
        //    int rowIndex = Convert.ToInt32(e.CommandArgument);
        //    GridViewRow row = gvAssignedJobs.Rows[rowIndex];
        //    if (e.CommandName == "Accept")
        //    {
        //        currentContractor.AcceptJob(Convert.ToInt32(row.Cells[2].Text));
        //    }
        //    else if (e.CommandName == "Reject")
        //    {
        //        currentContractor.RejectJob(Convert.ToInt32(row.Cells[2].Text));
        //    }
        //    gvActiveJobs.DataSource = currentContractor.AllAcceptedJobs().DefaultView;
        //    gvActiveJobs.DataBind();


        //}

        //protected void gvCompleteJob_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    Contractor currentInstructor = new Contractor();
        //    currentInstructor._contractorId = Convert.ToInt32(Session["InstructorId"].ToString());
        //    int rowIndex = Convert.ToInt32(e.CommandArgument);
        //    GridViewRow row = gvActiveJobs.Rows[rowIndex];
        //    if (e.CommandName == "Complete")
        //    {
        //        int kilometres = Convert.ToInt32(((TextBox)row.FindControl("txtKilometres")).Text.Trim());
        //        currentInstructor.CompleteJob(Convert.ToInt32(row.Cells[2].Text), kilometres);
        //        gvActiveJobs.DataSource = currentInstructor.AllAcceptedJobs().DefaultView;
        //        gvActiveJobs.DataBind();

        //    }


        //}
    }
}
