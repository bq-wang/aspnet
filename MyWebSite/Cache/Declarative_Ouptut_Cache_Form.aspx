<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Declarative_Ouptut_Cache_Form.aspx.cs" Inherits="MyWebSite.Cache.Declarative_Ouptut_Cache_Form" %>
<%@ OutputCache Duration="20" VaryByParam="None" %>
<!-- TODO:
  remove the OutputCache directive to use explicit code cacheability -->
<!-- < % @ OutputCache Duration="20" VaryByParam="None" %> -- >
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <!-- in this web form, we will examine the output cache declarative by time -->
      <asp:Label ID="lblDate" runat="server" />
    </div>
    </form>
</body>
</html>
