<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MultipleTablesAndRelations_Form.aspx.cs" Inherits="MyWebSite.DataSets.MultipleTablesAndRelations_Form" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:Button runat="server" ID="cmdMultipleTablesRelations" OnClick="cmdMultipleTablesRelationsClick" Text="Multiple Tables and Relation" />
      <br /><br />
      <asp:Label ID="HtmlContent" runat="server" />
    </div>
    </form>
</body>
</html>
