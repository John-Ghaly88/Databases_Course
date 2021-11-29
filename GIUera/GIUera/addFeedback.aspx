<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addFeedback.aspx.cs" Inherits="GIUera.addFeedback" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Glad to see you here! Please Add your comment below:<br />
            <asp:TextBox ID="cmnt" runat="server"></asp:TextBox>
            <br />
            Your course id:<br />
            <asp:TextBox ID="courseid" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="feedback" runat="server" Text="Add feedback" OnClick="feedback_Click" />
            <br />
            <asp:Button ID="home" runat="server" Text="Back To HomePage" OnClick="home_Click" />
        </div>
    </form>
</body>
</html>
