<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cache_RemovalCallback_Form.aspx.cs" Inherits="MyWebSite.Cache.Cache_RemovalCallback_Form" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <!-- 
        1. this shows that the cache system in asp.net provides you the callback when cached item is removed.
      -->
      <asp:Button ID="cmdCheckItems" runat="server" Text="Check Items" OnClick="cmdCheck_Click" />
      <asp:Button ID="cmdRemoveOneItems" runat="server" Text="Remove One Item" OnClick="cmdRemove_Click" />

      <asp:Label ID="lblInfo" runat="server" />
    </div>
    </form>
</body>
</html>
