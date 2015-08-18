using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebSite.Cache
{
  public partial class Declarative_Ouptut_Cache_Form : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      lblDate.Text = "The time isnow:<br />";
      lblDate.Text += DateTime.Now.ToString();
    }
  }
}