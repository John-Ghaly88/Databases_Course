<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="view_course_content.aspx.cs" Inherits="GIUera.view_course_content" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="course_content" runat="server">
        <asp:Button ID="back7" runat="server" Text="Back to home page" OnClick="back7_Click" />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Enter the course id"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="done" runat="server" Text="Show content" OnClick="done_Click" />
    </form>
</body>
</html>
