<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImageFromDataBase_Form.aspx.cs" Inherits="MyWebSite.GridViews.ImageFromDataBase_Form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <!-- 1. we will check the techniques that read from the Sql Database 
            First we will define a SqlSource which can include the 
            -->
        
        <asp:SqlDataSource runat="server" ID="sourcePublishers" ConnectionString="<%$ ConnectionStrings:Pubs %>" SelectCommand="SELECT * FROM publishers"></asp:SqlDataSource>
        
        <asp:GridView runat="server" ID="gridLogos" DataSourceID="sourcePublishers" AllowPaging="True" PageSize="10">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                       <table border="1">
                            <tr><td><img src='ImageFromDB.ashx?ID=<%# Eval("pub_id") %>'/></td></tr>
                        </table>
                        <b><%# Eval("pub_name") %></b>
                        <%# Eval("city") %>
                        <%# Eval("state") %>
                        <%# Eval("country") %>
                        <br /><br />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns> 
        </asp:GridView>
       
    </div>
    </form>
</body>
</html>