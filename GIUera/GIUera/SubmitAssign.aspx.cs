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
    public partial class SubmitAssign : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void enter_Click(object sender, EventArgs e)
        {
            string ConnStr = WebConfigurationManager.ConnectionStrings["GIUera"].ToString();
            SqlConnection Conn = new SqlConnection(ConnStr);

            String atype = type.Text;
            int num = Int16.Parse(number.Text);
            int cid = Int16.Parse(courseid.Text);
            int sid = ((int)Session["user"]);

            SqlCommand submitassigments = new SqlCommand("submitAssign", Conn);
            submitassigments.CommandType = CommandType.StoredProcedure;

            submitassigments.Parameters.Add(new SqlParameter("@assignType", atype));
            submitassigments.Parameters.Add(new SqlParameter("@assignnumber", num));
            submitassigments.Parameters.Add(new SqlParameter("@sid", sid));
            submitassigments.Parameters.Add(new SqlParameter("@cid", cid));

            Conn.Open();
            submitassigments.ExecuteNonQuery();
            Conn.Close();
            Response.Write("Submitted Successfully");
            //Response.Redirect("SubmitAssign");
        }

        protected void home_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx");
        }
    }
}