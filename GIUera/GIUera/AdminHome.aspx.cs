using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GIUera
{
    public partial class AdminHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Instructor_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewInstructors.aspx");
        }
        protected void students_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewStudents.aspx");
        }
        protected void courses_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewCourses.aspx");
        }
        protected void CreatePromoCode_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreatePromoCode.aspx");
        }

        protected void sign_out_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}