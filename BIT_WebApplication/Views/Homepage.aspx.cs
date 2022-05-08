using BIT_WebApplication.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BIT_WebApplication.Views
{
    public partial class Homepage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

       

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            User user = new User()
            {
                Email = txtUserName.Text,
                Password = txtPassword.Text
            };

            //VALIDATE LOGIN LEVEL
            int clientId = user.CheckClient();
            int contractorId = user.CheckContractor();
            int staffId = user.CheckStaff();

            if (clientId > 0)
            {
                Session.Add("Client_Id", clientId);
                Response.Redirect("ClientJobView.aspx");
            }
            else if (contractorId > 0)
            {
                Session.Add("Contractor_Id", contractorId);
                Response.Redirect("ContractorJobView.aspx");
            }
            else if (staffId > 0)
            {
                Session.Add("Staff_Id", staffId);
                Response.Redirect("RequestedJobView.aspx");
            }
            else
            {
                Response.Write("<script>alert('Invalid Credentials')</script>");
            }
        }

            
        }
    }

