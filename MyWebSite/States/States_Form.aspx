<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="States_Form.aspx.cs" Inherits="MyWebSite.States.States_Form" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

    <table id="Table1" runat="server">

    <tr><td><asp:Label ID="Label1" runat="server" Text="Description" /></td><td><asp:Label ID="Label2" runat="server" Text="Value" /></td></tr>

    <tr><td><asp:Label ID="Label3" runat="server" Text="Name" /></td><td><asp:TextBox ID="txtName" runat="server" /></td></tr>

    <tr><td><asp:Label ID="Label4" runat="server" Text="IF" /></td><td><asp:TextBox ID="txtID" runat="server" /></td></tr>

    <tr><td><asp:Label ID="Label5" runat="server" Text="Age" /></td><td><asp:TextBox ID="txtAge" runat="server" /></td></tr>

    <tr><td><asp:Label ID="Label6" runat="server" Text="E-Mail" /></td><td><asp:TextBox ID="txtEmail" runat="server" /></td></tr>

    <tr><td><asp:Label ID="Label7" runat="server" Text="Password" /></td><td><asp:TextBox ID="txtPassword" runat="server" /></td></tr>
 
    <tr><td><asp:Button ID="btnSave" runat="server" OnClick="btnSaveClick" Text="save"/></td><td><asp:Button ID="btnRestore" runat="server" OnClick="btnRestoreClick" Text="Restore" /></td></tr>
    </table>
    </div>
    </form>
</body>
</html>
