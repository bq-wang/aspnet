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

      <asp:Label ID="label1" Text="Please choose below the sorting fields" runat="server"/>
      <br />
      <asp:DropDownList ID="sortingLists" runat="server" OnSelectedIndexChanged="sortingLists_SelectedIndexChanged" AutoPostBack="true">
        <asp:ListItem Text="TitleOfCourtesy, FirstName, LastName" Value="TitleOfCourtesy, FirstName, LastName" Selected="True"/>
        <asp:ListItem Text="FirstName, LastName" Value="FirstName, LastName" />
        <asp:ListItem Text="LastName, FirstName" Value="LastName, FirstName" />
        <asp:ListItem Text="FirstName, LastName, TitleOfCourtesy" Value="FirstName, LastName, TitleOfCourtesy" />
      </asp:DropDownList>
      <br /><br />

      <!-- AllowSorting will change header to sortable header --> 
      <asp:GridView ID="sourceEmployeesSortedGridView" runat="server" DataSourceID="sourceEmployees" AllowSorting="true" OnSorting="gridEmployees_Sorting" >
      </asp:GridView>


    </div>
    </form>
</body>
</html>
