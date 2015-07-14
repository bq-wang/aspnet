using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebSite.ServerControls
{
  public partial class CalendarControl : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
      // if SelectionMode is other than Day, check SelectedDates rather than SelectedDate
      //lblDates.Text = "You selected: " + Calendar1.SelectedDate.ToLongDateString();


      lblDates.Text = "You selected these dates: <br />";

      foreach (DateTime dt in Calendar1.SelectedDates)
      {
        lblDates.Text += dt.ToLongDateString() + "<br />";
      }
    }

    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
      if (e.Day.IsWeekend)
      {
        e.Cell.BackColor = System.Drawing.Color.Green;
        e.Cell.ForeColor = System.Drawing.Color.Yellow;
        e.Day.IsSelectable = false;
      }
    }
  }
}