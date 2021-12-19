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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        CRUD cr = new CRUD();
        protected void btnLogin(object sender, EventArgs e)
        {

            //try
            //{


                //SqlCommand cmd = new SqlCommand("select * from Users where UserEmail='" + txtlEmail.Text.Trim() + "' AND password='" + txtlpassword.Text.Trim() + "'", cr.con);
                //SqlDataReader dr = cmd.ExecuteReader();
                string mySql = @"select * from Users where UserEmail=@UserEmail AND password=@password";
                Dictionary<string, object> InputParaList = new Dictionary<string, object>();
                InputParaList.Add("@UserEmail", txtlEmail.Text.Trim());
                InputParaList.Add("@password", txtlpassword.Text.Trim());
                SqlDataReader dr = cr.getDrPassSqlDic(mySql, InputParaList);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        string email = dr["UserEmail"].ToString();
                        string name = dr["UserName"].ToString();
                        string password = dr["password"].ToString();
                        int role = int.Parse(dr["roleId"].ToString());
                    int id= int.Parse(dr["UserId"].ToString());
                    Session["UserId"] = id;
                    Session["UserEmail"] = email;
                    Session["UserName"] = name;
                    if (role == 1)
                        {
                            Session["role"] = "admin";
                        
                        Response.Redirect("home.aspx");
                        }
                        else
                        {
                            Session["role"] = "normal";
                       
                            Response.Redirect("Default.aspx");
                        }
                    }
                }


                else
                {
                    Response.Write("<script>alert('Invalid Email or Password please try again ' );</script>");
                }
            //}
            //catch (Exception ex)
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('catch')", true);

            //}
        }
    }
}