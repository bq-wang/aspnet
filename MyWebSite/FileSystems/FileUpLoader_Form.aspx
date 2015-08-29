<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileUpLoader_Form.aspx.cs" Inherits="MyWebSite.FileSystems.FileUpLoader_Form" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <!-- 1. in this file, we will discuss the file uploader and others -->
      <asp:FileUpload runat="server" ID="UpLoader" />
      <asp:Button runat="server" ID="cmdUpload" OnClick="cmdUpload_OnClick" Text="Upload" />
      <br /><br />
      <asp:Label runat="server" ID="lblStatus"></asp:Label>
    </div>
    </form>
</body>
</html>
