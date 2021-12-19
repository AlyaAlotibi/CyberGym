using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace WebApplication1
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage ms = new MailMessage();
                ms.From = new MailAddress("alotibiAlya@gmail.com");
                var to = "alotibiAlya@gmail.com";
                ms.To.Add(to);
                ms.Subject = txtSub.Text;
                string UserEmail = txtEmail.Text;
                string bodyMsg = txtmesg.Text;
                ms.Body = "Email Rec. from "+UserEmail+" and the Body \n "+bodyMsg;

                SmtpClient sc = new SmtpClient("smtp.gmail.com", 587);
                sc.Port = 587;
                sc.Credentials = new NetworkCredential("alotibiAlya@gmail.com", "@Shood12345");
                sc.EnableSsl = true;
                sc.Send(ms);
                lblOut.Text = "Email was sent! we will reply as soon as possible";
                lblOut.Visible = true;
            }
            catch
            {
                lblOut.Text = "Wrong";
                lblOut.Visible = true;
            }
        }
    }
}