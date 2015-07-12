<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectableControls.aspx.cs" Inherits="MyWebSite.ServerControls.SelectableControls" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:ListBox runat="server" ID="Listbox1" SelectionMode="Multiple" Rows="5">
        <asp:ListItem Selected="True">Option 1</asp:ListItem>
        <asp:ListItem>Option 2</asp:ListItem>
      </asp:ListBox>

      <br />
      <br />

      <asp:DropDownList runat="server" ID="DropdownList1">
        <asp:ListItem Selected="True">Option 1</asp:ListItem>
        <asp:ListItem>Option 2</asp:ListItem>
      </asp:DropDownList>

      <asp:CheckBoxList runat="server" ID="CheckboxList1" RepeatColumns="3">
        <asp:ListItem Selected="True">Option 1</asp:ListItem>
        <asp:ListItem>Option 2</asp:ListItem>
      </asp:CheckBoxList>

      <asp:RadioButtonList runat="server" ID="RadioButtonList1" RepeatColumns="2" RepeatDirection="Horizontal">
        <asp:ListItem Selected="True">Option 1</asp:ListItem>
        <asp:ListItem>Option 2</asp:ListItem>
      </asp:RadioButtonList>

      <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />

    </div>
    </form>
</body>
</html>
