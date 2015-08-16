<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ObjectDataSource_Binding_Form.aspx.cs" Inherits="MyWebSite.DataBindings.ObjectDataSource_Binding_Form" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <!-- TODO: -->
      <!-- not completed, as the EmployeeDB class is not yet ready -->
      <!-- define a Object Datasource -->
      <asp:ObjectDataSource ID="sourceEmployees" runat="server" SelectMethod="GetEmployees" TypeName="MyWebSite.DataSets.EmployeeDB"  />

      <asp:ListBox ID="listBox1" runat="server" DataSourceID="sourceEmployees" DataTextField="EmployeeID">
      </asp:ListBox>
      <asp:GridView ID="GridView" runat="server" DataSourceID="sourceEmployees">
      </asp:GridView>


      <!-- to use parameterized Object method -->
      <asp:ListBox ID="lstEmployees" runat="server" DataSourceID="sourceEmployees" DataTextField="EmployeeID"  AutoPostBack="true">
      </asp:ListBox>

      <asp:ObjectDataSource ID="sourceEmployee" runat="server" SelectMethod="GetEmployee" TypeName="MyWebSite.DataSets.EmployeeDB" OnSelecting="sourceEmployee_Selecting">
        <SelectParameters>
          <asp:ControlParameter ControlID="lstEmployees" Name="employeeID" PropertyName="SelectedValue" />
        </SelectParameters>
      </asp:ObjectDataSource>

      <asp:DetailsView ID="DetailsView1" runat="server" DataSourceID="sourceEmployee" />


      <!-- to update via ObjectDataSource -->

      <!-- 

OnUpdating="sourceEmployees_updating_Updating"
-->

      OnUpdating="sourceEmployees_updating_Updating"
       <asp:ObjectDataSource ID="sourceEmployees_updating" runat="server" SelectMethod="GetEmployees" TypeName="MyWebSite.DataSets.EmployeeDB" UpdateMethod="UpdateEmployee" >
        <%--<UpdateParameters>
          <asp:Parameter Name="employeeID" Type="Int32" />
        </UpdateParameters>--%>
      </asp:ObjectDataSource>

      <asp:GridView ID="GridVIewSourceUPdateNonStandardMethodSig" runat="server" DataSourceID="sourceEmployees_updating" AutoGenerateEditButton="true">
      </asp:GridView>


      <asp:SqlDataSource 
      ID="sourceEmployeeCities" 
      runat="server" 
      ProviderName="System.Data.SqlClient" 
      ConnectionString="<%$ ConnectionStrings:Northwind %>" 
      SelectCommand="SELECT DISTINCT City from Employees"
       />

      <!-- to handle with user added items -->
      <asp:DropDownList ID="DropDownListCities" runat="server" DataTextField="City" AutoPostBack="True">
      </asp:DropDownList>

      <asp:SqlDataSource ID="userAddedOptionsSourceEmployees" runat="server" ProviderName="System.Data.SqlClient" ConnectionString="<%$ ConnectionStrings:Northwind %>" 
        SelectCommand="SELECT * FROM Employees WHERE City=@City" OnSelecting="userAddedOptions_sourceEmployees_Selecting">
        <SelectParameters>
          <asp:ControlParameter ControlID="DropDownListCities" Name="City" PropertyName="SelectedValue" />
        </SelectParameters>
      </asp:SqlDataSource>

      <asp:GridView ID="CitiesBoundSourceEmployeesGrid" runat="server" DataSourceID="userAddedOptionsSourceEmployees" AutoGenerateEditButton="true">
      </asp:GridView>

    </div>
    </form>
</body>
</html>
