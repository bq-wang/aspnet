<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DirectoryContents_Form.aspx.cs" Inherits="MyWebSite.FileSystems.DirectoryContents_Form" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <!-- in this Form we will introduce how to bind GridView to display the Directory and File info -->
      <asp:Button runat="server" ID="cmdUp" OnClick="cmdUp_Click" Text="Up" />
      <asp:Label runat="server" ID="lblCurrentDir" />
      <asp:GridView runat="server" ID="gridDirList" AutoGenerateColumns="false" OnSelectedIndexChanged="gridDirList_OnSelectedIndexChanged" GridLines="None" CellPadding="0" CellSpacing="1" DataKeyNames="FullName">
        <Columns>
          <asp:TemplateField>
            <ItemTemplate>
              <img src="folder.jpg" alt="Folder" />
            </ItemTemplate>
          </asp:TemplateField>
          <asp:ButtonField DataTextField="Name" CommandName="Select" HeaderText="Name" />
          <asp:BoundField  HeaderText="Size" />
          <asp:BoundField DataField="LastWriteTime" HeaderText="Last Modified" />
        </Columns>
      </asp:GridView>

      <asp:GridView runat="server" ID="gridFileList" AutoGenerateColumns="false" OnSelectedIndexChanged="gridFileList_OnSelectedIndexChanged" GridLines="None" CellPadding="0" CellSpacing="1" DataKeyNames="FullName">
        <Columns>
          <asp:TemplateField>
            <ItemTemplate>
              <img src="file.jpg" alt="File" />
            </ItemTemplate>
          </asp:TemplateField>
          <asp:ButtonField DataTextField="Name" CommandName="Select" HeaderText="Select" />
          <asp:BoundField  HeaderText="Length" DataField="Length" />
          <asp:BoundField DataField="LastWriteTime" />
        </Columns>
      </asp:GridView>


      <asp:FormView runat="server" ID="formFileDetails">
        <ItemTemplate>
          <b>File:
            <%# DataBinder.Eval(Container.DataItem, "CreationItem") %><br />
          </b><br />

          Created at
          <%# DataBinder.Eval(Container.DataItem, "CreationItem") %><br />
          <%# DataBinder.Eval(Container.DataItem, "LastWriteTime") %><br />
          <%# DataBinder.Eval(Container.DataItem, "LastAccessTime") %><br />
          <%# DataBinder.Eval(Container.DataItem, "Attributes") %><br />
          <%# DataBinder.Eval(Container.DataItem, "Length") %><br />
          <%# GetVersionInfoString(DataBinder.Eval(Container.DataItem, "FullName")) %><br />
        </ItemTemplate>
      </asp:FormView>
    </div>
    </form>
</body>
</html>
