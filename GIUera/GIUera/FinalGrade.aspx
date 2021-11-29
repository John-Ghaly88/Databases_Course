<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FinalGrade.aspx.cs" Inherits="GIUera.FinalGrade" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Please enter course id:<br />
            <asp:TextBox ID="courseid" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="fg" runat="server" Text="Final Grade" OnClick="fg_Click" />
            <br />
            <asp:Button ID="home" runat="server" Text="Back To HomePage" OnClick="home_Click" />
        </div>
    </form>
</body>
</html>
