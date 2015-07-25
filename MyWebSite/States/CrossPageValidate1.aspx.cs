using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebSite.States
{
  public partial class CrossPageValidate1 : System.Web.UI.Page
  {
    // in this page
    // we will try to do cehck the IsValidate to see if the page "CrossPage" is valid 
    // the key here is to use the Query["err"] to check if the error flag is set 
    // the problem that we observed is that since the validator are enabled and it will take effect before cross page to CrossPageValidate2.aspx
    // so it is not possible to witeness the redirect back to the orignal page to do validate again.
    protected void Page_Load(object sender, EventArgs e)
    {
      if (Request.QueryString["err"] != null)
      {
        Page.Validate();
      }
    }

    // note that the Server transfer can directly cross page post back through PostBackUrl, while it is possible that to do 
    // manuall explicit server.Transfer
    protected void cmdTransferClick(object sender, EventArgs e)
    {
      Server.Transfer("~/States/CrossPageValidate2.aspx");
    }
  }
}