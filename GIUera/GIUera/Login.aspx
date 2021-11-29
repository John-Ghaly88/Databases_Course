<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GIUera.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" style="text-align:center" ForeColor="#000099" Font-Bold="true" Font-Size="X-Large"  Text="GIUera"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" style="text-align:center" Font-Bold="true" Font-Size="Large"  Text="Welcome! Pleae Login"></asp:Label>
            <br />
            ID</div>
        <asp:TextBox ID="ID" runat="server"></asp:TextBox>
        <br />
        Password<br />
        <asp:TextBox ID="password" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="signin" runat="server" OnClick="login" Text="Login" />
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" style="text-align:center" Font-Bold="true" Font-Size="Large"  Text="Dont have an account? Register"></asp:Label>
        <br />
        <asp:Button ID="register" runat="server" Text="Register" OnClick="register_Click" />
        <br />
    </form>
</body>
</html>
