using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.App_Code;

namespace WebApplication1
{
    public partial class Add_workout : System.Web.UI.Page
    {
        CRUD cr = new CRUD();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] != "admin")
            {
                Response.Redirect("Login.aspx");

            }
            if (!Page.IsPostBack)
            {
                populateProgramName();
                getAllWorkout();
            }
        }
        public void populateProgramName()
        {
            string mySql = "Select * from Programs;";
            SqlDataReader drr = cr.getDrPassSql(mySql);
            rbprogramName.DataTextField = "ProgramName";
            rbprogramName.DataValueField = "ProgramId";
            rbprogramName.DataSource = drr;
            rbprogramName.DataBind();
        }
       
        protected void btnAddWorkout_Click(object sender, EventArgs e)
        {
            string WorkoutName = txtWorkoutName.Text;
            string WorkoutDes = txtWorkoutDes.Text;
            string mySql = @"insert into WorkOut values
                                (@WorkoutName , @WorkoutDes , @ProgramID )";
            Dictionary<string, object> InputParaList = new Dictionary<string, object>();
            InputParaList.Add("@WorkoutName", WorkoutName);
            InputParaList.Add("@WorkoutDes", WorkoutDes);
            InputParaList.Add("@ProgramID", int.Parse(rbprogramName.SelectedItem.Value));
            int mycommand = cr.InsertUpdateDeleteViaSqlDic(mySql, InputParaList);
            ClearRecords();
            if (mycommand >= 1)
            {
                //getAllWorkout();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Workout Added Successfully')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Some thing went wrong please try again')", true);
            }
        }
        public void ClearRecords()
        {
            txtWorkoutName.Text = "";
            txtWorkoutDes.Text = "";
            rbprogramName.ClearSelection();
            
        }
        public void getAllWorkout()
        {
            try
            {

                string mySql = @"Select WorkOutId, WorkOutName , WorkOutDescription , ProgramName from WorkOut as w inner join Programs as p on w.ProgramId=p.ProgramID;";
                var mycommand = cr.getDrPassSql(mySql);
                GvWorkout.DataSource = mycommand;
                GvWorkout.DataBind();

            }

            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Some thing went wrong please try again')", true);

            }
            finally
            {
                cr.con.Close();

            }
        }
        protected void LbWorkoutID_Click(object sender, EventArgs e)
        {
            LinkButton mySender = sender as LinkButton;
            int WorkoutId = int.Parse(mySender.Text);
            Session["WorkoutId"] = WorkoutId;
            string mySql = @"select * from WorkOut where WorkOutId=@WorkoutId";
            Dictionary<string, object> InputParaList = new Dictionary<string, object>();
            InputParaList.Add("@WorkoutId", WorkoutId);
            SqlDataReader dr = cr.getDrPassSqlDic(mySql, InputParaList);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    txtWorkoutName.Text = dr["WorkOutName"].ToString();
                    txtWorkoutDes.Text = dr["WorkOutDescription"].ToString();
                    
                    rbprogramName.SelectedValue = dr["ProgramId"].ToString();
                  
                }
            }
        }

        protected void btnUpdateWorkout_Click(object sender, EventArgs e)
        {
            
            string mySql = @"update WorkOut set
                            WorkOutName= @WorkOutName, WorkOutDescription=@WorkOutDescription, 
                             ProgramId=@ProgramId where WorkOutId=@WorkOutId";
            Dictionary<string, object> InputParaList = new Dictionary<string, object>();
            InputParaList.Add("@WorkOutId", Session["WorkoutId"]);
            InputParaList.Add("@WorkOutName", txtWorkoutName.Text);
            InputParaList.Add("@WorkOutDescription", txtWorkoutDes.Text);
            InputParaList.Add("@ProgramId", int.Parse(rbprogramName.SelectedItem.Value));
            int rtn = cr.InsertUpdateDeleteViaSqlDic(mySql, InputParaList);
            ClearRecords();
            if (rtn >= 1)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Workout Updated Successful')", true);
                ClearRecords();
                getAllWorkout();

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Workout Updated Faild,Please try Again')", true);
            }

        }

        protected void btnDelWorkout_Click(object sender, EventArgs e)
        {

            string mySql = @"delete from WorkOut where  WorkOutId=@WorkOutId";
            Dictionary<string, object> InputParaList = new Dictionary<string, object>();
            InputParaList.Add("@WorkOutId", Session["WorkoutId"]);
            int rtn = cr.InsertUpdateDeleteViaSqlDic(mySql, InputParaList);

            if (rtn >= 1)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('WorkOut Deleted Successful')", true);
                ClearRecords();
                getAllWorkout();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('WorkOut Deleted Faild,Please try Again')", true);
            }

        }

        protected void btnClearWorkout_Click(object sender, EventArgs e)
        {
            ClearRecords();
        }
    }
}