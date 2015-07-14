<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CalendarControl.aspx.cs" Inherits="MyWebSite.ServerControls.CalendarControl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <!-- SelectionMode value other than Day , check SelectedDates rather than SelectedDate -->
      <asp:Calendar runat="server" ID="Calendar1" ForeColor="Red" BackColor="LightYellow" OnSelectionChanged="Calendar1_SelectionChanged" SelectionMode="DayWeek" OnDayRender="Calendar1_DayRender"></asp:Calendar>

      <asp:Label ID="lblDates" runat="server" />
    </div>
    </form>
</body>
</html>
