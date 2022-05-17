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
                    gvAssignedJobs.DataSource = currentContractor.AllAssignedJobs().DefaultView;
                    gvAcceptedJobs.DataSource = currentContractor.AllAcceptedJobs().DefaultView;
                    gvAssignedJobs.DataBind();
                    gvAcceptedJobs.DataBind();
                }
                else
                {
                    Response.Redirect("Homepage.aspx");
                }
            }


        }

        protected void gvAssignedJobs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Contractor currentContractor = new Contractor();
            currentContractor.ContractorId = Convert.ToInt32(Session["Contractor_Id"].ToString());
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvAssignedJobs.Rows[rowIndex];
            if (e.CommandName == "Accept")
            {
                currentContractor.AcceptJob(Convert.ToInt32(row.Cells[2].Text));
            }
            else if (e.CommandName == "Reject")
            {
                currentContractor.RejectJob(Convert.ToInt32(row.Cells[2].Text));
            }
            gvAssignedJobs.DataSource = currentContractor.AllAssignedJobs();
            gvAssignedJobs.DataBind();
        }

  
    }
}
