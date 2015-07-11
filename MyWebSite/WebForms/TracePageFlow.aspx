<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TracePageFlow.aspx.cs" Inherits="MyWebSite.WebForms.TracePageFlow" Trace="true" %>
<!-- the key attribute here is the Trace = "True" flag -->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:Label id="lbInfo" runat="server" EnableViewState="false">
      </asp:Label>

      <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click">
      </asp:Button>
    </div>
    </form>
</body>
</html>
