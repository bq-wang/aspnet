using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebSite.States
{
  /// <summary>
  /// this example compared to the Form1 - to demonstrate that you can save object (rather than simple string) into ViewStates.
  /// </summary>
  public partial class States_Form2 : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnSaveClick(object sender, EventArgs e)
    {
      Dictionary<string, string> textToSave = new Dictionary<string, string>();

      SaveAllText(Table1.Controls, textToSave, true);

      ViewState["ControlText"] = textToSave;
    }

    private void SaveAllText(ControlCollection controls, Dictionary<string, string> textToSave, bool saveNested)
    {
      foreach (Control control in controls)
      {
        // add the text into the dictionary
        if (control is TextBox)
        {
          textToSave.Add(control.ID, ((TextBox)control).Text);
        }

        if (control.Controls != null && saveNested)
        {
          SaveAllText(control.Controls, textToSave, saveNested);
        }
      }
    }

    private void RestoreAllText(ControlCollection controls, Dictionary<string, string> textToSave, bool saveNested)
    {
      foreach (Control control in controls)
      {
        if (control is TextBox)
        {
          if (textToSave.ContainsKey(control.ID) != null)
            ((TextBox)control).Text = textToSave[control.ID];
        }

        if (control.Controls != null && saveNested)
        {
          RestoreAllText(control.Controls,  textToSave, saveNested);
        }
      }
    }


    protected void btnRestoreClick(object sender, EventArgs e)
    {
      if (ViewState["ControlText"] != null)
      {
        Dictionary<string, string> textToSave = ViewState["ControlText"] as Dictionary<string, string>;
        if (textToSave != null)
        {
          RestoreAllText(Table1.Controls, textToSave, true);
        }
      }
    }

    protected void btnDisplayClick(object sender, EventArgs e)
    {
      if (ViewState["ControlText"] != null)
      {
        // get the dictionary 
        Dictionary<string, string> savedText = (Dictionary<string, string>)ViewState["ControlText"];

        lblResult.Text = "";
        foreach (KeyValuePair<string, string> item in savedText)
        {
          lblResult.Text += (string)item.Key + "=" + (string)item.Value + "<br />";
        }
      }
    }
  }
}