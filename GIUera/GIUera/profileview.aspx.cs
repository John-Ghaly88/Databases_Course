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
    public partial class profileview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ConnStr = WebConfigurationManager.ConnectionStrings["GIUera"].ToString();
            SqlConnection Conn = new SqlConnection(ConnStr);

            SqlCommand p = new SqlCommand("viewMyProfile", Conn);
            p.CommandType = CommandType.StoredProcedure;

            int id = ((int)Session["user"]);
            p.Parameters.Add(new SqlParameter("@id", id));

            Conn.Open();
            SqlDataReader rdr = p.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                view.Controls.Add(new LiteralControl("<br>"));
                view.Controls.Add(new LiteralControl("ID: "));
                int sid = ((int)Session["user"]);
                Label lid = new Label();
                lid.Text = sid.ToString();
                view.Controls.Add(lid);
                view.Controls.Add(new LiteralControl("<br>"));

                view.Controls.Add(new LiteralControl("GPA: "));
                string sgpa = rdr["gpa"].ToString();
                Label lgpa = new Label();
                lgpa.Text = sgpa;
                view.Controls.Add(lgpa);
                view.Controls.Add(new LiteralControl("<br>"));

                view.Controls.Add(new LiteralControl("First name: "));
                string sfn = rdr["firstName"].ToString();
                Label lfn = new Label();
                lfn.Text = sfn;
                view.Controls.Add(lfn);
                view.Controls.Add(new LiteralControl("<br>"));

                view.Controls.Add(new LiteralControl("Last name: "));
                string sln = rdr["lastName"].ToString();
                Label lln = new Label();
                lln.Text = sln;
                view.Controls.Add(lln);
                view.Controls.Add(new LiteralControl("<br>"));

                string g = rdr["gender"].ToString();
                if (g == "False")
                {
                    view.Controls.Add(new LiteralControl("Gender: "));
                    Label lg = new Label();
                    lg.Text = "male";
                    view.Controls.Add(lg);
                }
                else if (g == "True")
                {
                    view.Controls.Add(new LiteralControl("Gender: "));
                    Label lg = new Label();
                    lg.Text = "female";
                    view.Controls.Add(lg);
                }
                view.Controls.Add(new LiteralControl("<br>"));

                view.Controls.Add(new LiteralControl("E-mail: "));
                string smail = rdr["email"].ToString();
                Label lmail = new Label();
                lmail.Text = smail;
                view.Controls.Add(lmail);
                view.Controls.Add(new LiteralControl("<br>"));

                view.Controls.Add(new LiteralControl("Address: "));
                string sa = rdr["address"].ToString();
                Label la = new Label();
                la.Text = sa;
                view.Controls.Add(la);
                view.Controls.Add(new LiteralControl("<br>"));
                view.Controls.Add(new LiteralControl("---------------------------------------------------------"));
                view.Controls.Add(new LiteralControl("<br>"));
            }
        }

        protected void back1_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx");
        }
    }
}