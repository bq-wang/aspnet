<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cache_Replacing_Form.aspx.cs" Inherits="MyWebSite.Cache.Cache_Replacing_Form" %>
<%@ OutputCache Duration="20" VaryByParam="None" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <!-- 
        1. Caching and replacing 

        well, the partical caching technique is not talked here which involves creating a user control and set the user control to output cache-ability

        still, we need to declarative to set the OutputCache for the page.
      -->

    </div>
    </form>
</body>
</html>
