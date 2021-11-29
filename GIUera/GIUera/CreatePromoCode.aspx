<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreatePromoCode.aspx.cs" Inherits="GIUera.CreatePromoCode" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: x-large;
        }
        .auto-style2 {
            font-size: x-large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            Create Promo code&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Home" runat="server" Text="Home" OnClick="Home_Click" />
            <br />
            <br />
            <span class="auto-style2">Code:</span><br />
            <asp:TextBox ID="Code" runat="server"></asp:TextBox>
            <br />
            <br />
            <span class="auto-style2">Issue Date:</span><br />
            <asp:TextBox ID="IssueDate" runat="server"></asp:TextBox>
            <br />
            <br />
            Expiry Date:<br />
            <asp:TextBox ID="ExpiryDate" runat="server"></asp:TextBox>
            <br />
            <br />
            Discount Amount:<br />
            <asp:TextBox ID="DiscountAmount" runat="server"></asp:TextBox>
            <br />
            <br />
            Your ID:<br />
            <asp:TextBox ID="ID" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Create" runat="server" Text="Create" Height="44px" OnClick="Create_Click" Width="124px" />
            <br />
            <br />
            <asp:Button ID="Issue" runat="server" Text="IssueCode" OnClick="Issue_Click" Width="124px" />
        </div>
    </form>
</body>
</html>
