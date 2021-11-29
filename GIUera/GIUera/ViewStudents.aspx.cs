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
    public partial class ViewStudents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ConnStr = WebConfigurationManager.ConnectionStrings["GIUera"].ToString();
            SqlConnection Conn = new SqlConnection(ConnStr);

            SqlCommand courses = new SqlCommand("AdminListAllStudents", Conn);
            courses.CommandType = System.Data.CommandType.StoredProcedure;

            Conn.Open();
            SqlDataReader rdr = courses.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                String firstName = rdr.GetString(rdr.GetOrdinal("firstName"));
                Label name = new Label();
                name.Text = firstName;
                form1.Controls.Add(name);

                form1.Controls.Add(new LiteralControl("&nbsp"));

                String lastName = rdr.GetString(rdr.GetOrdinal("lastName"));
                Label lname = new Label();
                lname.Text = lastName;
                form1.Controls.Add(lname);

                form1.Controls.Add(new LiteralControl("<br>"));
            }
        }

        protected void Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminHome.aspx");
        }
    }
}
