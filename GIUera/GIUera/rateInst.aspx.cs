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
    public partial class rateInst : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void rate_Click(object sender, EventArgs e)
        {
            string ConnStr = WebConfigurationManager.ConnectionStrings["GIUera"].ToString();
            SqlConnection Conn = new SqlConnection(ConnStr);

            float rate = float.Parse(rating.Text);
            int sid = ((int)Session["user"]);
            int instrid = Int16.Parse(instid.Text);

            SqlCommand rateInstr = new SqlCommand("rateInstructor", Conn);
            rateInstr.CommandType = CommandType.StoredProcedure;

            rateInstr.Parameters.Add(new SqlParameter("@rate", rate));
            rateInstr.Parameters.Add(new SqlParameter("@sid", sid));
            rateInstr.Parameters.Add(new SqlParameter("@instId", instrid));

            Conn.Open();
            rateInstr.ExecuteNonQuery();
            Conn.Close();
            Response.Write("Rating saved");
            //Response.Redirect("rateInst");
        }

        protected void home_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx");
        }
    }
}