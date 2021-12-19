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
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                getProgramInfo();
                getUserInfo();
                getExerInfo();
            }
        }


        bool ValidateEmpty(string empty)
        {
            if (empty == "")
            {
                return true;
            }
            else
            {
                return false;

            }
        }
        protected void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            if(ValidateEmpty(txtName.Text) || ValidateEmpty(txtEmail.Text) || ValidateEmpty(txtNumber.Text) )
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('you must inter all feilds')", true);

            }
            else if (rbFemale.Checked != true & rbMale.Checked != true)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('you must select your gender')", true);

            }
            else
            {
                UpdateUserInfo();
            }

        }
        void UpdateUserInfo()
        {
            string mySql = @"update Users set
                            UserName= @UserName, UserEmail=@UserEmail, 
                            UserPhone=@UserPhone,UserGender=@gender where UserId=@UserId";
            Dictionary<string, object> InputParaList = new Dictionary<string, object>();
            InputParaList.Add("@UserId", Session["UserId"]);
            InputParaList.Add("@UserName", txtName.Text);
            InputParaList.Add("@UserEmail", txtEmail.Text);
            InputParaList.Add("@UserPhone", int.Parse(txtNumber.Text));
            string gender = string.Empty;
            if (rbMale.Checked)
            {
                gender = "Male";
            }
            else if (rbFemale.Checked)
            {
                gender = "Female";
            }
            InputParaList.Add("@gender", gender);
            int rtn = cr.InsertUpdateDeleteViaSqlDic(mySql, InputParaList);
           
            if (rtn >= 1)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your Profile Updated Successfully')", true);
                

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(' Faild,Please try Again')", true);
            }
        }
        CRUD cr = new CRUD();
        void getUserInfo()
        {
            string mySql = @"select * from Users where UserId=@UserId";
            Dictionary<string, object> InputParaList = new Dictionary<string, object>();
            var UserId = Session["UserId"];
            InputParaList.Add("@UserId", UserId);
            SqlDataReader dr = cr.getDrPassSqlDic(mySql, InputParaList);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    txtName.Text = dr["UserName"].ToString();
                    txtEmail.Text = dr["UserEmail"].ToString();
                    string gender= dr["UserGender"].ToString().Trim();
                    if(gender== "Female")
                    {
                        rbFemale.Checked = true;
                    }
                    else
                    {
                        rbMale.Checked = true;
                    }
                    txtNumber.Text = dr["UserPhone"].ToString();
                    txtId.Text = UserId.ToString();
                }
            }
        }
        void getProgramInfo()
        {
            try
            {
                //  if () { }

                if (cr.con.State == ConnectionState.Closed)
                {
                    cr.con.Open();
                }
                var UserId = Session["UserId"];
                string mySql = @"Select Day1,Day2,Day3,Day4,Day5,Day6,Calories from Subscrption Where UserId=@UserId;";
                Dictionary<string, object> InputParaList = new Dictionary<string, object>();
                InputParaList.Add("@UserId", UserId);
                var dr = cr.getDrPassSqlDic(mySql, InputParaList);
                gvProgramInfo.DataSource = dr;
                gvProgramInfo.DataBind();
               
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
               

            }
        }
        void getExerInfo()
        {
            try
            {
                //  if () { }

                if (cr.con.State == ConnectionState.Closed)
                {
                    cr.con.Open();
                }
                string sqls = @"Select ProgramId from Subscrption where UserId=@UserId";
                Dictionary<string, object> InputParaList = new Dictionary<string, object>();
                var UserId = Session["UserId"];
                InputParaList.Add("@UserId", UserId);
                SqlDataReader dr = cr.getDrPassSqlDic(sqls, InputParaList);
               // int ProgramId = 0;
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Session["ProgramId"] =int.Parse(dr["ProgramId"].ToString());
                    }
                }

                        //var UserId = Session["UserId"];
                string mySql = @"Select WorkOutName , WorkOutDescription from WorkOut where ProgramId=@programId;";
                Dictionary<string, object> InputParaList1 = new Dictionary<string, object>();
                InputParaList1.Add("@ProgramId", Session["ProgramId"]);
                SqlDataReader dr1 = cr.getDrPassSqlDic(mySql, InputParaList1);
                gvExer.DataSource = dr1;
                gvExer.DataBind();

                    }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");


            }
        }
        protected void btnDeleteProgram_Click(object sender, EventArgs e)
        {

            string mySql = @"delete from Subscrption where UserId=@UserId";
            Dictionary<string, object> InputParaList = new Dictionary<string, object>();
            var UserId = Session["UserId"];
            InputParaList.Add("@UserId", UserId);
            int rtn = cr.InsertUpdateDeleteViaSqlDic(mySql, InputParaList);

            if (rtn >= 1)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Program Deleted Successfully you can join other program')", true);
                Session["ProgramId"] = null;
                getExerInfo();
                getProgramInfo();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Faild,Please try Again')", true);
            }
        }
    }
}