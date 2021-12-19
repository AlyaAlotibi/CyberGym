using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.App_Code;

namespace WebApplication1
{
    public partial class Gain_Workout : System.Web.UI.Page
    {
        CRUD cr = new CRUD();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                getallGainWorkout();
            }

        }
        public void getallGainWorkout()
        {
            string mySql = @"SELECT WorkOutId, WorkOutName, WorkOutDescription FROM WorkOut WHERE ProgramId = 1";
            var mycommand = cr.getDrPassSql(mySql);
            gvGain.DataSource = mycommand;
            gvGain.DataBind();

        }
    }
}