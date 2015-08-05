<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Transaction_ClientTrans_Form.aspx.cs" Inherits="MyWebSite.DataAccesses.Transaction_ClientTrans_Form" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

      <asp:Button ID="cmdTransaction" runat="server" OnClick="cmdTransactionClick" Text="Transaction (Insert)"/>
      &nbsp; &nbsp; &nbsp;

      <asp:Button ID="cmdTransactionRemove" runat="server" OnClick="cmdTransactionRemoveClick" Text="Transaction (Remove)" />
      <asp:Label ID="HtmlContent" runat="server" />
    </div>
    </form>
</body>
</html>
