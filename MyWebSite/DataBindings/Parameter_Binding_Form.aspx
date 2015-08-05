<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Parameter_Binding_Form.aspx.cs" Inherits="MyWebSite.DataBindings.Parameter_Binding_Form" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <!-- the following shows how you can define SqlDataSource and binding with the DataSource -->
      <asp:SqlDataSource ID="sourceEmployees" runat="server" ProviderName="System.Data.SqlClient" ConnectionString="<%$ ConnectionStrings:Northwind %>" SelectCommand="SELECT EmployeeID, FirstName, LastName, Title, City FROM Employees" />

      <asp:listbox runat="server" DataSourceID="sourceEmployees" DataTextField="EmployeeID"></asp:listbox>
      <asp:DataGrid runat="server" DataSourceID="sourceEmployees" />

      <br /><br />

      <asp:SqlDataSource ID="sourceEmployeeCities" runat="server" ProviderName="System.Data.SqlClient" ConnectionString="<%$ ConnectionStrings:Northwind %>" SelectCommand="SELECT DISTINCT City from Employees" />

      <asp:SqlDataSource ID="sourceEmployees2" runat="server" ProviderName="System.Data.SqlClient" ConnectionString="<%$ ConnectionStrings:Northwind %>" SelectCommand="SELECT EmployeeID, FirstName, LastName, Title, City FROM Employees WHERE City=@City">
        <SelectParameters>
          <asp:ControlParameter ControlID="lstCities" Name="City" PropertyName="SelectedValue" />
        </SelectParameters>
      </asp:SqlDataSource>

      <asp:DropDownList ID="lstCities" runat="server" AutoPostBack="True" 
        DataSourceID="sourceEmployeeCities" DataTextField="City">
      </asp:DropDownList>

      <br /><br />
      <asp:GridView ID="GridView1" runat="server" DataSourceID="sourceEmployees2">
      </asp:GridView>

      <br /><br />
      <asp:SqlDataSource ID="sourceEmployees3" runat="server" ProviderName="System.Data.SqlClient" ConnectionString="<%$ ConnectionStrings:Northwind %>" SelectCommand="GetEmployeesByCity" SelectCommandType="StoredProcedure">
        <SelectParameters>
          <asp:ControlParameter ControlID="lstCities" Name="City" PropertyName="SelectedValue" />
        </SelectParameters>
      </asp:SqlDataSource>

      <br /><br />
      <asp:GridView ID="GridView2" runat="server" DataSourceID="sourceEmployees3">
      </asp:GridView>
    </div>
    </form>
</body>
</html>

