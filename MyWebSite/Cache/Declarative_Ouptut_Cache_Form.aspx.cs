using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebSite.Cache
{
  public partial class Declarative_Ouptut_Cache_Form : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      // other than the standard OutputCache directive, you can also introduce the cacheability explicit by code

      Response.Cache.SetCacheability(HttpCacheability.Public);

      // in the next 60 seconds, use the cached copy
      Response.Cache.SetExpires(DateTime.Now.AddSeconds(60));

      // 
      Response.Cache.SetValidUntilExpires(true);

      lblDate.Text = "The time isnow:<br />";
      lblDate.Text += DateTime.Now.ToString();
    }
  }
}