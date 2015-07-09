using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace MyWebSite.WebForms
{
  public partial class PageHeader : System.Web.UI.Page
  {
    // Check methods
    // you can open a Web page and then Inspect the page element.
    protected void Page_Load(object sender, EventArgs e)
    {
      Page.Header.Title = "Dynamically titled page";

      //  System.Web.UI.HtmlControls
      HtmlMeta metaDescription = new HtmlMeta();

      metaDescription.Content = "A great Website to lean .net";
      metaDescription.Name = "Description";

      // meta data labels

      HtmlMeta metaKeywords = new HtmlMeta();

      metaKeywords.Name = "keywords";
      metaKeywords.Content = ".NET, C#, ASP.NET";
      Page.Header.Controls.Add(metaKeywords);
    }
  }
}