<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubmitAssign.aspx.cs" Inherits="GIUera.SubmitAssign" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Please Enter assignment type:<br />
            <asp:TextBox ID="type" runat="server"></asp:TextBox>
        </div>
        Please Enter assignment number:<br />
        <asp:TextBox ID="number" runat="server"></asp:TextBox>
        <br />
        Please Enter Course id:<br />
        <asp:TextBox ID="courseid" runat="server"></asp:TextBox>
        <br />
            <asp:Button ID="enter" runat="server" Text="Done" OnClick="enter_Click" />
        <br />
        <asp:Button ID="home" runat="server" Text="Back to HomePage" OnClick="home_Click" />
        </div>
    </form>
</body>
</html>
