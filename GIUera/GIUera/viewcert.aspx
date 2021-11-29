<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewcert.aspx.cs" Inherits="GIUera.viewcert" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Congratulation! You can now check your certificate<br />
            <br />
            Please enter your course id:<br />
            <asp:TextBox ID="courseid" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="cert" runat="server" Text="Show certificate" OnClick="cert_Click" />
            <br />
            <asp:Button ID="home" runat="server" Text="Back To HomePage" OnClick="home_Click" />
        </div>
    </form>
</body>
</html>
