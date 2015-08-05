<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Binding_UpdateValue_Form.aspx.cs" Inherits="MyWebSite.DataBindings.Binding_UpdateValue_Form" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:SqlDataSource ID="sourceEmployees" runat="server" ProviderName="System.Data.SqlClient" ConnectionString="<%$ ConnectionStrings:Northwind %>" 
      SelectCommand="SELECT EmployeeID, FirstName, LastName, Title, City FROM Employees"
      UpdateCommand="UPDATE Employees SET FirstName=@FirstName, LastName=@LastName, Title=@Title, City=@City FROM Employees WHERE EmployeeID=@EmployeeID" />

      <asp:GridView runat="server" AutoGenerateEditButton="true" DataSourceID="sourceEmployees" ID="gridView1" />
    </div>
    </form>
</body>
</html>
