using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebSite.DataBindings
{
  public partial class ObjectDataSource_Binding_Form : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void sourceEmployee_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
      if (e.InputParameters["EmployeeID"] == null) e.Cancel = true;
    }
  }
}