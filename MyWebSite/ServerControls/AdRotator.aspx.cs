using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebSite.ServerControls
{
  public partial class AdRotator : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void Ads_AdCreated(object sender, AdCreatedEventArgs e)
    {

      // sync the hyperlink control
      lnkBanner.NavigateUrl = e.NavigateUrl;

      // sync text from the hyperlink text
      lnkBanner.Text = "Click here for information about our sponsor";
      lnkBanner.Text += e.AlternateText;
    }
  }
}