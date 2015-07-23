using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebSite.States
{
  public partial class States_Form : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnSaveClick(object sender, EventArgs e)
    {
      SaveAllText(Table1.Controls, true);
    }

    private void SaveAllText(ControlCollection controls,  bool saveNested)
    {
      foreach (Control control in controls)
      {
        // add the text into the dictionary
        if (control is TextBox)
        {
          ViewState[control.ID] = ((TextBox)control).Text;
        }

        if (control.Controls != null && saveNested)
        {
          SaveAllText(control.Controls, saveNested);
        }
      }
    }

    private void RestoreAllText(ControlCollection controls, bool saveNested)
    {
      foreach (Control control in controls)
      {
        if (control is TextBox)
        {
          if (ViewState[control.ID] != null)
            ((TextBox)control).Text = (string)ViewState[control.ID];
        }

        if (control.Controls != null && saveNested)
        {
          RestoreAllText(control.Controls, saveNested);
        }
      }

    }


    protected void btnRestoreClick(object sender, EventArgs e)
    {
      RestoreAllText(Table1.Controls, true);
    }
  }
}