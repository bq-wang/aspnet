using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebSite.GridViews
{
  public partial class GridView_Templates_Form : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected string GetStatusPicture(object dataItem)
    {
      int units = Int32.Parse(DataBinder.Eval(dataItem, "UnitsInStock").ToString());
      if (units == 0)
        return "Cancel.gif";
      else if (units > 50)
        return "OK.gif";
      else
        return "blank.gif";
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      if (e.CommandName == "StatusClick")
        lblInfo.Text = "You clicked product #" + e.CommandArgument;
    }
  }
}