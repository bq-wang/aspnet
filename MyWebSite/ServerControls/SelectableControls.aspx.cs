using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebSite.ServerControls
{
  public partial class SelectableControls : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {

        for (int i = 3; i <= 5; i++)
        {
          Listbox1.Items.Add("Option " + i.ToString());
          DropdownList1.Items.Add("Option " + i.ToString());
          CheckboxList1.Items.Add("Option " + i.ToString());
          RadioButtonList1.Items.Add("Option " + i.ToString());
        }
      }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
      Response.Write("<b>Selected items for Listbox1:</b><br />");
      foreach (ListItem li in Listbox1.Items)
      {
        if (li.Selected) Response.Write("- " + li.Text + "<br />");
      }

      Response.Write("<b>Selected items for DropdownList1:</b><br />");
      Response.Write("- " + DropdownList1.SelectedItem.Text + "<br />");

      Response.Write("<b>Selected items for CheckboxList1:</b><br />");
      foreach (ListItem li in CheckboxList1.Items)
      {
        if (li.Selected) Response.Write("- " + li.Text + "<br />");
      }

      Response.Write("<b>Selected items for RadioButtonList:</b><br />");
      Response.Write("- " + RadioButtonList1.SelectedItem.Text + "<br />");
    }
  }
}