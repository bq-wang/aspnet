using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebSite.ServerControls
{
  public partial class ValidationGroup : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void cmdValidateAll_Click(object sender, EventArgs e)
    {
      Label1.Text = "Initial Page.IsValid State: " + Page.IsValid.ToString();

      Page.Validate("Group1");

      Label1.Text += "<br />Group1 valid: " + Page.IsValid.ToString();

      Page.Validate("Group2");

      Label1.Text += "<br />Group and Group2 valid: " + Page.IsValid.ToString();

    }

  }
}