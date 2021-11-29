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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void add_Click(object sender, EventArgs e)
        {
            string ConnStr = WebConfigurationManager.ConnectionStrings["GIUera"].ToString();
            SqlConnection Conn = new SqlConnection(ConnStr);

            String firstName = firstname.Text;
            String lastName = lastname.Text;
            String pass = password.Text;
            String Email = email.Text;
            String Address = address.Text;
            String Gender = gender.Text;
            String Type = type.Text;

            if (Type == "Student")
            {
                SqlCommand stdregister = new SqlCommand("studentRegister", Conn);
                stdregister.CommandType = CommandType.StoredProcedure;

                stdregister.Parameters.Add(new SqlParameter("@first_name", firstName));
                stdregister.Parameters.Add(new SqlParameter("@last_name", lastName));
                stdregister.Parameters.Add(new SqlParameter("@password", pass));
                stdregister.Parameters.Add(new SqlParameter("@email", Email));
                if (Gender == "female")
                    stdregister.Parameters.Add(new SqlParameter("@gender", true));
                else if (Gender == "male")
                    stdregister.Parameters.Add(new SqlParameter("@gender", false));
                stdregister.Parameters.Add(new SqlParameter("@address", Address));

                SqlParameter id = stdregister.Parameters.Add("@ID", SqlDbType.Int);
                id.Direction = ParameterDirection.Output;

                Conn.Open();
                stdregister.ExecuteNonQuery();
                Conn.Close();
                Session["registered"] = id.Value.ToString();
            }
            else if (Type == "Instructor")
            {
                SqlCommand instregister = new SqlCommand("InstructorRegister", Conn);
                instregister.CommandType = CommandType.StoredProcedure;

                instregister.Parameters.Add(new SqlParameter("@first_name", firstName));
                instregister.Parameters.Add(new SqlParameter("@last_name", lastName));
                instregister.Parameters.Add(new SqlParameter("@password", pass));    
                instregister.Parameters.Add(new SqlParameter("@email", Email));
                if (Gender == "female")
                    instregister.Parameters.Add(new SqlParameter("@gender", true));
                else if (Gender == "male")
                    instregister.Parameters.Add(new SqlParameter("@gender", false));
                instregister.Parameters.Add(new SqlParameter("@address", Address));

                SqlParameter id = instregister.Parameters.Add("@ID", SqlDbType.Int);
                id.Direction = ParameterDirection.Output;

                Conn.Open();
                instregister.ExecuteNonQuery();
                Conn.Close();
                Session["registered"] = id.Value.ToString();
            }
            Response.Redirect("phoneNumbers.aspx");
        }
    }
}