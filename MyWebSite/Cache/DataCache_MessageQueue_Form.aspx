﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataCache_MessageQueue_Form.aspx.cs" Inherits="MyWebSite.Cache.DataCache_MessageQueue_Form" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:Button runat="server" ID="cmdCheckItems" OnClick="cmdCheckitems_OnClick" Text="Check Items" />
      <asp:Button runat="server" ID="cmdModify" OnClick="cmdModify_OnClick" Text="Sent Message" />
      <asp:Label runat="server" ID="lblInfo" />
    </div>
    </form>
</body>
</html>
