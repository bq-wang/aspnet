﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DynamicControls.aspx.cs" Inherits="MyWebSite.WebForms.DynamicControls" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <p>
      <asp:Label ID="Label1" runat="server" />
      <asp:Panel ID="Panel1" runat="server" />

      <asp:Button ID="cmdRemove" runat="server" OnClick="cmdRemove_Click" Text="Remove">
      </asp:Button>
      </p>
    </div>
    </form>
</body>
</html>
