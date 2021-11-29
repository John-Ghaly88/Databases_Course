using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GIUera
{
    public partial class viewcourses_Student : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ConnStr = WebConfigurationManager.ConnectionStrings["GIUera"].ToString();
            SqlConnection Conn = new SqlConnection(ConnStr);

            SqlCommand courses = new SqlCommand("availableCourses", Conn);

            Conn.Open();
            SqlDataReader rdr = courses.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            available_courses.Controls.Add(new LiteralControl("<br>"));
            while (rdr.Read())
            {
                available_courses.Controls.Add(new LiteralControl("<br>"));
                available_courses.Controls.Add(new LiteralControl("Course name: "));
                string cname = rdr["name"].ToString();
                Label course_name = new Label();
                course_name.Text = cname;
                available_courses.Controls.Add(course_name);
                available_courses.Controls.Add(new LiteralControl("<br>"));

                available_courses.Controls.Add(new LiteralControl("Course ID: "));
                string cid = rdr["id"].ToString();
                Label course_id = new Label();
                course_id.Text = cid;
                available_courses.Controls.Add(course_id);
                available_courses.Controls.Add(new LiteralControl("<br>"));
                available_courses.Controls.Add(new LiteralControl("---------------------------------------------------------"));
            }
        }

        protected void back3_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx");
        }
    }
}