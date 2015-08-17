using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebSite.GridViews
{
  public partial class GridView_EditingTemplate_Form : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void gridEmployees2_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
      DropDownList title = (DropDownList)(gridEmployees2).Rows[e.RowIndex].FindControl("EditTitle");
      if (title != null)
      {
        e.NewValues.Add("TitleOfCourtesy", title.Text);
      }
    }

    protected string[] TitlesOfCourtesy
    {
      get
      {
        return new string[] { "Mr.", "Dr.", "Ms.", "Mrs." };
      }
    }

    protected int GetSelectedTitle(object title)
    {
      return Array.IndexOf(TitlesOfCourtesy, title);
    }

  }
}