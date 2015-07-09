<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Controls.aspx.cs" Inherits="MyWebSite.WebForms.Controls" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Control</title>
</head>
<body>
    <p><i>This is a static HTML (not a web control).</i></p>
    <form id="frm" method="post" runat="server">

    <div>

    <asp:Panel ID="MainPanel" runat="server" Height="112px">
        <p>
          <asp:Button ID="Button1" runat="server" Text="Button1" />
          <asp:Button ID="Button2" runat="server" Text="Button2" />
          <asp:Button ID="Button3" runat="server" Text="Button3" />
        </p>

        <p>
          <asp:Label ID="Label1" runat="server" Width="48px">Name:</asp:Label>
          <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

        </p>
      </asp:Panel>

      <p> <asp:Button ID="Button4" runat="server" Text="Button4" /></p>
    </div>
      
    </form>

    <p><i>This is static html (not a web control).</i></p>
</body>
</html>
