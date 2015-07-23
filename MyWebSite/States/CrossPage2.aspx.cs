using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebSite.States
{
  public partial class CrossPage2 : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (PreviousPage != null)
      {
        lblInfo.Text = "you came from a page titled " + PreviousPage.Header.Title;
      }

      CrossPage1 prevPage = PreviousPage as CrossPage1;
      if (prevPage != null)
      {
        lblInfo.Text += "From previous page, name = " + prevPage.FullName;
      }
    }
  }
}