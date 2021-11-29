<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="phoneNumbers.aspx.cs" Inherits="GIUera.phoneNumbers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        PhoneNumber<br />
        <asp:TextBox ID="phonenumber" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Add" runat="server" Text="Add another phone number" OnClick="Add_Click" />
        <br />
        <asp:Button ID="done" runat="server" Text="Done" OnClick="done_Click" />
    </form>
</body>
</html>
