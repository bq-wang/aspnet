using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebSite.GridViews
{
  public partial class GridView_Format_Form : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void gridEmployees_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        string title = (string)DataBinder.Eval(e.Row.DataItem, "TitleOfcourtesy");


        // if it is "Mr." or "Mrs." or "Ms." change it color 
        if (title == "Ms." || title == "Mrs.")
        {
          e.Row.BackColor = System.Drawing.Color.LightPink;
          e.Row.ForeColor = System.Drawing.Color.Maroon;
        }
        else if (title == "Mr.")
        {
          e.Row.BackColor = System.Drawing.Color.LightCyan;
          e.Row.ForeColor = System.Drawing.Color.DarkBlue;
        }
      }

      
    }

    protected void gridEmployees_SelectedIndexChanged(object sender, EventArgs e)
    {
      int index = gridEmployees.SelectedIndex;

      // get key fields get SelectedDateKeys
      int ID = (int)gridEmployees.SelectedDataKey.Values["EmployeeID"];

      // get others cells values by index
      string firstName = gridEmployees.SelectedRow.Cells[2].Text;
      string lastName = gridEmployees.SelectedRow.Cells[3].Text;

      lblRegionCaption.Text = "Regions that " + firstName + " " + lastName + " (employee " + ID.ToString() + " ) is reponsible for :";
    }

  }
}