using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebSite.States
{
  public partial class CrossPage1 : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    // FirstNameTextBox and LastNameText box which are not exposed (control memeber 
    public TextBox FirstNameTextBox
    {
      get { return txtFirstName; }
    }

    public TextBox LastNameTextBox
    {
      get { return txtLastName; }
    }

    // more reasonable way is to extract the necessary information (rather than expose the control )
    public string FullName
    {
      get { return txtFirstName.Text + " " + txtLastName.Text; }
    }
  }
}