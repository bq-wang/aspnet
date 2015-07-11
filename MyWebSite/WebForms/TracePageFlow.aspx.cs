using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebSite.WebForms
{
  public partial class TracePageFlow : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      lbInfo.Text += "Page.Load event handled.<br />";

      if (Page.IsPostBack)
      {
        lbInfo.Text += "<b>This is not the first time you've seen this page.</b> <br />";
      }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
      lbInfo.Text += "Page.Init event handled.<br />";
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
      lbInfo.Text += "Page.PreRender event handled.<br />";
    }


    protected void Page_Unload(object sender, EventArgs e)
    {
      lbInfo.Text += "Page.Unload event handled.<br />";
    }

    protected void Button1_Click(object sender, System.EventArgs e)
    {
      // provide one information, one class info, as below
      Trace.Write("Button1_Click", "About to update the label");
      lbInfo.Text += "Button1.Click event handled.<br />";
      Trace.Write("Button1_Click", "Label Updated");
    }
   }
 }
