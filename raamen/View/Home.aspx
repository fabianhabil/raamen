<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="raamen.View.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="~/lib/bootstrap/css/bootstrap.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            test bootstrap
            <asp:Button ID="Button1" runat="server" Text="test button" CssClass="btn btn-primary" ValidateRequestMode="Disabled" />
        </div>
    </form>
</body>
</html>
