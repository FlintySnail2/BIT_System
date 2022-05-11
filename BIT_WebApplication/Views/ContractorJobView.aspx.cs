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
            if (Session["Contractor_Id"] != null)
            {
                LinkButton logout = (LinkButton)Master.FindControl("lbtnLogout");
                logout.Visible = true;

                Contractor currentContractor = new Contractor();
                currentContractor._contractorId = Convert.ToInt32(Session["Contractor_Id"].ToString());
                gvContractorJobs.DataSource = currentContractor.AllAssignedJobs().DefaultView;
                gvContractorJobs.DataBind();

            }
            else
            {
                Response.Redirect("Homepage.aspx");
            }
        }

        protected void gvContractorJobs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Job currentJob = new Job();
            currentJob._contractorId = Convert.ToInt32(Session["InstructorId"].ToString());
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvContractorJobs.Rows[rowIndex];
          
            gvContractorJobs.DataSource = currentJob.AllClientJobs().DefaultView;
            gvContractorJobs.DataBind();

        }

        
    }
}
