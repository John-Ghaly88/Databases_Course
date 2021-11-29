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
    public partial class IssueCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Issue_Click(object sender, EventArgs e)
        {
            string ConnStr = WebConfigurationManager.ConnectionStrings["GIUera"].ToString();
            SqlConnection Conn = new SqlConnection(ConnStr);

            int sid = Int16.Parse(Sid.Text);
            String pid = PromoCode.Text;

            SqlCommand Issue = new SqlCommand("AdminIssuePromocodeToStudent", Conn);
            Issue.CommandType = CommandType.StoredProcedure;

            Issue.Parameters.Add(new SqlParameter("@sid",sid));
            Issue.Parameters.Add(new SqlParameter("@pid",pid));

            Conn.Open();
            Issue.ExecuteNonQuery();
            Conn.Close();
        }

        protected void Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminHome.aspx");
        }
    }
}