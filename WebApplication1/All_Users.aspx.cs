using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.App_Code;

namespace WebApplication1
{
    public partial class All_Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                getAllUsers();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

        }
        CRUD cr = new CRUD();
        void getAllUsers()
        {


            try
            {
                //  if () { }

                if (cr.con.State == ConnectionState.Closed)
                {
                    cr.con.Open();
                }
                
                string mySql = @"Select UserName,UserEmail,UserGender,roleName from Users inner join roles on Users.roleId=roles.roleId;";
                var dr = cr.getDrPassSql(mySql);
                gvAllUsers.DataSource = dr;
                gvAllUsers.DataBind();

            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");


            }


        }
    }
}