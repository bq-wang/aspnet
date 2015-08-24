<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataCache_SqlDataSourceCache_Form.aspx.cs" Inherits="MyWebSite.Cache.DataCache_SqlDataSourceCache_Form" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <!-- 
      1. in this chapter, we will introduce the sqldatasource cahcing 
      -->

      <asp:SqlDataSource ID="sourceCities" runat="server" SelectCommand="SELECT DISTINCT City from Employees" ProviderName="System.Data.SqlClient" ConnectionString="<%$ ConnectionStrings:Northwind %>">
      
      </asp:SqlDataSource>

      <asp:DropDownList ID="lstCities" runat="server" DataSourceID="sourceCities" DataTextField="City" DataValueField="City" AutoPostBack="true"/>

      <!-- shows an Un-cached sql data source -->
<%--      <asp:SqlDataSource ID="sourceEmployees" runat="server" SelectCommand="SELECT EmployeeID, FirstName, LastName, Title, City FROM Employees WHERE City=@City" ProviderName="System.Data.SqlClient" ConnectionString="<%$ ConnectionStrings:Northwind %>" >
        <SelectParameters>
          <asp:ControlParameter ControlID="lstCities" Name="City" PropertyName="SelectedValue" />
        </SelectParameters>
      </asp:SqlDataSource> --%>

      <!-- 
       well, changed to Cached sql source, we need 

       1. EnableCaching = true
       2. Filter expression: City='{0}'
       3. FilterParameters.. 

      -->
      <asp:SqlDataSource ID="sourceEmployees" runat="server" SelectCommand="SELECT EmployeeID, FirstName, LastName, Title, City FROM Employees" ProviderName="System.Data.SqlClient" ConnectionString="<%$ ConnectionStrings:Northwind %>"
          FilterExpression="City='{0}'" EnableCaching="true">
          <FilterParameters>
            <asp:ControlParameter ControlID="lstCities" Name="City" PropertyName="SelectedValue" />
          </FilterParameters>
      </asp:SqlDataSource>



      <asp:GridView ID="gridEmployees" runat="server" AutoGenerateColumns="true" DataSourceID="sourceEmployees" />
    </div>
    </form>
</body>
</html>
