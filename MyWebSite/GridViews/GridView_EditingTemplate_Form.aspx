<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GridView_EditingTemplate_Form.aspx.cs" Inherits="MyWebSite.GridViews.GridView_EditingTemplate_Form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <!-- EditItemTemplate wil have a TextBox to display the content of Notes -- to allow editing on the Notes.
            Pay close attention that in teh TextBox uses Bind() rather than Eval() method.
             -->
        
                <!--<asp:Parameter Name="EmployeeID" Type="String"/>
                <asp:Parameter Name="FirstName" Type="String"/>
                <asp:Parameter Name="LastName" Type="String"/>
                <asp:Parameter Name="Title" Type="String"/>
                <asp:Parameter Name="City" Type="String"/>
                <asp:Parameter Name="Country" Type="String"/>
                <asp:Parameter Name="Notes" Type="String"/>
                <asp:Parameter Name="Address" Type="String"/>
                <asp:Parameter Name="Region" Type="String"/>
                <asp:Parameter Name="PostalCode" Type="String"/>
                <asp:Parameter Name="HomePhone" Type="String"/>
                <asp:Parameter Name="TitleOfCourtesy" Type="String"/>-->
        
        <!-- 
            
            <UpdateParameters>
                <asp:Parameter Name="Notes" Type="String"/>
                <asp:Parameter Name="EmployeeID" Type="Int32"/>
            </UpdateParameters>
        -->

        <asp:SqlDataSource ID="sourceEmployees" runat="server" ProviderName="System.Data.SqlClient" ConnectionString="<%$ ConnectionStrings:Northwind %>" 
            SelectCommand="SELECT EmployeeID, FirstName, LastName, Title, City, Country, Notes, Address, Region, PostalCode, HomePhone, TitleOfCourtesy FROM Employees"
            UpdateCommand="UPDATE Employees SET NOTEs=@Notes WHERE EmployeeID=@EmployeeID"
            UpdateCommandType="Text">
        </asp:SqlDataSource>
        
        <!-- 
            GridView going out of the page asp.net
            http://stackoverflow.com/questions/15246071/gridview-going-out-of-page-asp-net
            You can find more content on the book "Pro ASP.NET 4 in C# 2010" in  
                https://books.google.com.hk/books?id=2wg5LCKuChcC&printsec=frontcover&hl=zh-CN#v=onepage&q&f=false
        -->
        <asp:GridView ID="gridEmployees" runat="server" DataSourceID="sourceEmployees" AutoGenerateColumns="false" AutoGenerateEditButton="True" DataKeyNames="EmployeeID">
        <Columns>
          <asp:TemplateField HeaderText="Employees">
            <ItemTemplate>
              <b>
                <%# Eval("EmployeeID") %> - 
                <%# Eval("TitleOfCourtesy") %>  <%# Eval("FirstName") %>
                <%# Eval("LastName")%>
              </b>
              <hr />
              <small><i>
                  <%# Eval("Address") %>
                  <%# Eval("City") %>, <%# Eval("Country") %>
                  <%# Eval("PostalCode") %> <%# Eval("HomePhone") %></i>
                  <br /><br />

              <%# Eval("Notes") %>
              </small>
              
            </ItemTemplate>

            <EditItemTemplate>
                <b>
                  <%# Eval("EmployeeID") %> - 
                  <%# Eval("TitleOfCourtesy") %>  <%# Eval("FirstName") %>
                  <%# Eval("LastName")%>
                </b>
                <hr />
                <small><i>
                  <%# Eval("Address") %>
                  <%# Eval("City") %>, <%# Eval("Country") %>
                  <%# Eval("PostalCode") %> <%# Eval("HomePhone") %></i>
                  <br /><br />
                 
                  <asp:TextBox runat="server" Text='<%# Bind("Notes") %>' ID="textBox" TextMode="MultiLine" Width="413px" />
               </small>
              </EditItemTemplate>
          </asp:TemplateField>
        </Columns>
      </asp:GridView>
        
        <!-- gridEmployees2 have the advanced editing template for the TitleOfCourtesy field - a drop down for selection -->
        <br />
        <br/>
    
    <br /><br />
    <asp:SqlDataSource ID="sourceEmployees2" runat="server" ProviderName="System.Data.SqlClient" ConnectionString="<%$ ConnectionStrings:Northwind %>" 
            SelectCommand="SELECT EmployeeID, FirstName, LastName, Title, City, Country, Notes, Address, Region, PostalCode, HomePhone, TitleOfCourtesy FROM Employees"
            UpdateCommand="UPDATE Employees SET NOTEs=@Notes, TitleOfCourtesy=@TitleOfCourtesy WHERE EmployeeID=@EmployeeID"
            UpdateCommandType="Text">
    </asp:SqlDataSource>

    <asp:GridView ID="gridEmployees2" runat="server" DataSourceID="sourceEmployees2" AutoGenerateColumns="false" AutoGenerateEditButton="True" DataKeyNames="EmployeeID" OnRowUpdating="gridEmployees2_RowUpdating">
        <Columns>
          <asp:TemplateField HeaderText="Employees">
            <ItemTemplate>
              <b>
                <%# Eval("EmployeeID") %> - 
                <%# Eval("TitleOfCourtesy") %>  <%# Eval("FirstName") %>
                <%# Eval("LastName")%>
              </b>
              <hr />
              <small><i>
                  <%# Eval("Address") %>
                  <%# Eval("City") %>, <%# Eval("Country") %>
                  <%# Eval("PostalCode") %> <%# Eval("HomePhone") %></i>
                  <br /><br />

              <%# Eval("Notes") %>
              </small>
              
            </ItemTemplate>

            <EditItemTemplate>
                <b>
                  <%# Eval("EmployeeID") %> - 
                  <asp:DropDownList runat="server" ID="EditTitle" DataSource='<%# TitlesOfCourtesy %>' AutoPostBack="True" SelectedIndex='<%# GetSelectedTitle(Eval("TitleOfCourtesy")) %>'/>
                  <%# Eval("FirstName") %>
                  <%# Eval("LastName")%>
                </b>
                <hr />
                <small><i>
                  <%# Eval("Address") %>
                  <%# Eval("City") %>, <%# Eval("Country") %>
                  <%# Eval("PostalCode") %> <%# Eval("HomePhone") %></i>
                  <br /><br />
                 
                  <asp:TextBox runat="server" Text='<%# Bind("Notes") %>' ID="textBox" TextMode="MultiLine" Width="413px" />
               </small>
              </EditItemTemplate>
          </asp:TemplateField>
        </Columns>
      </asp:GridView>
    
        
        
        <!-- 
            Comparing to gridEmployees2, gridEmployees3 will introduce our own editing/updating/cancel buttons -->
        <br /><br />
        <b>Below shows inner linked Update controls</b>
        <asp:GridView ID="gridEmployees3" runat="server" DataSourceID="sourceEmployees2" AutoGenerateColumns="false" DataKeyNames="EmployeeID" OnRowUpdating="gridEmployees2_RowUpdating">
        <Columns>
          <asp:TemplateField HeaderText="Employees">
            <ItemTemplate>
              <b>
                <%# Eval("EmployeeID") %> - 
                <%# Eval("TitleOfCourtesy") %>  <%# Eval("FirstName") %>
                <%# Eval("LastName")%>
              </b>
              <hr />
              <small><i>
                  <%# Eval("Address") %>
                  <%# Eval("City") %>, <%# Eval("Country") %>
                  <%# Eval("PostalCode") %> <%# Eval("HomePhone") %></i>
                  <br /><br />

              <%# Eval("Notes") %>
                  
                  <br /><br />
                  <asp:LinkButton runat="server" Text="Edit" CommandName="Edit" ID="cmdEdit" />
              </small>
              
            </ItemTemplate>

            <EditItemTemplate>
                <b>
                  <%# Eval("EmployeeID") %> - 
                  <asp:DropDownList runat="server" ID="EditTitle" DataSource='<%# TitlesOfCourtesy %>' AutoPostBack="True" SelectedIndex='<%# GetSelectedTitle(Eval("TitleOfCourtesy")) %>'/>
                  <%# Eval("FirstName") %>
                  <%# Eval("LastName")%>
                </b>
                <hr />
                <small><i>
                  <%# Eval("Address") %>
                  <%# Eval("City") %>, <%# Eval("Country") %>
                  <%# Eval("PostalCode") %> <%# Eval("HomePhone") %></i>
                  <br /><br />
                 
                  <asp:TextBox runat="server" Text='<%# Bind("Notes") %>' ID="textBox" TextMode="MultiLine" Width="413px" />
                    
                    <br /><br />
                    <asp:LinkButton runat="server" Text="Update" CommandName="Update" ID="cmdUpdate" />
                    <asp:LinkButton runat="server" Text="Cancel" CommandName="Cancel" ID="cmdCacel" />
               </small>
              </EditItemTemplate>
          </asp:TemplateField>
        </Columns>
      </asp:GridView>

    </div>
    </form>
</body>
</html>