<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImageButtonClick.aspx.cs" Inherits="MyWebSite.ServerControls.ImageButtonClick" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:Label ID="lblResult" runat="server" />
      <asp:ImageButton ID="ImageButton1" runat="server" OnClick="ImageButton1_Click" Height="140px" Width="315px" />
    </div>
    </form>
</body>
</html>
