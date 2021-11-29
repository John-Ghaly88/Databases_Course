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
    public partial class addFeedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void feedback_Click(object sender, EventArgs e)
        {
            string ConnStr = WebConfigurationManager.ConnectionStrings["GIUera"].ToString();
            SqlConnection Conn = new SqlConnection(ConnStr);
            String comment = cmnt.Text;
            int sid = ((int)Session["user"]);
            int cid = Int16.Parse(courseid.Text);

            SqlCommand feedback = new SqlCommand("addFeedBack", Conn);
            feedback.CommandType = CommandType.StoredProcedure;

            feedback.Parameters.Add(new SqlParameter("@sid", sid));
            feedback.Parameters.Add(new SqlParameter("@cid", cid));
            feedback.Parameters.Add(new SqlParameter("@comment", comment));

            Conn.Open();
            feedback.ExecuteNonQuery();
            Conn.Close();

            Response.Write("Thank you for your feedback!");
            //Response.Redirect("addFeedback.aspx");
        }

        protected void home_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx");
        }
    }
}