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
    public partial class viewcert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cert_Click(object sender, EventArgs e)
        {
            string ConnStr = WebConfigurationManager.ConnectionStrings["GIUera"].ToString();
            SqlConnection Conn = new SqlConnection(ConnStr);

            int sid = ((int)Session["user"]);
            int cid = Int16.Parse(courseid.Text);

            SqlCommand certificate = new SqlCommand("viewCertificate", Conn);
            certificate.CommandType = CommandType.StoredProcedure;

            certificate.Parameters.Add(new SqlParameter("@sid", sid));
            certificate.Parameters.Add(new SqlParameter("@cid", cid));

            Conn.Open();
            SqlDataReader rdr = certificate.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            while (rdr.Read())
            {

                form1.Controls.Add(new LiteralControl("<br>"));
                string studid = sid.ToString();
                Label sd = new Label();
                sd.Text = studid;
                form1.Controls.Add(sd);

                form1.Controls.Add(new LiteralControl("<br>"));
                string courseid = rdr["cid"].ToString();
                Label cd = new Label();
                cd.Text = courseid;
                form1.Controls.Add(cd);

                form1.Controls.Add(new LiteralControl("<br>"));
                DateTime issued = rdr.GetDateTime(rdr.GetOrdinal("issueDate"));
                Label issuedate = new Label();
                issuedate.Text = issued.ToString();
                form1.Controls.Add(issuedate);
            }
        }

        protected void home_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx");
        }
    }
}