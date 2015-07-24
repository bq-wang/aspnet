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


      // below shows to handler IsCrossPagePostBack 
      // when IsCrossPagePostBack is true, meaning that the post back is triggered through server.transfer
      if (PreviousPage == null)
      {
        // directly requested or (post back - non-cross page)
      }
      else if (PreviousPage.IsCrossPagePostBack)
      {
        // button PostBackUrl triggered post-back
        lblInfo.Text += "Post back via IButonControl";
      }
      else
      {
        // Server.Transfer triggered post-back
        lblInfo.Text += "Post back via server.transfer()";
      }
    }
  }
}