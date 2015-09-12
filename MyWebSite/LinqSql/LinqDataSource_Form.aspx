<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LinqDataSource_Form.aspx.cs" Inherits="MyWebSite.LinqSql.LinqDataSource_Form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%--  1. in this post, we will watch an example where the data source steming from LinqDataSource 
            to do that 
            1. construct the DBML designer , we will add the Employee, EmployeeTerritory and Territory
            2. create controls with the GridView and DetailsView (one to display all the employees and the other to display a single record
            3. Link the DataContext and the Data controls 

           Nearly forget, to enable GridView select, you will need to set AutoGenerateSelectButton to "true"
            --%>
        <asp:GridView ID="gridEmployees" runat="server" DataSourceID="sourceEmployees" DataKeyNames="EmployeeID" AutoGenerateSelectButton="True">

            <Columns>

                <asp:TemplateField HeaderText="# Linked Territories">
                    <ItemTemplate>
                        <%# Eval("EmployeeTerritories.Count") %>
                    </ItemTemplate>
                </asp:TemplateField>

                <%-- suppose that you have a Order grid, you can nagivate to the parent record as well %-->
                <%--
                <asp:TemplateField HeaderText="Order By">
                    <ItemTemplate>
                        <%# Eval("Customer.CompanyName") %>
                    </ItemTemplate>
                </asp:TemplateField> --%>
            </Columns>
        </asp:GridView>
        <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="125px" DataSourceID="sourceSingleEmployee"></asp:DetailsView>

        <asp:LinqDataSource
            ID="sourceEmployees"
            runat="server"
            ContextTypeName="MyWebSite.LinqSql.AutoGen.NorthwindDataContext"
            EntityTypeName=""
            TableName="Employees"
            Select="new (EmployeeID, LastName, FirstName, TitleOfCourtesy, EmployeeTerritories)">
        </asp:LinqDataSource>
        <asp:LinqDataSource 
            ID="sourceSingleEmployee" 
            runat="server" 
            ContextTypeName="MyWebSite.LinqSql.AutoGen.NorthwindDataContext" 
            EntityTypeName="" 
            TableName="Employees"
            Where="EmployeeID.ToString() == @EmployeeID">
            <WhereParameters>
                <asp:ControlParameter ControlID="gridEmployees" Name="EmployeeID" PropertyName="SelectedValue" Type="String" />
            </WhereParameters>
        </asp:LinqDataSource>
    </div>

    </form>
</body>
</html>
