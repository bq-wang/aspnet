using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebSite.DataBindings
{
  public partial class Binding_UpdateValue_Form : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    // for stored procedure updating, we do parameter transforming
    protected void sourceEmployees3_Updating(object sender, SqlDataSourceCommandEventArgs e)
    {
      e.Command.Parameters["@First"].Value = e.Command.Parameters["@FirstName"].Value;
      e.Command.Parameters["@Last"].Value = e.Command.Parameters["@LastName"].Value;
      e.Command.Parameters.Remove(e.Command.Parameters["@FirstName"]);
      e.Command.Parameters.Remove(e.Command.Parameters["@LastName"]);

      // and we need to remove the extra 'City' which is filled automatically by the GridView binding
      e.Command.Parameters.Remove(e.Command.Parameters["@City"]);
    }
  }
}