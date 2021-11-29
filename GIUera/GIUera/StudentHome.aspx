<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentHome.aspx.cs" Inherits="GIUera.StudentHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="S_home" runat="server">
        <asp:Label ID="Label5" runat="server" style="text-align:center" Font-Bold="true" Font-Size="Large"  Text="Student Home Page"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="sign_out" runat="server" Text="Sign out" OnClick="sign_out_Click" />
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Font-Bold="true" Font-Size="Medium" Text="Students' section"></asp:Label>
        <br />
        <asp:Button ID="vmp" runat="server" Text="View my profile" OnClick="vmp_Click" />
        <br />
        <br />
        <asp:Button ID="emp" runat="server" Text="Edit my profile" OnClick="emp_Click" />
        <br />
        <br />
        <asp:Button ID="courses" runat="server" OnClick="courses_Click" Text="View all available courses" />
        <br />
        <br />
        <asp:Button ID="enroll" runat="server" Text="Enroll in a course" OnClick="enroll_Click" />
        <br />
        <br />
        <asp:Button ID="credit_card" runat="server" Text="Add my credit card details" OnClick="credit_card_Click" />
        <br />
        <br />
        <asp:Button ID="promo_codes" runat="server" Text="View promo codes" OnClick="promo_codes_Click" />
        <br />
        <br />
        <asp:Button ID="course_content" runat="server" Text="View content of a course I enrolled in" OnClick="course_content_Click" />
        <br />
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Font-Bold="true" Font-Size="Medium" Text="Assignments' section"></asp:Label>
        <br />
        <asp:Button ID="AssignCont" runat="server" Text="Assignments Contents" OnClick="AssignCont_Click" />
        <br />
        <br />
        <asp:Button ID="Submit" runat="server" Text="Submit Assignment" OnClick="Submit_Click" />
        <br />
        <br />
        <asp:Button ID="Assigngrade" runat="server" Text="Assignment Grade" OnClick="Assigngrade_Click" />
        <br />
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Font-Bold="true" Font-Size="Medium" Text="Courses' section"></asp:Label>
        <br />
        <asp:Button ID="finalGrade" runat="server" Text="Show Final Grade" OnClick="finalGrade_Click" />
        <br />
        <br />
        <asp:Button ID="feedback" runat="server" Text="Add feedback to the course" OnClick="feedback_Click" />
        <br />
        <br />
        <asp:Button ID="cert" runat="server" Text="View Certificate" OnClick="cert_Click" />
        <br />
        <br />
        <asp:Button ID="rate" runat="server" Text="Rate Instructor" OnClick="rate_Click" />
        <br />

    </form>
</html>
