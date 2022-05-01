﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BIT_WebApplication
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblCopyrightYear.Text = DateTime.Today.Year.ToString();
        }

        protected void lbtnClient_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClientView.aspx");
        }

        protected void lbtnStaff_Click(object sender, EventArgs e)
        {
            Response.Redirect("CoordinatorView.aspx");
        }

        protected void lbtnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Homepage.aspx");
        }
    }
}