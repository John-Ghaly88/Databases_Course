<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="GIUera.AdminHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: x-large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <asp:Label ID="Label5" runat="server" style="text-align:center" Font-Bold="true" Font-Size="Large"  Text="Admin Home Page"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="sign_out" runat="server" Text="Sign out" OnClick="sign_out_Click" />
        </div>
        <asp:Button ID="Instructor" runat="server" Text="View Instructors" OnClick="Instructor_Click" Width="154px" />
        <p>
        <asp:Button ID="students" runat="server" Text="View Students" OnClick="students_Click" Width="154px" />
        </p>
        <p>
        <asp:Button ID="courses" runat="server" Text="View Courses" OnClick="courses_Click" Width="154px" />
        </p>
        <p>
            <asp:Button ID="CreatePromoCode" runat="server" Text="Create Promo code" OnClick="CreatePromoCode_Click" Width="154px" />
        </p>
    </form>
</body>
</html>
