﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServerEvents.aspx.cs" Inherits="MyWebSite.ServerControls.ServerEvents" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <select runat="server" id="List1" size="5" multiple="true" onserverchange="List1_ServerChange">
        <option>Option 1</option>
        <option>Option 2</option>
      </select>

      <input type="text" runat="server" id="Textbox1" size="10" />
      <br />
      <input type="checkbox" runat="server" id="Checkbox1" onserverchange="Ctrl_ServerChange" />
      Option Text<br />

      <input type="submit" runat="server" id="Submit1" value="Submit Query" onserverclick="Submit1_ServerClick"/>
    </div>
    </form>
</body>
</html>
