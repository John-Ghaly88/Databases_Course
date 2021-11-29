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
    public partial class AssgnGrades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void grade_Click(object sender, EventArgs e)
        {
            string ConnStr = WebConfigurationManager.ConnectionStrings["GIUera"].ToString();
            SqlConnection Conn = new SqlConnection(ConnStr);

            String atype = type.Text;
            String num = number.Text;
            String cid = courseid.Text;
            int sid = ((int)Session["user"]);

            SqlCommand assignmentgrade = new SqlCommand("viewAssignGrades", Conn);
            assignmentgrade.CommandType = CommandType.StoredProcedure;

            assignmentgrade.Parameters.Add(new SqlParameter("@assignnumber", num));
            assignmentgrade.Parameters.Add(new SqlParameter("@assignType", atype));
            assignmentgrade.Parameters.Add(new SqlParameter("@cid", cid));
            assignmentgrade.Parameters.Add(new SqlParameter("@sid", sid));

            Conn.Open();
            SqlDataReader rdr = assignmentgrade.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                string gr = rdr["grade"].ToString();
                Label agrade = new Label();
                agrade.Text = gr;
                asgrade.Controls.Add(agrade);
            }
            //Response.Redirect("AssgnGrades");
        }

        protected void home_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx");
        }
    }
}