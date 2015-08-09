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
      <asp:ObjectDataSource ID="sourceEmployees" runat="server" SelectMethod="GetEmployees" TypeName="MyWebSite.DataSets.EmployeeDB" />

      <asp:ListBox ID="listBox1" runat="server" DataSourceID="sourceEmployees" DataTextField="EmployeeID">
      </asp:ListBox>
      <asp:GridView ID="GridView" runat="server" DataSourceID="sourceEmployees">
      </asp:GridView>


      <asp:ListBox ID="lstEmployees" runat="server" DataSourceID="sourceEmployees" DataTextField="EmployeeID"  AutoPostBack="true">
      </asp:ListBox>

      <asp:ObjectDataSource ID="sourceEmployee" runat="server" SelectMethod="GetEmployee" TypeName="MyWebSite.DataSets.EmployeeDB" OnSelecting="sourceEmployee_Selecting">
        <SelectParameters>
          <asp:ControlParameter ControlID="lstEmployees" Name="employeeID" PropertyName="SelectedValue" />
        </SelectParameters>
      </asp:ObjectDataSource>

      <asp:DetailsView ID="DetailsView1" runat="server" DataSourceID="sourceEmployee" />

    </div>
    </form>
</body>
</html>
