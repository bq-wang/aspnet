﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrossPage1.aspx.cs" Inherits="MyWebSite.States.CrossPage1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:TextBox runat="server" ID="txtFirstName"></asp:TextBox> &nbsp;
      <asp:TextBox runat="server" ID="txtLastName"></asp:TextBox> &nbsp;
      <asp:Button runat="server" ID="cmdSubmit" Text="submit" PostBackUrl="~/States/CrossPage2.aspx"/>
      <asp:Button runat="server" ID="cmdTransfer" Text="transfer" OnClick="cmdTransferClick"/>

      <asp:Label runat="server" ID="lblInfo" />
    </div>
    </form>
</body>
</html>
