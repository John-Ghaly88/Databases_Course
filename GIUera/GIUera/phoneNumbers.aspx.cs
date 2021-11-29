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
    public partial class phoneNumbers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("Your id is: ");
            Response.Write((string)Session["registered"]);
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            string ConnStr = WebConfigurationManager.ConnectionStrings["GIUera"].ToString();
            SqlConnection Conn = new SqlConnection(ConnStr);

            int ID = Int16.Parse((string)Session["registered"]);
            String number = phonenumber.Text;

            SqlCommand addmobileNumber = new SqlCommand("addMobile", Conn);
            addmobileNumber.CommandType = CommandType.StoredProcedure;

            addmobileNumber.Parameters.Add(new SqlParameter("@ID", ID));
            addmobileNumber.Parameters.Add(new SqlParameter("@mobile_number", number));

            Conn.Open();
            addmobileNumber.ExecuteNonQuery();
            Conn.Close();

            Response.Redirect("phoneNumbers.aspx");
        }

        protected void done_Click(object sender, EventArgs e)
        {
            string ConnStr = WebConfigurationManager.ConnectionStrings["GIUera"].ToString();
            SqlConnection Conn = new SqlConnection(ConnStr);

            int ID = Int16.Parse((string)Session["registered"]);
            String number = phonenumber.Text;

            SqlCommand addmobileNumber = new SqlCommand("addMobile", Conn);
            addmobileNumber.CommandType = CommandType.StoredProcedure;

            addmobileNumber.Parameters.Add(new SqlParameter("@ID", ID));
            addmobileNumber.Parameters.Add(new SqlParameter("@mobile_number", number));

            Conn.Open();
            addmobileNumber.ExecuteNonQuery();
            Conn.Close();

            Response.Redirect("Login.aspx");

        }
    }
}