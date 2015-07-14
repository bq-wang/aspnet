<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ValidationGroup.aspx.cs" Inherits="MyWebSite.ServerControls.ValidationGroup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

    <!-- this page will introduce validation group - group form controls with its respective validator -->
    <form id="form1" runat="server">
    <div>
      <asp:Panel ID="Panel1" runat="server">
        <asp:TextBox ID="TextBox1" ValidationGroup="Group1" runat="server" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
          ErrorMessage="Required" ValidationGroup="Group1"
          runat="server" ControlToValidate="TextBox1" />
        <asp:Button ID="Button1" Text="Validate Group1" ValidationGroup="Group1" runat="server" />
      
      </asp:Panel>


      <br />

      <asp:Panel ID="Panel2" runat="server">
        <asp:TextBox ID="TextBox2" ValidationGroup="Group1" runat="server" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
          ErrorMessage="Required" ValidationGroup="Group2"
          runat="server" ControlToValidate="TextBox2" />
        <asp:Button ID="Button2" Text="Validate Group2" ValidationGroup="Group2" runat="server" />
      
      </asp:Panel>
    </div>
    </form>
</body>
</html>
