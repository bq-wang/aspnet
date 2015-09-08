<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Serializer_Formatter_Form.aspx.cs" Inherits="MyWebSite.FileSystems.Serializer_Formatter_Form" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <!-- 1. the page will show a technique
         1.2. to get a unique file name
         1.2.  use the unique file name to write your own log -->
      <asp:Button runat="server" ID="cmdPostBack" Text="Post Back" />
      <asp:Button runat="server" ID="cmdRead" OnClick="cmdRead_Click" Text="Read Log" />
      <asp:Button runat="server" ID="cmdDelete" OnClick="cmdDelete_Click" Text="Delete Log" />
      <asp:Label runat="server" ID="lblInfo"></asp:Label>
    </div>
    </form>
</body>
</html>
