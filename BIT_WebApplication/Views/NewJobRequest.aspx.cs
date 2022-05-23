using BIT_WebApplication.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BIT_WebApplication.Views
{
    public partial class ClientView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)

        {
            if (!IsPostBack)
            {
                if (Session["Client_Id"] != null)
                {
                 
                    LinkButton logout = (LinkButton)Master.FindControl("lbtnLogout");
                    LinkButton jobHistory = (LinkButton)Master.FindControl("lbtnClientJobHistory"); 
                    logout.Visible = true;
                    jobHistory.Visible = true;

                    Job currentClient = new Job();
                    currentClient.ClientId = Convert.ToInt32(Session["Client_Id"].ToString());
                    ddlRegion.DataSource = Region.GetAllRegion().DefaultView;
                    ddlSkills.DataSource = Skills.GetAllSkills().DefaultView;
                    ddlRegion.DataTextField = "Region";
                    ddlSkills.DataTextField = "SkillTitle";
                    ddlRegion.DataValueField = "Region";
                    ddlSkills.DataValueField = "SkillTitle";
                    ddlSkills.DataBind();
                    ddlRegion.DataBind();
                }
                else
                {
                    Response.Redirect("Homepage.aspx");
                }
            }

        }

        protected void btnSubmitJob_Click(object sender, EventArgs e)
        {
            DateTime jobStart = DateTime.ParseExact(txtReqStartDate.Text.Trim(), "yyyy-mm-dd", null);
            DateTime jobComp = DateTime.ParseExact(txtReqCompDate.Text.Trim(), "yyyy-mm-dd", null);
            Job newClientJob = new Job();

            newClientJob.ClientId = Convert.ToInt32(Session["Client_Id"].ToString());
       //     newClientJob.Region = ddlRegion.Text; 
            newClientJob.Priority = ddlPriority.Text;
            newClientJob.SkillReq = ddlSkills.SelectedValue;
            newClientJob.Region = ddlRegion.SelectedValue;
            newClientJob.Description = txtDesc.Text;
            newClientJob.StartDate = Convert.ToDateTime(jobStart.ToString());
            newClientJob.CompletionDate = Convert.ToDateTime(jobComp.ToString());
                
            string message = newClientJob.InsertJob();
            Response.Write(message);

        }
    }
}