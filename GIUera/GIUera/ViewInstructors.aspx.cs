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
    public partial class ViewInstructors : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ConnStr = WebConfigurationManager.ConnectionStrings["GIUera"].ToString();
            SqlConnection Conn = new SqlConnection(ConnStr);

            SqlCommand courses = new SqlCommand("AdminListInstr", Conn);
            courses.CommandType = System.Data.CommandType.StoredProcedure;

            Conn.Open();
            SqlDataReader rdr = courses.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                String ifn = rdr.GetString(rdr.GetOrdinal("firstName"));
                Label name = new Label();
                name.Text = ifn;
                form1.Controls.Add(name);

                form1.Controls.Add(new LiteralControl("&nbsp"));


                String iln = rdr.GetString(rdr.GetOrdinal("lastName"));
                Label lname = new Label();
                lname.Text = iln;
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