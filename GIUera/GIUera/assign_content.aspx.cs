using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GIUera
{
    public partial class assign_content : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void viewcontent(object sender, EventArgs e)
        {
            string ConnStr = WebConfigurationManager.ConnectionStrings["GIUera"].ToString();
            SqlConnection Conn = new SqlConnection(ConnStr);
            int sid = ((int)Session["user"]);
            int cid = Int16.Parse(courseid.Text);

            SqlCommand viewassignments = new SqlCommand("viewAssign", Conn);
            viewassignments.CommandType = CommandType.StoredProcedure;

            viewassignments.Parameters.Add(new SqlParameter("@courseId", cid));
            viewassignments.Parameters.Add(new SqlParameter("@Sid", sid));

            Conn.Open();
            SqlDataReader rdr = viewassignments.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                form1.Controls.Add(new LiteralControl("<br>"));
                string courseid = rdr["cid"].ToString();
                Label coid = new Label();
                coid.Text = courseid;
                form1.Controls.Add(coid);
                form1.Controls.Add(new LiteralControl("<br>"));

                string numb = rdr["number"].ToString();
                Label num = new Label();
                num.Text = numb;
                form1.Controls.Add(num);
                form1.Controls.Add(new LiteralControl("<br>"));

                string atype = rdr["type"].ToString();
                Label ty = new Label();
                ty.Text = atype;
                form1.Controls.Add(ty);
                form1.Controls.Add(new LiteralControl("<br>"));

                string aweight = rdr["weight"].ToString();
                Label w = new Label();
                w.Text = aweight;
                form1.Controls.Add(w);
                form1.Controls.Add(new LiteralControl("<br>"));

                string fullgr = rdr["fullGrade"].ToString();
                Label fg = new Label();
                fg.Text = fullgr;
                form1.Controls.Add(fg);
                form1.Controls.Add(new LiteralControl("<br>"));

                string adeadline = rdr["deadline"].ToString();
                Label dl = new Label();
                dl.Text = adeadline;
                form1.Controls.Add(dl);
                form1.Controls.Add(new LiteralControl("<br>"));

                string cont = rdr["content"].ToString();
                Label content = new Label();
                content.Text = cont;
                form1.Controls.Add(content);
                form1.Controls.Add(new LiteralControl("<br>"));
            }
            //Response.Redirect("assignmentContent.aspx");
        }

        protected void home_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx");
        }
    }
}