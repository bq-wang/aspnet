<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebControlEvents.aspx.cs" Inherits="MyWebSite.ServerControls.WebControlEvents" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <h3>List of events</h3>
      <asp:ListBox ID="lstEvents" runat="server" Height="107px" Width="354px"></asp:ListBox>

      <br />
      <br />


      <h3>Controls being monitored for change events</h3>

      <asp:TextBox ID="txt" runat="server" AutoPostBack="true" OnTextChanged="CtrlChanged" />
      <br />
      <br />

      <asp:CheckBox ID="chk" runat="server" AutoPostBack="true" OnCheckedChanged="CtrlChanged" />

      <asp:RadioButton ID="opt1" runat="server" AutoPostBack="true" OnCheckedChanged="CtrlChanged" GroupName="Sample" />
      <asp:RadioButton ID="opt2" runat="server" AutoPostBack="true" OnCheckedChanged="CtrlChanged" GroupName="Sample" />

    </div>
    </form>
</body>
</html>
