using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebSite.ServerControls
{
  public partial class ValidationControls : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    // NOTE: it is not required to create a custom validator which inherits from the BaseValidator
    // remember to wire  it up with the OnServerValidate method
    protected void EmpIDServerValidate(object sender, ServerValidateEventArgs args)
    {
      try
      {
        args.IsValid = (int.Parse(args.Value) % 5 == 0);
      }
      catch
      {
        // non number figure may have an error
        args.IsValid = false;
      }
    }

    
  }
}