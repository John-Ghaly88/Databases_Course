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
    public partial class viewpromocode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ConnStr = WebConfigurationManager.ConnectionStrings["GIUera"].ToString();
            SqlConnection Conn = new SqlConnection(ConnStr);

            int sid = ((int)Session["user"]);

            SqlCommand p = new SqlCommand("viewPromoCode", Conn);
            p.CommandType = CommandType.StoredProcedure;


            p.Parameters.Add(new SqlParameter("@sid", sid));

            Conn.Open();
            SqlDataReader rdr = p.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                promo.Controls.Add(new LiteralControl("<br>"));
                promo.Controls.Add(new LiteralControl("Code: "));
                string c = rdr.GetString(rdr.GetOrdinal("code"));
                Label lc = new Label();
                lc.Text = c;
                promo.Controls.Add(lc);
                promo.Controls.Add(new LiteralControl("<br>"));

                promo.Controls.Add(new LiteralControl("Issue Date: "));
                DateTime idate = rdr.GetDateTime(rdr.GetOrdinal("issueDate"));
                Label lidate = new Label();
                lidate.Text = idate.ToString();
                promo.Controls.Add(lidate);
                promo.Controls.Add(new LiteralControl("<br>"));

                promo.Controls.Add(new LiteralControl("Expiry Date: "));
                DateTime edate = rdr.GetDateTime(rdr.GetOrdinal("expiryDate"));
                Label ledate = new Label();
                ledate.Text = edate.ToString();
                promo.Controls.Add(ledate);
                promo.Controls.Add(new LiteralControl("<br>"));

                promo.Controls.Add(new LiteralControl("Discount Percentage: "));
                string dis = rdr["discount"].ToString();
                Label ldis = new Label();
                ldis.Text = dis;
                promo.Controls.Add(ldis);
                promo.Controls.Add(new LiteralControl("%"));
                promo.Controls.Add(new LiteralControl("<br>"));
                promo.Controls.Add(new LiteralControl("---------------------------------------------------------"));
                promo.Controls.Add(new LiteralControl("<br>"));

/*              promo.Controls.Add(new LiteralControl("Admin ID: "));
                string aid = rdr["adminId"].ToString();
                Label laid = new Label();
                laid.Text = aid;
                promo.Controls.Add(laid);
                promo.Controls.Add(new LiteralControl("<br>"));
                promo.Controls.Add(new LiteralControl("---------------------------------------------------------"));
                promo.Controls.Add(new LiteralControl("<br>"));
*/
            }
        }

        protected void back6_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx");
        }
    }
}