using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Net;
using System.Net.Mail;
using WebApplication1.App_Code;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class regestration : System.Web.UI.Page
    {
        
        CRUD cr = new CRUD();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegUser_Click(object sender, EventArgs e)
        {
            if (checkMemberExists())
            {
                Response.Write("<script>alert('This Email already exists, try another Email');</script>");
            }
            else if(ValidateEmpty(txtName.Text) || ValidateEmpty(txtEmail.Text) || ValidateEmpty(txtPassword.Text) || ValidateEmpty(phone.Text) || ValidateEmpty(rbGender.SelectedItem.Text))
            {
                Response.Write("<script>alert('Please fill all the fields');</script>");
            }
            else
            {
                MailMessage ms = new MailMessage();
                ms.From = new MailAddress("alotibiAlya@gmail.com");
                ms.To.Add(txtEmail.Text);
                ms.Subject = "Thank you for signing up on CyberGym!";
                ms.Body = "One step can change your life and you made it!! \n go to the website and choose your goal ";

                SmtpClient sc = new SmtpClient("smtp.gmail.com", 587);
                sc.Port = 587;
                sc.Credentials = new NetworkCredential("alotibiAlya@gmail.com", "@");
                sc.EnableSsl = true;
                sc.Send(ms);
                signUpNewUser();
                ClearRecords();
            }
        }
        public void ClearRecords()
        {
            txtName.Text = "";
            phone.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            rbGender.ClearSelection();
            
        }
        bool checkMemberExists()
        {
            try
            {
                //  if () { }
               
                if (cr.con.State == ConnectionState.Closed)
                {
                    cr.con.Open();
                }
                string mySql = @"Select * from Users where UserEmail = @UserEmail;";
                Dictionary<string, object> InputParaList = new Dictionary<string, object>();
                InputParaList.Add("@UserEmail",txtEmail.Text);
                SqlDataReader dr = cr.getDrPassSqlDic(mySql, InputParaList);
                bool stat = false;
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {


                        string id = dr["UserEmail"].ToString();


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
                //int mycommand = cr.InsertUpdateDeleteViaSqlDic(mySql, InputParaList);

                //if (mycommand >= 1)
                //{
                //    return true;
                //}
                //else
                //{
                //    return false;
                //}
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
            finally
            {
                cr.con.Close();
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
        void signUpNewUser()
        {
            string name = txtName.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string gender = rbGender.SelectedItem.Text;
            //string instructorPhone = phone.Text;
            //string instructorEmail = txtEmail.Text;
            //string Pass = txtPassword.Text;
            string mySql = @"INSERT INTO Users(UserName,UserEmail, password,UserPhone,UserGender,roleId)
                    values(@UserName,@UserEmail,@password,@UserPhone,@UserGender,@roleId)";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@UserName", name);
            myPara.Add("@UserEmail", email);
            myPara.Add("@password", password);
            myPara.Add("@UserPhone", int.Parse(phone.Text));
            myPara.Add("@UserGender", gender);
            myPara.Add("@roleId", 2);

            CRUD myCrud = new CRUD();

            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
            if (rtn >= 1)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(),
                                                        "alert", "alert('Sign Up Successful.you can Login');window.location ='Login.aspx';", true);
                //Response.Redirect("Login.aspx");
                //Response.Write("<script>alert('Sign Up Successful.you can Login');</script>");
            }

            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('try again')", true);
            }
        }
    }
}