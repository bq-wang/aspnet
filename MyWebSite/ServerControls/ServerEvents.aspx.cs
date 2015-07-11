using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebSite.ServerControls
{
  public partial class ServerEvents : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Ctrl_ServerChange(object sender, EventArgs e)
    {
      Response.Write("<li>Server change detected for " + ((Control)sender).ID + "</li>");
    }
  }
}