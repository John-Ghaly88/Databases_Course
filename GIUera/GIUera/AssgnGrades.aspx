<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssgnGrades.aspx.cs" Inherits="GIUera.AssgnGrades" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="asgrade" runat="server">
        <div>
            Please enter assignment type:<br />
            <asp:TextBox ID="type" runat="server"></asp:TextBox>
            <br />
            Please enter assignment number:<br />
            <asp:TextBox ID="number" runat="server"></asp:TextBox>
            <br />
            Please enter course id:<br />
            <asp:TextBox ID="courseid" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="grade" runat="server" Text="Show Grade" OnClick="grade_Click" />
            <br />
            <asp:Button ID="home" runat="server" Text="Back to HomePage" OnClick="home_Click" />
            <br />
        </div>
    </form>
</body>
</html>
