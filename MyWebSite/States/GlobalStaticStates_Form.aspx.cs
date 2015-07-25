using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace MyWebSite.States
{
  public partial class GlobalStaticStates_Form : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      StringBuilder sb = new StringBuilder();
      foreach (var file in Global.FileList)
      {
        sb.Append(file + "<br />");
      }

      lblInfo.Text = sb.ToString();
    }
  }
}