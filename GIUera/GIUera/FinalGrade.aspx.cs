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
    public partial class FinalGrade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void fg_Click(object sender, EventArgs e)
        {
            string ConnStr = WebConfigurationManager.ConnectionStrings["GIUera"].ToString();
            SqlConnection Conn = new SqlConnection(ConnStr);

            int cid = Int16.Parse(courseid.Text);
            int sid = ((int)Session["user"]);

            SqlCommand finalgrade = new SqlCommand("viewFinalGrade", Conn);
            finalgrade.CommandType = CommandType.StoredProcedure;

            finalgrade.Parameters.Add(new SqlParameter("@sid", sid));
            finalgrade.Parameters.Add(new SqlParameter("@cid", cid));

            Conn.Open();
            SqlDataReader rdr = finalgrade.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                string fgrade = rdr["grade"].ToString();
                Label finalGrade = new Label();
                finalGrade.Text = fgrade;
                form1.Controls.Add(finalGrade);
            }
            //Response.Redirect("FinalGrade.aspx");
        }

        protected void home_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx");
        }
    }
}