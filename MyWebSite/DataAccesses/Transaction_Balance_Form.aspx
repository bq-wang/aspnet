<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Transaction_Balance_Form.aspx.cs" Inherits="MyWebSite.DataAccesses.Transaction_Balance_Form" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:Label ID="transfer" Text="Transfer from Account '001' to '002'" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;
      <asp:TextBox ID="money" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;
      <asp:Button ID="cmdTransfer" runat="server" Text="Transfer" OnClick="cmdTransferClick" />&nbsp;&nbsp;&nbsp;
      <br />
      <br />
      <asp:Label ID="HtmlContent" runat="server" />

    </div>
    </form>
</body>
</html>
