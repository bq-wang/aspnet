using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebSite.ServerControls
{
  public partial class WebForm_HtmlInputStyles : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      // only initialize on first request

      if (!Page.IsPostBack)
      {
        // setting the styles settings 
        Text1.Style["font-size"] = "20px";
        Text1.Style["color"] = "red";


        // a slightly different but equivalent methods 
        Text1.Style.Add("background-color", "lightyellow");

        Text1.Value = "<Enter e-mail address here >";

        Text1.Attributes["onfocus"] = "alert(Text1.value)";
        
      }
    }
  }
}