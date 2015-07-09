using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebSite.WebForms
{
  public partial class Controls : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      DisplayControl(Page.Controls, 0);

      Response.Write("<hr />");
    }

    private void DisplayControl(ControlCollection controls, int depth)
    {
      foreach (Control control in controls)
      {
        Response.Write(new String('-', depth * 4) + "> ");

        // Display the control
        Response.Write(control.GetType().ToString() + " - <b>" + control.ID + "</b><br />");

        if (control.Controls != null)
        {
          DisplayControl(control.Controls, depth + 1);
        }
      }
    }
  }
}