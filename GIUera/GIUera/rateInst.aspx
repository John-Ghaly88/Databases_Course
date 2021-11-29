<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rateInst.aspx.cs" Inherits="GIUera.rateInst" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Please show your rating below:<br />
            <asp:TextBox ID="rating" runat="server"></asp:TextBox>
            <br />
            Instructor id:<br />
            <asp:TextBox ID="instid" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="rate" runat="server" Text="Done" OnClick="rate_Click" />
            <br />
            <asp:Button ID="home" runat="server" Text="Back To HomePage" OnClick="home_Click" />
        </div>
    </form>
</body>
</html>
