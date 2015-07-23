using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebSite.Applications
{
  public partial class ImageGuardHandler_Form : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void btnRedirectToImageClick(object sender, EventArgs e)
    {
      var image = txtImage.Text;
      if (!string.IsNullOrEmpty(image))
      {
        //Response.Redirect("Images/Programs.gif");
        Response.Redirect(image);
      }
    }
  }
}