using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["role"] == "admin")
            {
                linkVallSubscrption.Visible = true;
                linkValluser.Visible = true;
                linkbProfile.Visible = false;
                linkBAddWorkout.Visible = true;


            }
            else if (Session["role"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                linkbProfile.Text = "Hello, " + Session["UserName"].ToString();
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["role"] = null;
            btnLogout.Visible = false;
            Response.Redirect("Login.aspx");
        }

        protected void linkValluser_Click(object sender, EventArgs e)
        {
            Response.Redirect("All_Users.aspx");
        }

        protected void linkVallSubscrption_Click(object sender, EventArgs e)
        {
            Response.Redirect("All_Subscrption.aspx");
        }

        protected void linkbProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }

        protected void linkBHome_Click(object sender, EventArgs e)
        {
            if (Session["role"] == "admin")
            {
                Response.Redirect("Home.aspx");
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void linkBAddWorkout_Click(object sender, EventArgs e)
        {
            if (Session["role"] == "admin")
            {
                Response.Redirect("Add_workout.aspx");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}