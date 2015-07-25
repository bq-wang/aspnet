using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebSite.States
{
	public partial class CrossPageValidate2 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
      // the following skeleton shows one way to handle verify validity 
      /*
      // check previous page validity
      if (PreviousPage != null)
      {
        if (!PreviousPage.IsValid)
        {
          // display an error or doing nothing.
        }
        else
        {s
          // ...
        }
      }
      */

      // or simply you can redirect back to original page
      if (!PreviousPage.IsValid)
      {
        Response.Redirect(Request.UrlReferrer.AbsolutePath + "?err=true");
      }
		}
	}
}