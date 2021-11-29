<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="assign_content.aspx.cs" Inherits="GIUera.assign_content" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Please enter Course id:<br />
            <asp:TextBox ID="courseid" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="viewassign" runat="server" Text="View Content" OnClick="viewcontent" />
            <br />
            <asp:Button ID="home" runat="server" Text="Back To HomePage" OnClick="home_Click" />
        </div>
    </form>
</body>
</html>
