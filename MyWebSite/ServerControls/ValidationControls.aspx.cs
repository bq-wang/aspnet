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
      if (!IsPostBack)
      {
        Options_Changed(this, EventArgs.Empty);
      }
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

    protected void Options_Changed(object sender, System.EventArgs e)
    {
      // check all validator
      foreach (BaseValidator validator in Page.Validators)
      {
        // enable/disable validator depends on the chkEnableValidators
        validator.Enabled = chkEnableValidators.Checked;

        // client side validator , depends on chkEnableClientSide
        validator.EnableClientScript = chkEnableValidators.Checked;
      }

      // based on the last two check boxes
      Summary.ShowMessageBox = chkShowMsgBox.Checked;
      Summary.ShowSummary = chkShowSummary.Checked;
    }
    protected void cmdOK_Click(object sender, EventArgs e)
    {
      // validate
      this.Validate();

      if (!this.IsValid)
      {
        string errorMessage = "<b>Mistakes found: </b><br />";
        // 
        TextBox ctrlInput;
        foreach (BaseValidator ctrl in this.Validators)
        {
          if (!ctrl.IsValid)
          {
            errorMessage += ctrl.ErrorMessage + "<br />";
            ctrlInput = (TextBox)this.FindControl(ctrl.ControlToValidate);
            errorMessage += " * Problem is with this input: ";
            errorMessage += ctrlInput.Text + "<br />";
          }
        }

        lblMessage.Text = errorMessage;
      }
    }
  }
}