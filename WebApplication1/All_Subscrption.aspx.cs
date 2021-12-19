using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.App_Code;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

namespace WebApplication1
{
    public partial class All_Subscrption : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                getAllSubscrption();
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
        private void ExportGrid(string fileName, string contentType)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=" + fileName);
            Response.Charset = "";
            Response.ContentType = contentType;

            StringWriter sw = new StringWriter();
            HtmlTextWriter HW = new HtmlTextWriter(sw);

            gvAllSubscrption.RenderControl(HW);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.Close();
            Response.End();
        }
        CRUD cr = new CRUD();
        void getAllSubscrption()
        {


            try
            {
                //  if () { }

                if (cr.con.State == ConnectionState.Closed)
                {
                    cr.con.Open();
                }
                var UserId = Session["UserId"];
                string mySql = @"Select UserName,UserEmail,ProgramName,Calories,
                            Day1,Day2,Day3,Day4,Day5,Day6 from Subscrption as s inner join Users as u on s.UserId=u.UserId 
                            inner join Programs as p on s.ProgramId=p.ProgramId;";
                Dictionary<string, object> InputParaList = new Dictionary<string, object>();
                InputParaList.Add("@UserId", UserId);
                var dr = cr.getDrPassSqlDic(mySql, InputParaList);
                gvAllSubscrption.DataSource = dr;
                gvAllSubscrption.DataBind();

            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");


            }
        

        }

        protected void btnExportEx_Click(object sender, EventArgs e)
        {
            ExportGrid("AllSubscrption.xls", "application/vnd.ms-excel");
        }

        protected void btnExportWord_Click(object sender, EventArgs e)
        {
            ExportGrid("AllSubscrption.doc", "application/vnd.ms-word");
        }

        protected void btnExportpdf_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=AllSubscrption.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            gvAllSubscrption.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
#pragma warning disable CS0612 // Type or member is obsolete  
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
#pragma warning restore CS0612 // Type or member is obsolete  
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();

            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
            gvAllSubscrption.AllowPaging = true;
            gvAllSubscrption.DataBind();
        }
    }
}