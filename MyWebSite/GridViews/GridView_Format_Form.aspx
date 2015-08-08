<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GridView_Format_Form.aspx.cs" Inherits="MyWebSite.GridViews.GridView_Format_Form" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:SqlDataSource ID="sourceEmployees" runat="server" ProviderName="System.Data.SqlClient"
        ConnectionString="<%$ ConnectionStrings:Northwind %>" SelectCommand="SELECT EmployeeID, FirstName, LastName, Title, City, Country, BirthDate, Notes FROM Employees" />


      <!-- learn how to do Format in GridView -->
      <asp:GridView ID="GridView1" runat="server" DataSourceID="sourceEmployees" Font-Names="Verdana" Font-Size="X-Small" ForeColor="#333333" CellPadding="4" GridLines="None" AutoGenerateColumns="false">
      <HeaderStyle BackColor="#990000" Font-Bold="true" ForeColor="White" />
      <RowStyle BackColor="#FFBD6"  ForeColor="#333333" />
      <AlternatingRowStyle BackColor="White" />
        <Columns>
          <asp:BoundField DataField="EmployeeID" HeaderText="ID">
            <ItemStyle Font-Bold="true" BorderWidth="1" />
          </asp:BoundField>
          <asp:BoundField DataField="FirstName" HeaderText="First Name" />
          <asp:BoundField DataField="LastName" HeaderText="Last Name" />
          <asp:BoundField DataField="Title" HeaderText="Title" />
          <asp:BoundField DataField="City" HeaderText="City">
            <ItemStyle BackColor="LightSteelBlue" />
          </asp:BoundField>
          <asp:BoundField DataField="Country" HeaderText="Country">
            <ItemStyle BackColor="LightSteelBlue" />
          </asp:BoundField>
          <asp:BoundField DataField="BirthDate" HeaderText="Birth Date" DataFormatString="{0:MM/dd/yyyy}" />
          <asp:BoundField DataField="Notes" HeaderText="Notes">
            <ItemStyle Wrap="true" Width="400" />
           </asp:BoundField>
        </Columns>
      </asp:GridView>

      <br />
      <br />


      <asp:SqlDataSource ID="sourceEmployees2" runat="server" ProviderName="System.Data.SqlClient"
        ConnectionString="<%$ ConnectionStrings:Northwind %>" SelectCommand="SELECT EmployeeID, FirstName, LastName, TitleOfCourtesy FROM Employees" />
      <asp:GridView ID="gird" runat="server" DataSourceID="sourceEmployees2" Font-Names="Verdana"
        Font-Size="X-Small" ForeColor="#333333" CellPadding="4" GridLines="None" OnRowDataBound="gridEmployees_RowDataBound">
      </asp:GridView>

      <asp:GridView ID="CommandFieldGrid" runat="server" DataSourceID="sourceEmployees2" Font-Names="Verdana"
        Font-Size="X-Small" ForeColor="#333333" CellPadding="4" GridLines="None">
        <SelectedRowStyle BackColor="#FFBD6" ForeColor="#333333" />
        <Columns>
          <asp:CommandField ShowSelectButton="true" ButtonType="Button" />
          <asp:CommandField ShowSelectButton="true" ButtonType="Image" SelectImageUrl="Select.gif" />

          <asp:BoundField DataField="EmployeeID" HeaderText="ID" />
          <asp:BoundField DataField="FirstName" HeaderText="First Name" />
          <asp:BoundField DataField="LastName" HeaderText="Last Name" />
        </Columns>
      </asp:GridView>

      <!-- Maste-details form, DataKeyNames = EmployeeID  -->
      <asp:GridView ID="gridEmployees" runat="server" DataSourceID="sourceEmployees2" Font-Names="Verdana"
        Font-Size="X-Small" ForeColor="#333333" CellPadding="4" GridLines="None" DataKeyNames="EmployeeID">

        <SelectedRowStyle BackColor="#FFBD6" ForeColor="#333333" />
        <Columns>
          <asp:CommandField ShowSelectButton="true" ButtonType="Button" />
          <asp:CommandField ShowSelectButton="true" ButtonType="Image" SelectImageUrl="Select.gif" />

          <asp:BoundField DataField="EmployeeID" HeaderText="ID" />
          <asp:BoundField DataField="FirstName" HeaderText="First Name" />
          <asp:BoundField DataField="LastName" HeaderText="Last Name" />
        </Columns>
      </asp:GridView>

      <asp:SqlDataSource ID="sourceRegions" runat="server" ConnectionString="<%$ ConnectionStrings:Northwind %>" ProviderName="System.Data.SqlClient" 
        SelectCommand="SELECT Employees.EmployeeID, Territories.TerritoryID, Territories.TerritoryDescription FROM Employees INNER JOIN EmployeeTerritories ON Employees.EmployeeID = EmployeeTerritories.EmployeeID INNER JOIN Territories ON EmployeeTerritories.TerritoryID = Territories.TerritoryID WHERE (Employees.EmployeeID = @EmployeeID)">
        <SelectParameters>
          <asp:ControlParameter ControlID="gridEmployees" Name="EmployeeID" PropertyName="SelectedDataKey.Values[&quot;EmployeeID&quot;]" />
        </SelectParameters>
      </asp:SqlDataSource>


      <asp:GridView ID="gridRegions" runat="server" DataSourceID="sourceRegions">
        <Columns>
          <asp:BoundField DataField="TerritoryID" HeaderText="ID" />
          <asp:BoundField DataField="TerritoryDescription" HeaderText="Description" />
        </Columns>
      </asp:GridView>
    </div>
    </form>
</body>
</html>
