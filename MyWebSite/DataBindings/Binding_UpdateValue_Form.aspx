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

      <br /><br />
      <!-- restrict on the concurrency -->
      <!-- one of the techniques are Comparing all the values before updating.
        the following are required

        * ConflictDetection CompareAllValues
        * OldValuesParameterFormatString
        * WHERE clause in the update method

      -->
      <asp:SqlDataSource ID="sourceEmployees2" runat="server" ProviderName="System.Data.SqlClient" ConnectionString="<%$ ConnectionStrings:Northwind %>" 
        SelectCommand="SELECT EmployeeID, FirstName, LastName, Title, City FROM Employees"
        ConflictDetection="CompareAllValues"
        OldValuesParameterFormatString="original_{0}"
        UpdateCommand="UPDATE Employees SET FirstName=@FirstName, LastName=@LastName, Title=@Title, City=@City FROM Employees WHERE EmployeeID=@original_EmployeeID AND FirstName=@original_FirstName AND LastName=@original_LastName AND Title=@original_Title AND City=@original_City" />

        <asp:GridView runat="server" AutoGenerateEditButton="true" DataSourceID="sourceEmployees2" ID="gridView2" />
        <br /><br />

        <!-- well to cope with stored procedures, here is what you can do
        the key below is the OnUpdating event handler
        
        remove the ConflictDetection and OldValuesParameterFormatString
         -->
      <asp:SqlDataSource ID="sourceEmployees3" runat="server" ProviderName="System.Data.SqlClient" ConnectionString="<%$ ConnectionStrings:Northwind %>" 
        SelectCommand="SELECT EmployeeID, FirstName, LastName, Title, City FROM Employees"
        UpdateCommandType="StoredProcedure"
        OnUpdating="sourceEmployees3_Updating"
        UpdateCommand="UpdateEmployee">
          <UpdateParameters>
            <asp:Parameter Name="First" Type="String" />
            <asp:Parameter Name="Last" Type="String" />
          </UpdateParameters>
        </asp:SqlDataSource>

        <asp:GridView runat="server" AutoGenerateEditButton="true" DataSourceID="sourceEmployees3" ID="gridView3" />


    </div>
    </form>
</body>
</html>
