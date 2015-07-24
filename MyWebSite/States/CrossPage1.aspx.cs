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
      // Page.IsPostBack is a very important feature that can affects the performance. 
      // in case of cross-page postback, if target page acccessed 'PreviousPage ', the life cycle of source page (current page)/
      // wil be executed. 
      // you shoudl check 
      //    IsCrossPagePostBack 
      //    IsPostBack 
      // in order to avoid cost operations

      if (IsCrossPagePostBack)
      {
        // triggered one post back to another page
        lblInfo.Text = "cross page post back";
      }
      else if (IsPostBack)
      {
        // normal post back 
        // do not execute INITIALIZE
        lblInfo.Text = "nomral post back"; 
      }
      else
      {
        // first visit (requested)
        // do initializing properly 
        lblInfo.Text = "proper initialize";
      }
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

    // note that the Server transfer can directly cross page post back through PostBackUrl, while it is possible that to do 
    // manuall explicit server.Transfer
    protected void cmdTransferClick(object sender, EventArgs e)
    {
      Server.Transfer("~/States/CrossPage2.aspx");
    }
  }
}