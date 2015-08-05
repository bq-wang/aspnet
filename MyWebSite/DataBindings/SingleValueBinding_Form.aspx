<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SingleValueBinding_Form.aspx.cs" Inherits="MyWebSite.DataBindings.SingleValueBinding_Form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Image ID="image1" runat="server" ImageUrl='<%# FilePath %>' />
        <br />
        
        <asp:Label ID="label1" runat="server" Text='<%# FilePath %>' />
        <br />

        <asp:TextBox ID="textBox1" runat="server" Text='<%# GetFilePath() %>' />
        <br />

        <asp:HyperLink ID="hyperLink1" runat="server" NavigateUrl='<%# LogoPath.Value %>' Font-Bold="True" Text="Show Logo" />

        <input type="hidden" id="LogoPath" runat="server" value="apress.gif" />

        <br />
        <b><%# FilePath %></b><br />

        <img src="<%# GetFilePath() %>" /> <!-- binding valuation can  also applies if in web control -->
        <br />
    </div>
    </form>
</body>
</html>