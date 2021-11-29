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
    public partial class CreatePromoCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Create_Click(object sender, EventArgs e)
        {
            string ConnStr = WebConfigurationManager.ConnectionStrings["GIUera"].ToString();
            SqlConnection Conn = new SqlConnection(ConnStr);

            String code = Code.Text;
            DateTime issueDate = DateTime.Parse(IssueDate.Text);
            DateTime expiryDate = DateTime.Parse(ExpiryDate.Text);
            decimal discount = Decimal.Parse(DiscountAmount.Text);
            int id = Int16.Parse(ID.Text);

            SqlCommand Create = new SqlCommand("AdminCreatePromocode", Conn);
            Create.CommandType = CommandType.StoredProcedure;

            Create.Parameters.Add(new SqlParameter("@code", code));
            Create.Parameters.Add(new SqlParameter("@issueDate", issueDate));
            Create.Parameters.Add(new SqlParameter("@expiryDate", expiryDate));
            Create.Parameters.Add(new SqlParameter("@discount", discount));
            Create.Parameters.Add(new SqlParameter("@adminId", id));

            Conn.Open();
            Create.ExecuteNonQuery();
            Conn.Close();

            Response.Redirect("CreatePromoCode.aspx");
        }

        protected void Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminHome.aspx");
        }

        protected void Issue_Click(object sender, EventArgs e)
        {
            Response.Redirect("IssueCode.aspx");
        }
    }
}