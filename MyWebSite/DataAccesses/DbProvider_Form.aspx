<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DbProvider_Form.aspx.cs" Inherits="MyWebSite.DataAccesses.DbProvider_Form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button runat="server" ID="cmdDbFactory" OnClick="cmdDbFactoryClick" Text="cmd Db Factory"/>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label runat="server" ID="HtmlContent" />
    </div>
    </form>
</body>
</html>
