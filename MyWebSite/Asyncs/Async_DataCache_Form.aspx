<!-- Fist step to make a page a async page, is that you will need to add the Async flag 

  Async = "true"

-->
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Async_DataCache_Form.aspx.cs" Inherits="MyWebSite.Asyncs.Async_DataCache_Form"  Async="true"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <!-- in this page, we will review the how to do the Async page loading -- like putting some of the data queries back to async operations
        -->

       <asp:GridView ID="grid" runat="server" />
      <asp:Label ID="lblError" runat="server" />

    </div>
    </form>
</body>
</html>
