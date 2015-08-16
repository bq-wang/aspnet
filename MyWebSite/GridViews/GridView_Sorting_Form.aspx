<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GridView_Sorting_Form.aspx.cs" Inherits="MyWebSite.GridViews.GridView_Sorting_Form" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <!-- TODO:
        Grid view sorting , need employee DB 
      -->
      <!-- the SortParameterName choose the sorting parameter -->
      <asp:ObjectDataSource ID="sourceEmployees" runat="server" SelectMethod="GetEmployees" TypeName="MyWebSite.DataSets.EmployeeDB" SortParameterName="sortExpression"/>

      <!-- AllowSorting will change header to sortable header --> 
      <asp:GridView ID="sourceEmployeesSortedGridView" runat="server" DataSourceID="sourceEmployees" AllowSorting="true" >
      </asp:GridView>
    </div>
    </form>
</body>
</html>
