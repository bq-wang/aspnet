<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListView_Template_Form.aspx.cs" Inherits="MyWebSite.GridViews.ListView_Template_Form" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <!-- 1. set the element for Layout template to "itemPlaceholder"
    the placeholder control has to be a server control , which means it must have r unat="se rver" attributes.
     -->
    <form id="form1" runat="server">
    <div>
        <asp:SqlDataSource ID="sourceEmployees" runat="server" ProviderName="System.Data.SqlClient" ConnectionString="<%$ ConnectionStrings:Northwind %>" 
            SelectCommand="SELECT EmployeeID, FirstName, LastName, Title, City, Country, Notes, Address, Region, PostalCode, HomePhone, TitleOfCourtesy FROM Employees"
            UpdateCommand="UPDATE Employees SET NOTEs=@Notes WHERE EmployeeID=@EmployeeID"
            UpdateCommandType="Text">
        </asp:SqlDataSource>
      <asp:ListView runat="server" DataSourceID="sourceEmployees" ID="listEmployees">
        <LayoutTemplate>
          <span id="itemPlaceholder" runat="server"></span>
        </LayoutTemplate>
        <ItemTemplate>
          <span>
            <b>
              <%# Eval("EmployeeID") %> - 
              <%# Eval("TitleOfCourtesy") %> <%# Eval("FirstName") %>
              <%# Eval("LastName") %>
            </b>
            <hr />
            <small>
              <i><%# Eval("Address") %> <br />
              <%# Eval("City") %>, <%# Eval("Country") %>,
              <%# Eval("PostalCode") %>
              <%# Eval("HomePhone") %> </i>
              <br /> <br />
              <%# Eval("Notes") %>
              <br /> <br />
            </small>
          </span>
        </ItemTemplate>
      </asp:ListView>

      <!-- you can modify the example to use table, such as 
        <LayoutTemplate>
          <span id="itemPlaceholder" r unat="s erver"></span>
        </LayoutTemplate>


        <LayoutTemplate>
          <table border="1">
            <tr id="itemPlaceholder" r unat="s erver" />
          </table>

        
        or 

         <LayoutTemplate>
          <table border="1">
            <tr valign="top" border="1"><td id="itemPlaceholder" r unat="s erver" /></tr>
          </table>
    -->

    <!-- 2.  e.g of the ListView showing in Td -->

    <asp:ListView runat="server" DataSourceID="sourceEmployees" ID="ListView1">
        <LayoutTemplate>
          <table border="1">
            <tr valign="top" border="1"><td id="itemPlaceholder" runat="server" /></tr>
          </table>
        </LayoutTemplate>
        <ItemTemplate>
          <td>
            <b>
              <%# Eval("EmployeeID") %> - 
              <%# Eval("TitleOfCourtesy") %> <%# Eval("FirstName") %>
              <%# Eval("LastName") %>
            </b>
            <hr />
            <small>
              <i><%# Eval("Address") %> <br />
              <%# Eval("City") %>, <%# Eval("Country") %>,
              <%# Eval("PostalCode") %>
              <%# Eval("HomePhone") %> </i>
              <br /> <br />
              <%# Eval("Notes") %>
              <br /> <br />
            </small>
          </td>
        </ItemTemplate>

      </asp:ListView>

    <!-- 3. ListView grouping 
    
      key change: itemPlaceholder changed to groupPlaceholder


    -->
    <b><p>Group of ListView.</p>
    </b>
    <br /><br />
     <asp:ListView runat="server" DataSourceID="sourceEmployees" ID="ListView2" GroupItemCount="3">
       <LayoutTemplate>
        <table border="1">
          <tr id="groupPlaceholder" runat="server"></tr>
        </table>
       </LayoutTemplate>
        <GroupTemplate>
          <tr><td runat="server" id="itemPlaceholder" valign="top" /></tr>
        </GroupTemplate>

        <ItemTemplate>
          <td>
            <b>
              <%# Eval("EmployeeID") %> - 
              <%# Eval("TitleOfCourtesy") %> <%# Eval("FirstName") %>
              <%# Eval("LastName") %>
            </b>
            <hr />
            <small>
              <i><%# Eval("Address") %> <br />
              <%# Eval("City") %>, <%# Eval("Country") %>,
              <%# Eval("PostalCode") %>
              <%# Eval("HomePhone") %> </i>
              <br /> <br />
              <%# Eval("Notes") %>
              <br /> <br />
            </small>
          </td>
        </ItemTemplate>
      </asp:ListView>

      <!-- 4. DataPager with ListView -->
       <asp:ListView runat="server" DataSourceID="sourceEmployees" ID="ListView3" GroupItemCount="3">
       <LayoutTemplate>
        <table border="1">
          <tr id="groupPlaceholder" runat="server"></tr>
        </table>
        <asp:DataPager runat="server" ID="ContactsDataPager" PageSize="6">
          <Fields>
            <asp:NextPreviousPagerField
              ShowFirstPageButton="true" ShowLastPageButton="true" FirstPageText="|&lt;&lt;" LastPageText="&gt;&gt;|" NextPageText=" &gt; " PreviousPageText=" &lt; " />
          </Fields>
        </asp:DataPager>
       </LayoutTemplate>

       <GroupTemplate>
          <tr><td runat="server" id="itemPlaceholder" valign="top" /></tr>
        </GroupTemplate>
        <ItemTemplate>
          <td>
            <b>
              <%# Eval("EmployeeID") %> - 
              <%# Eval("TitleOfCourtesy") %> <%# Eval("FirstName") %>
              <%# Eval("LastName") %>
            </b>
            <hr />
            <small>
              <i><%# Eval("Address") %> <br />
              <%# Eval("City") %>, <%# Eval("Country") %>,
              <%# Eval("PostalCode") %>
              <%# Eval("HomePhone") %> </i>
              <br /> <br />
              <%# Eval("Notes") %>
              <br /> <br />
            </small>
          </td>
        </ItemTemplate>
      </asp:ListView>

    </div>
    </form>

    
</body>
</html>
