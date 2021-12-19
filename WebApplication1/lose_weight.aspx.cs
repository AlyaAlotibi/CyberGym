using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.App_Code;

namespace WebApplication1
{
    public partial class lose_weight : System.Web.UI.Page
    {
        CRUD cr = new CRUD();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                getallWorkOut(chkExerciese);
                getallWorkOut(chkDay2);
                getallWorkOut(chkDay3);
                getallWorkOut(chkDay4);
                getallWorkOut(chkDay5);
                getallWorkOut(chkDay6);
            }
        }
        protected void btncalculate_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtcalories.Text) == 0)
            {
                lblDayesOfWorkout.Text = "you Should exercise .....";
            }
            else if (int.Parse(txtcalories.Text) >= 1500 && int.Parse(txtcalories.Text) < 1600)
            {
                lblDayesOfWorkout.Text = "you Should exercise 4-5 days in a week";
                lblDay1.Visible = true;
                chkExerciese.Visible = true;
                lblDay2.Visible = true;
                chkDay2.Visible = true;
                lblDay3.Visible = true;
                chkDay3.Visible = true;
                lblDay4.Visible = true;
                chkDay4.Visible = true;
                lblDay5.Visible = true;
                chkDay5.Visible = true;
                lblDay6.Visible = false;
                chkDay6.Visible = false;
                lblEx.Visible = true;

            }
            else if (int.Parse(txtcalories.Text) >= 1600)
            {
                lblDayesOfWorkout.Text = "you Should exercise 6 days in a week";
                lblDay1.Visible = true;
                chkExerciese.Visible = true;
                lblDay2.Visible = true;
                chkDay2.Visible = true;
                lblDay3.Visible = true;
                chkDay3.Visible = true;
                lblDay4.Visible = true;
                chkDay4.Visible = true;
                lblDay5.Visible = true;
                chkDay5.Visible = true;
                lblDay6.Visible = true;
                chkDay6.Visible = true;
                lblEx.Visible = true;
            }
            else if (int.Parse(txtcalories.Text) <= 1300)
            {
                lblDayesOfWorkout.Text = "you Should exercise 1-2 days in a week";
                lblDay1.Visible = true;
                chkExerciese.Visible = true;
                lblDay2.Visible = true;
                chkDay2.Visible = true;
                lblDay3.Visible = false;
                chkDay3.Visible = false;
                lblDay4.Visible = false;
                chkDay4.Visible = false;
                lblDay5.Visible = false;
                chkDay5.Visible = false;
                lblDay6.Visible = false;
                chkDay6.Visible = false;
                lblEx.Visible = true;
            }
        }
        public void getallWorkOut(CheckBoxList chk)
        {
            try
            {

                string mySql = @"Select * from WorkOut where ProgramId=2;";
                var mycommand = cr.getDrPassSql(mySql);
                chk.DataTextField = "WorkOutName";
                chk.DataValueField = "WorkOutId";
                chk.DataSource = mycommand;
                chk.DataBind();

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

        protected void btnExer_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtcalories.Text) >= 1600)
            {
                if (chkExerciese.SelectedItem == null || chkDay2.SelectedItem == null || chkDay3.SelectedItem == null || chkDay4.SelectedItem == null || chkDay5.SelectedItem == null || chkDay6.SelectedItem == null)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select all 6 days')", true);
                }
                else if (checkProgramSubs())
                {
                    Response.Write("<script>alert('You already have program');</script>");
                }
                else
                {
                    SaveSub();
                }
            }
            else if (int.Parse(txtcalories.Text) >= 1500 && int.Parse(txtcalories.Text) < 1600)
            {
                if (chkExerciese.SelectedItem == null || chkDay2.SelectedItem == null || chkDay3.SelectedItem == null || chkDay4.SelectedItem == null)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select all 4 days at least')", true);
                }
                else if (checkProgramSubs())
                {
                    Response.Write("<script>alert('You already have program');</script>");
                }
                else
                {
                    SaveSub();
                }
            }
            else if (int.Parse(txtcalories.Text) <= 1300)
            {
                if (chkExerciese.SelectedItem == null)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select at least day1 days ')", true);
                }
                else if (checkProgramSubs())
                {
                    Response.Write("<script>alert('You already have program');</script>");
                }
                else
                {
                    SaveSub();
                }
            }

        }
        bool checkProgramSubs()
        {
            try
            {
                //  if () { }

                if (cr.con.State == ConnectionState.Closed)
                {
                    cr.con.Open();
                }
                var UserId = Session["UserId"];
                string mySql = @"Select * from Subscrption Where UserId=@UserId;";
                Dictionary<string, object> InputParaList = new Dictionary<string, object>();
                InputParaList.Add("@UserId", UserId);
                SqlDataReader dr = cr.getDrPassSqlDic(mySql, InputParaList);
                bool stat = false;
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {


                        int id = int.Parse(dr["UserId"].ToString());


                        if (id != null)
                        {
                            stat = true;
                            //return stat;
                        }
                        else
                        {
                            stat = false;
                            //return false;
                        }
                    }
                }
                return stat;
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;

            }
        }
        public void SaveSub()
        {
            var UserId = Session["UserId"];
            string mySql = @"insert into Subscrption values
                                (@ProgramId , @UserId , @Day1 , @Day2 ,@Day3  , @Day4 ,@Day5 , @Day6 ,@Calories)";
            Dictionary<string, object> InputParaList = new Dictionary<string, object>();
            InputParaList.Add("@ProgramId", 2);
            InputParaList.Add("@UserId", UserId);



            InputParaList.Add("@Day1", getCardioPerDay(chkExerciese));
            InputParaList.Add("@Day2", getCardioPerDay(chkDay2));
            if (chkDay3.SelectedItem == null)
            {
                InputParaList.Add("@Day3", "Rest");
            }
            else
            {
                InputParaList.Add("@Day3", getCardioPerDay(chkDay3));
            }
            if (chkDay4.SelectedItem == null)
            {
                InputParaList.Add("@Day4", "Rest");
            }
            else
            {
                InputParaList.Add("@Day4", getCardioPerDay(chkDay4));
            }
            if (chkDay5.SelectedItem == null)
            {
                InputParaList.Add("@Day5", "Rest");
            }
            else
            {
                InputParaList.Add("@Day5", getCardioPerDay(chkDay5));
            }
            if (chkDay6.SelectedItem == null)
            {
                InputParaList.Add("@Day6", "Rest");
            }
            else
            {
                InputParaList.Add("@Day6", getCardioPerDay(chkDay6));
            }

            InputParaList.Add("@Calories", int.Parse(txtcalories.Text));
            int mycommand = cr.InsertUpdateDeleteViaSqlDic(mySql, InputParaList);
            //ClearRecords();
            if (mycommand >= 1)
            {
                //sendEmail(studentemail, studentname);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your WorkOut Inserted Successful')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Some thing went wrong please try again')", true);
            }
        }
        public string getCardioPerDay(CheckBoxList ck)
        {
            string chkboxselect = "";
            try
            {
                for (int i = 0; i < ck.Items.Count; i++)
                {
                    if (ck.Items[i].Selected)
                    {
                        if (chkboxselect == "")
                        {
                            chkboxselect = ck.Items[i].ToString();

                        }
                        else
                        {
                            chkboxselect += "," + ck.Items[i].ToString();
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
            }
            return chkboxselect;

        }
    }
        }
