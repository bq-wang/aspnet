<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExpressionBinding_Form.aspx.cs" Inherits="MyWebSite.DataBindings.ExpressionBinding_Form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <!-- built-in AppSettings Expression -->
        <%--<asp:Literal runat="server" Text="<%$ AppSettings:appName %>"></asp:Literal>--%>

            <br />

        <asp:Literal ID="Literal1" runat="server" Text="<%$ ConnectionStrings:NorthWind %>"></asp:Literal>
        
        
        <br />
        <asp:Literal ID="Literal2" runat="server" Text="<%$ RandomNumber:1,6 %>"></asp:Literal>
    </div>
    </form>
</body>
</html>