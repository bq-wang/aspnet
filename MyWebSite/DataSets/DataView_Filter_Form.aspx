<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataView_Filter_Form.aspx.cs" Inherits="MyWebSite.DataSets.DataView_Filter_Form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <asp:Label runat="server" ID="filter1" />
        <asp:DataGrid runat="server" ID="grid1" />
        <br /><br />
        
        <asp:Label runat="server" ID="filter2" />
        <asp:DataGrid runat="server" ID="grid2" />
        <br /><br />

        <asp:Label runat="server" ID="filter3" />
        <asp:DataGrid runat="server" ID="grid3" />
        <br /><br />

    </div>
    </form>
</body>
</html>
