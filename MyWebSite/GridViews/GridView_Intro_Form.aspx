<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GridView_Intro_Form.aspx.cs" Inherits="MyWebSite.GridViews.GridView_Intro_Form" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <!-- Auto Generate Columns == false, and create these columns explicitly -->
          <asp:SqlDataSource ID="sourceEmployees" runat="server" ProviderName="System.Data.SqlClient" ConnectionString="<%$ ConnectionStrings:Northwind %>" 
            SelectCommand="SELECT EmployeeID, FirstName, LastName, Title, City FROM Employees"
            />

    <asp:GridView ID="gridEmployees" runat="server" DataSourceID="sourceEmployees" AutoGenerateColumns="false">
      <Columns>
        <asp:BoundField DataField="EmployeeID" HeaderText="ID" />
        <asp:BoundField DataField="FirstName" HeaderText="First Name" />
        <asp:BoundField DataField="LastName" HeaderText="Last Name" />
        <asp:BoundField DataField="Title" HeaderText="Title" />
        <asp:BoundField DataField="City" HeaderText="City" />
      </Columns>
    </asp:GridView>
    </div>
    </form>
</body>
</html>
