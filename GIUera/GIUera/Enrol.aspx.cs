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
    public partial class Enrol : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void course_information_Click(object sender, EventArgs e)
        {
            string ConnStr = WebConfigurationManager.ConnectionStrings["GIUera"].ToString();
            SqlConnection Conn = new SqlConnection(ConnStr);

            int cid = Int16.Parse(TextBox1.Text);

            SqlCommand p = new SqlCommand("courseInformation", Conn);
            p.CommandType = CommandType.StoredProcedure;

            p.Parameters.Add(new SqlParameter("@id", cid));

            Conn.Open();
            SqlDataReader rdr = p.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                en.Controls.Add(new LiteralControl("<br>"));
                en.Controls.Add(new LiteralControl("Course ID: "));
                string co_id = TextBox1.Text;
                Label lid = new Label();
                lid.Text = co_id;
                en.Controls.Add(lid);
                en.Controls.Add(new LiteralControl("<br>"));

                en.Controls.Add(new LiteralControl("Credit Hours: "));
                string ch = rdr["creditHours"].ToString();
                Label lch = new Label();
                lch.Text = ch;
                en.Controls.Add(lch);
                en.Controls.Add(new LiteralControl("<br>"));

                en.Controls.Add(new LiteralControl("Course Name: "));
                string cn = rdr["name"].ToString();
                Label ln = new Label();
                ln.Text = cn;
                en.Controls.Add(ln);
                en.Controls.Add(new LiteralControl("<br>"));

                en.Controls.Add(new LiteralControl("Course Description: "));
                string cd = rdr["courseDescription"].ToString();
                Label ld = new Label();
                ld.Text = cd;
                en.Controls.Add(ld);
                en.Controls.Add(new LiteralControl("<br>"));

                en.Controls.Add(new LiteralControl("Price: € "));
                string price = rdr["price"].ToString();
                Label lprice = new Label();
                lprice.Text = price;
                en.Controls.Add(lprice);
                en.Controls.Add(new LiteralControl("<br>"));

 /*             en.Controls.Add(new LiteralControl("Admin ID: "));
                string aid = rdr["adminId"].ToString();
                Label laid = new Label();
                laid.Text = aid;
                en.Controls.Add(laid);
                en.Controls.Add(new LiteralControl("<br>"));

                en.Controls.Add(new LiteralControl("Accepted state: "));
                bool acc = rdr.GetBoolean(rdr.GetOrdinal("accepted"));
                Label lacc = new Label();
                if (acc)
                    lacc.Text = "accepted by the admin";
                else if (!acc)
                    lacc.Text = "not accepted yet";
                en.Controls.Add(lacc);
                en.Controls.Add(new LiteralControl("<br>"));
*/
                en.Controls.Add(new LiteralControl("Instructor ID: "));
                string iid = rdr["instructorId"].ToString();
                Label liid = new Label();
                liid.Text = iid;
                en.Controls.Add(liid);
                en.Controls.Add(new LiteralControl("<br>"));

                en.Controls.Add(new LiteralControl("Instructor Name: Dr."));
                string fn = rdr["firstName"].ToString();
                Label lfn = new Label();
                lfn.Text = fn;
                en.Controls.Add(lfn);
                en.Controls.Add(new LiteralControl("&nbsp"));

                string lastn = rdr["lastName"].ToString();
                Label lln = new Label();
                lln.Text = lastn;
                en.Controls.Add(lln);
                en.Controls.Add(new LiteralControl("<br>"));
                en.Controls.Add(new LiteralControl("---------------------------------------------------------"));
                en.Controls.Add(new LiteralControl("<br>"));
            }
        }

        protected void done_Click(object sender, EventArgs e)
        {
            string ConnStr = WebConfigurationManager.ConnectionStrings["GIUera"].ToString();
            SqlConnection Conn = new SqlConnection(ConnStr);

            int sid = ((int)Session["user"]);
            int cid = Int16.Parse(TextBox1.Text);
            int iid = Int16.Parse(TextBox2.Text);

            SqlCommand enrolling = new SqlCommand("enrollInCourse", Conn);
            enrolling.CommandType = CommandType.StoredProcedure;

            enrolling.Parameters.Add(new SqlParameter("@sid", sid));
            enrolling.Parameters.Add(new SqlParameter("@cid", cid));
            enrolling.Parameters.Add(new SqlParameter("@instr", iid));

            Conn.Open();
            enrolling.ExecuteNonQuery();
            Conn.Close();

            Response.Redirect("StudentHome.aspx");
        }
    }
}