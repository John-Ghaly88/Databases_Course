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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login(object sender, EventArgs e)
        {
            string ConnStr = WebConfigurationManager.ConnectionStrings["GIUera"].ToString();
            SqlConnection Conn = new SqlConnection(ConnStr);

            int id = Int16.Parse(ID.Text);
            String pass = password.Text;

            SqlCommand loginproc = new SqlCommand("userLogin", Conn);
            loginproc.CommandType = CommandType.StoredProcedure;

            loginproc.Parameters.Add(new SqlParameter("@ID", id));
            loginproc.Parameters.Add(new SqlParameter("@password", pass));

            SqlParameter Success = loginproc.Parameters.Add("@Success", SqlDbType.Int);
            SqlParameter type = loginproc.Parameters.Add("@type", SqlDbType.Int);

            Success.Direction = ParameterDirection.Output;
            type.Direction = ParameterDirection.Output;

            Conn.Open();
            loginproc.ExecuteNonQuery();
            Conn.Close();
            if (Success.Value.ToString() == "1")
            {
                Session["user"] = id;
                if (type.Value.ToString() == "1")
                    Response.Redirect("StudentHome.aspx");
                else if (type.Value.ToString() == "3")
                    Response.Redirect("AdminHome.aspx");
            }
            else if (Success.Value.ToString() == "0")
                Response.Write("Invalid ID or Password");
        }

        protected void register_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}