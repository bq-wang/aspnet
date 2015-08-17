<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetailsView_FormView_Form.aspx.cs" Inherits="MyWebSite.GridViews.DetailsView_FormView_Form" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <!-- 1. in this ewb form, we will introduce the Details view and Form view -->
      <asp:SqlDataSource ID="sourceEmployees" runat="server" ProviderName="System.Data.SqlClient" ConnectionString="<%$ ConnectionStrings:Northwind %>" 
            SelectCommand="SELECT EmployeeID, FirstName, LastName, Title, City, Country, Notes, Address, Region, PostalCode, HomePhone, TitleOfCourtesy, BirthDate FROM Employees"
            UpdateCommand="UPDATE Employees SET NOTEs=@Notes WHERE EmployeeID=@EmployeeID"
            UpdateCommandType="Text">
        </asp:SqlDataSource>
      <asp:DetailsView ID="DetailsView1" runat="server" DataSourceID="sourceEmployees" AutoGenerateRows="false">
        <Fields>
          <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" />
          <asp:BoundField DataField="FirstName" HeaderText="FirstName" />
          <asp:BoundField DataField="LastName" HeaderText="LastName" />
          <asp:BoundField DataField="Title" HeaderText="Title" />
          <asp:BoundField DataField="TitleOfCourtesy" HeaderText="TitleOfCourtesy" />
          <asp:BoundField DataField="BirthDate" HeaderText="BirthDate" />
        </Fields>
      </asp:DetailsView>


      <!-- 2. Form view  - if you need maximize the template's flesibility, FormView is a control to display/edit single records -->
      <asp:FormView ID="FormView1" runat="server" DataSourceID="sourceEmployees" OnItemUpdating="FormView1_ItemUpdating" DataKeyNames="EmployeeID">
        <ItemTemplate>
          <b>
            <%# Eval("EmployeeID") %>
            <%# Eval("TitleOfCourtesy") %> <%# Eval("FirstName")%> 
             <%# Eval("LastName")%> 
          </b>
          <small>
              <i><%# Eval("Address") %> <br />
              <%# Eval("City") %>, <%# Eval("Country") %>,
              <%# Eval("PostalCode") %>
              <%# Eval("HomePhone") %> </i>
              <br /> <br />
              <%# Eval("Notes") %>
              <br /> <br />
            </small>
            <br />
            <asp:linkbutton runat="server" Text="Edit" CommandName="Edit" ID="cmdEdit" />
            <!-- you have to manual insert a linkbutton or button to generate commands that supports insert/delete/update -->
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
      </asp:FormView>
    </div>
    </form>
</body>
</html>
