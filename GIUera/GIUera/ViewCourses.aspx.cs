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
    public partial class ViewCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ConnStr = WebConfigurationManager.ConnectionStrings["GIUera"].ToString();
            SqlConnection Conn = new SqlConnection(ConnStr);

            SqlCommand courses = new SqlCommand("AdminViewAllCourses", Conn);
            courses.CommandType = System.Data.CommandType.StoredProcedure;

            Conn.Open();
            SqlDataReader rdr = courses.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                form1.Controls.Add(new LiteralControl("<br>"));
                String courseName = rdr.GetString(rdr.GetOrdinal("name"));
                Label name = new Label();
                name.Text = courseName;
                form1.Controls.Add(name);

                form1.Controls.Add(new LiteralControl("&nbsp"));

                string ch = rdr["creditHours"].ToString();
                Label creditH = new Label();
                creditH.Text = ch;
                form1.Controls.Add(creditH);

                form1.Controls.Add(new LiteralControl("&nbsp"));

                string p = rdr["price"].ToString();
                Label price = new Label();
                price.Text = p;
                form1.Controls.Add(price);

                form1.Controls.Add(new LiteralControl("&nbsp"));

                bool ac = rdr.GetBoolean(rdr.GetOrdinal("accepted"));
                Label accepted = new Label();
                if (ac)
                    accepted.Text = "Accepted";
                else if (!ac)
                    accepted.Text = "Not Accepted";
                form1.Controls.Add(accepted);

                form1.Controls.Add(new LiteralControl("<br>"));

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("NonAcceptedCourses.aspx");
        }

        protected void home_Click1(object sender, EventArgs e)
        {
            Response.Redirect("AdminHome.aspx");
        }
    }
}