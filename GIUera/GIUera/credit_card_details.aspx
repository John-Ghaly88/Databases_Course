<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="credit_card_details.aspx.cs" Inherits="GIUera.credit_card_details" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="credit" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Enter your credit card number"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Enter your credit card holder name "></asp:Label>
            <br />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Enter the expiry date of your credit card"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Enter the cvv"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="done" runat="server" Text="Press here after you finish" OnClick="done_Click" />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
