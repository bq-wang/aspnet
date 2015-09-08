<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataReader_SqlInjection.aspx.cs" Inherits="MyWebSite.DataAccesses.DataReader_SqlInjection" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox runat="server" ID="txtID" ></asp:TextBox>
        <asp:Button runat="server" ID="cmdGetRecords" OnClick="cmdGetRecordsClick" Text="Get Records"/>
        <asp:GridView runat="server" ID="GridView1" />
    </div>
    </form>
</body>
</html>
