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
    public partial class profileedit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void done_Click(object sender, EventArgs e)
        {
            string ConnStr = WebConfigurationManager.ConnectionStrings["GIUera"].ToString();
            SqlConnection Conn = new SqlConnection(ConnStr);

            int id = ((int)Session["user"]);
            String pass = TextBox1.Text;
            String firstName = TextBox2.Text;
            String lastName = TextBox3.Text;
            String Email = TextBox5.Text;
            String Address = TextBox6.Text;
            String Gender = TextBox4.Text;

            SqlCommand edit = new SqlCommand("editMyProfile", Conn);
            edit.CommandType = CommandType.StoredProcedure;

            edit.Parameters.Add(new SqlParameter("@id", id));
            edit.Parameters.Add(new SqlParameter("@password", pass));
            edit.Parameters.Add(new SqlParameter("@firstName", firstName));
            edit.Parameters.Add(new SqlParameter("@lastName", lastName));
            edit.Parameters.Add(new SqlParameter("@email", Email));
            edit.Parameters.Add(new SqlParameter("@address", Address));
            if (Gender == "female")
                edit.Parameters.Add(new SqlParameter("@gender", true));
            else if (Gender == "male")
                edit.Parameters.Add(new SqlParameter("@gender", false));

            Conn.Open();
            edit.ExecuteNonQuery();
            Conn.Close();
            Response.Redirect("StudentHome.aspx");
        }
    }
}