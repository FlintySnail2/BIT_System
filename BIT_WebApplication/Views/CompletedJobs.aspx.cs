using BIT_WebApplication.BLL;
using System;
using System.Collections.Generic;
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
                    logout.Visible = true;

                    Job allCompletedJobs = new Job();
                    allCompletedJobs._staffId = Convert.ToInt32(Session["Staff_Id"].ToString());
                    gvCompletedJobs.DataSource = allCompletedJobs.AllCompletedJobs().DefaultView;
                    gvRejectedJobs.DataSource = allCompletedJobs.AllRejectedJobs().DefaultView;
                    gvRejectedJobs.DataBind();
                    gvCompletedJobs.DataBind();


                }
                else
                {
                    Response.Redirect("Homepage.aspx");
                }
            }

        }
        protected void gvSearchContractor_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                //will retrieve the row for which the button has been clicked
                GridViewRow row = gvSearchContractor.Rows[rowIndex];
                Job newQuery = new Job();
                newQuery.Skill = txtSkill.Text;
                newQuery.WeekDay = ddlAvailable.Text;
                newQuery.Rating = Convert.ToInt32(txtRating.Text.ToString());
                newQuery._contractorId = Convert.ToInt32(Session["ContractorId"].ToString());
            }

        }
    }
}