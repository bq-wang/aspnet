<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImageGuardHandler_Form.aspx.cs" Inherits="MyWebSite.Applications.ImageGuardHandler_Form" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:TextBox ID="txtImage" runat="server" Text="Images/Programs.gif" />
      <asp:Button ID="btnRedirectToImage" runat="server" OnClick="btnRedirectToImageClick" Text="Redirect to Image"/>
    </div>
    </form>
</body>
</html>
