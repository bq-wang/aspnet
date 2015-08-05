<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StoreProcedure_Form.aspx.cs" Inherits="MyWebSite.DataAccesses.StoreProcedure_Form" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:Label runat="server" Text="Title" />
      <asp:TextBox runat="server" ID="title" />
      &nbsp;&nbsp;&nbsp;&nbsp;
      <br /><br />

      <asp:Label runat="server" Text="LastName" />
      <asp:TextBox runat="server" ID="lastName" />
      &nbsp;&nbsp;&nbsp;&nbsp;

      <br /><br />

      <asp:Label ID="Label1" runat="server" Text="firstName" />
      <asp:TextBox runat="server" ID="firstName" />
      &nbsp;&nbsp;&nbsp;&nbsp;
      <br /><br />


      <asp:Button ID="cmdInsertEmployee" runat="server" Text="Insert Employee" OnClick="cmdInsertEmployeeClick" />
      <br />
      <asp:Label ID="HtmlContent" runat="server" />
    </div>
    </form>
</body>
</html>
