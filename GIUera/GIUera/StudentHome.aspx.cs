using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GIUera
{
    public partial class StudentHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void vmp_Click(object sender, EventArgs e)
        {
            Response.Redirect("profileview.aspx");
        }

        protected void emp_Click(object sender, EventArgs e)
        {
            Response.Redirect("profileedit.aspx");
        }

        protected void courses_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewcourses_Student.aspx");
        }

        protected void enroll_Click(object sender, EventArgs e)
        {
            Response.Redirect("enrol.aspx");
        }

        protected void credit_card_Click(object sender, EventArgs e)
        {
            Response.Redirect("credit_card_details.aspx");
        }

        protected void promo_codes_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewpromocode.aspx");
        }

        protected void course_content_Click(object sender, EventArgs e)
        {
            Response.Redirect("view_course_content.aspx");
        }

        protected void AssignCont_Click(object sender, EventArgs e)
        {
            Response.Redirect("assign_content.aspx");
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            Response.Redirect("SubmitAssign.aspx");
        }

        protected void Assigngrade_Click(object sender, EventArgs e)
        {
            Response.Redirect("AssgnGrades.aspx");
        }

        protected void finalGrade_Click(object sender, EventArgs e)
        {
            Response.Redirect("FinalGrade.aspx");
        }

        protected void feedback_Click(object sender, EventArgs e)
        {
            Response.Redirect("addFeedback.aspx");
        }

        protected void cert_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewcert.aspx");
        }

        protected void rate_Click(object sender, EventArgs e)
        {
            Response.Redirect("rateInst.aspx");
        }

        protected void sign_out_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}