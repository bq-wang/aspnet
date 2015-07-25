<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SimpleCookie.aspx.cs" Inherits="MyWebSite.States.SimpleCookie" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <!-- this page will create a simple cookie to by code to show how -->

      <asp:Button ID="cmdSetCookie" runat="server" OnClick="cmdSetCookieClick" Text="setCookie" />
      <asp:Button ID="cmdShowCookie" runat="server" OnClick="cmdShowCookieClick" Text="showCookie" />
      <asp:Button ID="cmdRemoveCookie" runat="server" OnClick="cmdRemoveCookieClick" Text="removeCookie" />
      <asp:Label ID="lblInfo" runat="server" />
    </div>
    </form>
</body>
</html>
