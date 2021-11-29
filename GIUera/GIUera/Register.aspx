<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="GIUera.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        FirstName</div>
        <br />
        <asp:TextBox ID="firstname" runat="server"></asp:TextBox>
        <br />
        LastName<br />
        <asp:TextBox ID="lastname" runat="server"></asp:TextBox>
        <br />
        Password<br />
        <asp:TextBox ID="password" runat="server"></asp:TextBox>
        <br />
        E-mail<br />
        <asp:TextBox ID="email" runat="server"></asp:TextBox>
        <br />
        Gender, please enter "female" or "male"<br />
        <asp:TextBox ID="gender" runat="server"></asp:TextBox>
        <br />
        Address<br />
        <asp:TextBox ID="address" runat="server"></asp:TextBox>
        <br />
        Student or Instructor?<br />
        <asp:TextBox ID="type" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="add" runat="server" Text="add telephone numbers" OnClick="add_Click" />
    </form>
</body>
</html>
