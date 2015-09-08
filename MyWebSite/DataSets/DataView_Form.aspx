<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataView_Form.aspx.cs" Inherits="MyWebSite.DataAccesses.DataView_Form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button runat="server" ID="cmdGridViewBinding" OnClick="cmdGridViewBindingClick" Text="Grid View"/>

        <asp:DataGrid runat="server" ID="grid1" />
        <br /><br />
        
        <asp:DataGrid runat="server" ID="grid2" />
        <br /><br />

        <asp:DataGrid runat="server" ID="grid3" />
        <br /><br />

    </div>
    </form>
</body>
</html>
