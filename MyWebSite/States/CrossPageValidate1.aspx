<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrossPageValidate1.aspx.cs" Inherits="MyWebSite.States.CrossPageValidate1" %>

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
      <asp:Label runat="server" ID="lblInfo" />
      <asp:RequiredFieldValidator ID="txtLastNameValidator" runat="server" ControlToValidate="txtFirstName" ErrorMessage="Last name is required" Enabled="true">*</asp:RequiredFieldValidator>
      <asp:RequiredFieldValidator ID="txtFirstNameValidator" runat="server" ControlToValidate="txtLastName" ErrorMessage="First Name is requied" Enabled="true">*</asp:RequiredFieldValidator>

      <asp:Button runat="server" ID="cmdSubmit" Text="submit" PostBackUrl="~/States/CrossPageValidate2.aspx"/>

      <asp:Button runat="server" ID="cmdTransfer" Text="transfer" OnClick="cmdTransferClick"/>

    </div>
    </form>
</body>
</html>
