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
                    //LinkButton clientNav = (LinkButton)Master.FindControl("lbtnClient");
                    //LinkButton staffNav = (LinkButton)Master.FindControl("lbtnStaff");
                    LinkButton logout = (LinkButton)Master.FindControl("lbtnLogout");
                    //clientNav.Visible = true;
                    logout.Visible = true;
                    //staffNav.Visible = false;


                    Job currentClient = new Job();
                    currentClient.ClientId = Convert.ToInt32(Session["Client_Id"].ToString());
                    gvJobs.DataSource = currentClient.AllClientJobs().DefaultView;
                    gvJobs.DataBind();

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
            newClientJob.Priority = txtPriority.Text;
            newClientJob.SkillReq = txtSkillReq.Text;
            newClientJob.Description = txtDesc.Text;
            newClientJob.StartDate = Convert.ToDateTime(jobStart.ToString());
            newClientJob.CompletionDate = Convert.ToDateTime(jobComp.ToString());
                
            string message = newClientJob.InsertJob();
            Response.Write(message);

        }
    }
}