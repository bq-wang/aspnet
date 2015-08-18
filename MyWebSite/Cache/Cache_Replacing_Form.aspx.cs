using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebSite.Cache
{
  public partial class Cache_Replacing_Form : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      Response.Write("This Date is cached with the page: ");
      Response.Write(DateTime.Now.ToString() + "<br />");
      Response.Write("The date is not: ");
      Response.WriteSubstitution(new HttpResponseSubstitutionCallback(GetDate));
    }

    private static string GetDate(HttpContext context)
    {
      return "<b>" + DateTime.Now.ToString() + "</b>";
    }
  }
}