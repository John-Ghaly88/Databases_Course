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
    public partial class view_course_content : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void done_Click(object sender, EventArgs e)
        {
            string ConnStr = WebConfigurationManager.ConnectionStrings["GIUera"].ToString();
            SqlConnection Conn = new SqlConnection(ConnStr);

            int id = ((int)Session["user"]);
            int cid = Int16.Parse(TextBox1.Text);

            SqlCommand cc = new SqlCommand("enrollInCourseViewContent", Conn);
            cc.CommandType = CommandType.StoredProcedure;

            cc.Parameters.Add(new SqlParameter("@id", id));
            cc.Parameters.Add(new SqlParameter("@cid", cid));

            Conn.Open();
            SqlDataReader rdr = cc.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                course_content.Controls.Add(new LiteralControl("<br>"));
                string con = rdr.GetString(rdr.GetOrdinal("content"));
                Label lcon = new Label();
                lcon.Text = con;
                course_content.Controls.Add(lcon);
            }
        }


        protected void back7_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx");
        }
    }
}