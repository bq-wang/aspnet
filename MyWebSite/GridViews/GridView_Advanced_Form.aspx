<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GridView_Advanced_Form.aspx.cs" Inherits="MyWebSite.GridViews.GridView_Advanced_Form" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <!-- 
        in this form, we will review some of the advanced GridView features, such as 
        1. GridView summary
          the key on the GridVIew summary is the OnDataBound event  - you can calculate the sum on the OnDataBound event 
      -->
      <asp:SqlDataSource ID="sourceProducts" runat="server" ProviderName="System.Data.SqlClient" ConnectionString="<%$ ConnectionStrings:Northwind %>" 
            SelectCommand="SELECT ProductID, ProductName, UnitPrice, UnitsInStock FROM Products">
        </asp:SqlDataSource>
      <asp:GridView ID="gridSummary" runat="server" DataSourceID="sourceProducts" OnDataBound="gridSummary_DataBound" ShowFooter="true" AllowPaging="true" PageSize="10">
        
      </asp:GridView>

      <asp:SqlDataSource ID="sourceCategories" runat="server" ProviderName="System.Data.SqlClient" ConnectionString="<%$ ConnectionStrings:Northwind %>" 
          SelectCommand="SELECT * FROM Categories">
      </asp:SqlDataSource>
    
<!-- 2. 
    Build the master-child relationship 
    
    remember that there is a DataKeyNames and gridChild does not have DataSource ID set in the first place.
    -->
    <asp:SqlDataSource ID="sourceProducts2" runat="server" ProviderName="System.Data.SqlClient" ConnectionString="<%$ ConnectionStrings:Northwind %>" 
        SelectCommand="SELECT * FROM Products WHERE CategoryID=@CategoryID">
        <SelectParameters>
            <asp:Parameter Name="CategoryID" Type="Int32"/>
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:GridView runat="server" ID="gridMaster" DataSourceID="sourceCategories" OnRowDataBound="gridMaster_OnRowDataBound" DataKeyNames="CategoryID" AutoGenerateColumns="False" >
        <Columns>
            <asp:TemplateField HeaderText="Category">
                <ItemStyle VerticalAlign="Top" Width="20%"></ItemStyle>
                <ItemTemplate>
                    <br />
                    <b><%# Eval("CategoryName") %></b>
                    <br /><br />
                    <%# Eval("Description") %>
                    <br />
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Products">
                <ItemStyle VerticalAlign="Top"></ItemStyle>
                <ItemTemplate>
                    <asp:GridView runat="server" ID="gridChild" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="ProductName" HeaderText="Product Name"/>
                            <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" DataFormatString="{0:C}"/>
                        </Columns>
                    </asp:GridView>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        
    </asp:GridView>
        
        
    <!-- 3. use check table to edit controls 
        we need to create two sources, one is to select/update from Products table.
        
        another source is to provide check table and get the lists.
        -->
    <br /><br/>
    <b>Please edit the Details form below.</b>
    <asp:SqlDataSource runat="server" ID="sourceProducts3" ProviderName="System.Data.SqlClient" ConnectionString="<%$ ConnectionStrings:Northwind %>"
        SelectCommand="SELECT ProductID, ProductName, Products.CategoryID, CategoryName, UnitPrice FROM Products INNER JOIN Categories ON Products.CategoryID=Categories.CategoryID"
        UpdateCommand="UPDATE Products SET ProductName=@ProductName, CategoryID=@CategoryID, UnitPrice=@UnitPrice WHERE ProductID=@ProductID">
    </asp:SqlDataSource>

    <asp:SqlDataSource runat="server" ID="sourceCategories2" ProviderName="System.Data.SqlClient" ConnectionString="<%$ ConnectionStrings:Northwind %>"
        SelectCommand="SELECT CategoryName, CategoryID FROM Categories">
    </asp:SqlDataSource>
        
    <asp:DetailsView runat="server" ID="detailsProducts" AllowPaging="True" AutoGenerateEditButton="True" AutoGenerateRows="False" DataKeyNames="ProductID" DataSourceID="sourceProducts3">
        <Fields>
            <asp:BoundField DataField="ProductID" HeaderText="ID" ReadOnly="True" />
            <asp:BoundField DataField="ProductName" HeaderText="Product"/>
            <asp:TemplateField HeaderText="Category">
                <ItemTemplate>
                    <%# Eval("CategoryName") %>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList runat="server" ID="lstCategories" DataSourceID="sourceCategories2" DataTextField="CategoryName" DataValueField="CategoryID" SelectedValue='<%# Bind("CategoryID") %>'></asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="UnitPrice" HeaderText="Price" />
        </Fields>
    </asp:DetailsView>

    </div>
    </form>
</body>
</html>