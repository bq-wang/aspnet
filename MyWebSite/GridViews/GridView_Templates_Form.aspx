<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GridView_Templates_Form.aspx.cs" Inherits="MyWebSite.GridViews.GridView_Templates_Form" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:SqlDataSource ID="sourceEmployees" runat="server" ProviderName="System.Data.SqlClient" ConnectionString="<%$ ConnectionStrings:Northwind %>" 
      SelectCommand="SELECT * FROM Employees" />

     <asp:SqlDataSource ID="sourceProducts" runat="server" ProviderName="System.Data.SqlClient" ConnectionString="<%$ ConnectionStrings:Northwind %>" 
      SelectCommand="SELECT * FROM Products" />

      <!-- in this webform, we will introduce GridView templates -->
      <asp:GridView ID="gridEmployees" runat="server" DataSourceID="sourceEmployees" AutoGenerateColumns="false">
        <Columns>
          <asp:TemplateField HeaderText="Employees">
            <ItemTemplate>
              <b>
                <%# Eval("EmployeeID") %> - 
                <%# Eval("TitleOfCourtesy") %>  <%# Eval("FirstName") %>
                <%# Eval("LastName")%>
              </b>
              <hr />
              <small><i>
                  <%# Eval("Address") %>
                  <%# Eval("City") %>, <%# Eval("Country") %>
                  <%# Eval("PostalCode") %> <%# Eval("HomePhone") %>
                  <br /><br />
              </i></small>
              
              <%# Eval("Notes") %>
            </ItemTemplate>
            
          </asp:TemplateField>
        </Columns>
      </asp:GridView>


      <!-- Bound to Method -->
      <asp:GridView ID="gridEmployeesBoundToMethod" runat="server" DataSourceID="sourceProducts" AutoGenerateColumns="false" AllowPaging="true" PageSize="10">
        <Columns>
          <asp:TemplateField HeaderText="Status">
            <ItemTemplate>
              <img src='<%# GetStatusPicture(Container.DataItem) %>' alt="Status" />
            </ItemTemplate>
          </asp:TemplateField>
          <asp:BoundField DataField="ProductID" HeaderText="ID" />
          <asp:BoundField DataField="ProductName" HeaderText="Product" />
          <asp:BoundField DataField="UnitPrice" HeaderText="Price" />
          <asp:BoundField DataField="UnitsInStock" HeaderText="UnitsInStock" />
        </Columns>
      </asp:GridView>


      <!-- Template bindings and etc... -->
      <br /><br />
      <asp:Label ID="lblInfo" runat="server" />
      <asp:GridView ID="GridView1" runat="server" DataSourceID="sourceProducts" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" OnRowCommand="GridView1_RowCommand">
        <Columns>
          <asp:TemplateField HeaderText="Status">
            <ItemTemplate>
              <asp:ImageButton ID="ImageButton1" ImageUrl='<%# GetStatusPicture(Container.DataItem) %>' runat="server" CommandName="StatusClick" CommandArgument='<%# Eval("ProductID") %>'/>
            </ItemTemplate>
          </asp:TemplateField>
          <asp:BoundField DataField="ProductID" HeaderText="ID" />
          <asp:BoundField DataField="ProductName" HeaderText="Product" />
          <asp:BoundField DataField="UnitPrice" HeaderText="Price" />
          <asp:BoundField DataField="UnitsInStock" HeaderText="UnitsInStock" />
        </Columns>
      </asp:GridView>
    </div>
    </form>
</body>
</html>
