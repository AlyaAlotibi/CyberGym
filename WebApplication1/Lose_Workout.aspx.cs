using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.App_Code;

namespace WebApplication1
{
    public partial class Lose_Workout : System.Web.UI.Page
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
            string mySql = @"SELECT  WorkOutName, WorkOutDescription FROM WorkOut WHERE ProgramId = 2";
            var mycommand = cr.getDrPassSql(mySql);
            gvLose.DataSource = mycommand;
            gvLose.DataBind();

        }
    }
}