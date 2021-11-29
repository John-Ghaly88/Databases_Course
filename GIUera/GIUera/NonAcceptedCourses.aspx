<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NonAcceptedCourses.aspx.cs" Inherits="GIUera.NonAcceptedCourses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: xx-large;
        }
        .auto-style2 {
            font-size: x-large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            Non Accepted Courses&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Home" runat="server" Text="Home" OnClick="Home_Click" />
            <br />
            <br />
            <span class="auto-style2">Course ID:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Your ID:<br />
            <asp:TextBox ID="CID" runat="server"></asp:TextBox>
            <asp:TextBox ID="AID" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Accept" runat="server" Text="Accept" Height="42px" OnClick="Accept_Click" Width="103px" />
            </span>
        </div>
    </form>
</body>
</html>
