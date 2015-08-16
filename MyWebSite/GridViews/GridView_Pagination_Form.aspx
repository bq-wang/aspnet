<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GridView_Pagination_Form.aspx.cs" Inherits="MyWebSite.GridViews.GridView_Pagination_Form" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <!-- Pagination by GridView itself. -->
      <asp:SqlDataSource ID="sourceEmployees" runat="server" ProviderName="System.Data.SqlClient" ConnectionString="<%$ ConnectionStrings:Northwind %>" 
            SelectCommand="SELECT EmployeeID, FirstName, LastName, Title, City FROM Employees" />
      <asp:GridView ID="GridView1" runat="server" DataSourceID="sourceEmployees" PageSize="5" AllowPaging="true" />

      <!-- Object data source to support paging.
        
        to enable ObjectDataSource to use Paging, we need 
        1. EnablePaging : true
        2. StartRowIndexParameter: startRowIndex - refer to your object method signature
        3. MaximumRowsParameterName: maximumRows - refer to your object method signature
      
       -->
      <asp:ObjectDataSource 
      ID="sourceEmployeesObjectDataSource" 
      runat="server" 
      SelectMethod="GetEmployees"
      TypeName="MyWebSite.DataSets.EmployeeDB"
      SelectCountMethod="CountEmployees"
      StartRowIndexParameterName="startRowIndex"
      MaximumRowsParameterName="maximumRows"
      EnablePaging="true" />

     <asp:GridView ID="GridView2" runat="server" DataSourceID="sourceEmployeesObjectDataSource" PageSize="5" AllowPaging="true"/>

    </div>
    </form>
</body>
</html>
