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
      if (!Page.IsPostBack)
      {
        List1.Items.Add("Option 3");
        List1.Items.Add("Option 4");
        List1.Items.Add("Option 5");
      }
    }

    protected void Ctrl_ServerChange(object sender, EventArgs e)
    {
      Response.Write("<li>Server change detected for " + ((Control)sender).ID + "</li>");
    }


    protected void List1_ServerChange(object sender, EventArgs e)
    {
      Response.Write("<li>ServerChange detected for List1. " + "The selected items are: </li><br />");

      foreach (ListItem li in List1.Items)
      {
        if (li.Selected)
        {
          Response.Write("&nbsp;&nbsp;- " + li.Value + "<br />");
        }
      }
    }

    protected void Submit1_ServerClick(object sender, EventArgs e)
    {
      Response.Write("<li>ServerClick detected for submit1.</li>");
    }
  }
}