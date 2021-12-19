using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class well_being : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] == "admin")
            {
                this.Master.FindControl("linkVallSubscrption").Visible = true;
                this.Master.FindControl("linkValluser").Visible = true;
            }
            

        }
    }
}