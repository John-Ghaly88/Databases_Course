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
    public partial class credit_card_details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void done_Click(object sender, EventArgs e)
        {
            string ConnStr = WebConfigurationManager.ConnectionStrings["GIUera"].ToString();
            SqlConnection Conn = new SqlConnection(ConnStr);

            int sid = ((int)Session["user"]);
            int num = Int32.Parse(TextBox1.Text);
            string holder = TextBox2.Text;
            DateTime exdate = Convert.ToDateTime(TextBox3.Text);
            string cvv = TextBox4.Text;

            SqlCommand creditcard = new SqlCommand("addCreditCard", Conn);
            creditcard.CommandType = CommandType.StoredProcedure;

            creditcard.Parameters.Add(new SqlParameter("@sid", sid));
            creditcard.Parameters.Add(new SqlParameter("@number", num));
            creditcard.Parameters.Add(new SqlParameter("@cardHolderName", holder));
            creditcard.Parameters.Add(new SqlParameter("@expiryDate", exdate));
            creditcard.Parameters.Add(new SqlParameter("@cvv", cvv));

            Conn.Open();
            creditcard.ExecuteNonQuery();
            Conn.Close();

            Response.Redirect("StudentHome.aspx");
        }
    }
}