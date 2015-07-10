using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebSite.WebForms
{
  public partial class DynamicControls : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      Button newButton = new Button();

      newButton.Text = "* Dynamic Button *";

      newButton.ID = "newButton";

      Panel1.Controls.Add(newButton);
      newButton.Click += dynamicButton_Click;
    }


    protected void cmdRemove_Click(object sender, EventArgs e)
    {
      // find control 

      Button foundButton = (Button)Page.FindControl("newButton");

      if (foundButton != null)
      {
        foundButton.Parent.Controls.Remove(foundButton);
      }
    }

    private void dynamicButton_Click(object sender, EventArgs e)
    {
      Label1.Text = "you clicked on the dynamic button";
    }
  }
}