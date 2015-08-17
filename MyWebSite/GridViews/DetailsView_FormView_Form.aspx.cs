using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebSite.GridViews
{
  public partial class DetailsView_FormView_Form : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void FormView1_ItemUpdating(object sender, FormViewUpdateEventArgs e)
    {
      DropDownList title = (DropDownList)FormView1.FindControl("EditTitle");
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