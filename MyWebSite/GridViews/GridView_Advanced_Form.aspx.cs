using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebSite.GridViews
{
  public partial class GridView_Advanced_Form : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void gridSummary_DataBound(object sender, EventArgs e)
    {
      decimal valueInStock = 0;
      foreach (GridViewRow row in gridSummary.Rows)
      {
        decimal price = decimal.Parse(row.Cells[2].Text); // how do you know that cells[2] is price, cells[3] is unitsInStock
        int unitsInStock = int.Parse(row.Cells[3].Text);
        valueInStock += price * unitsInStock;
      }

      // to update the Footer
      GridViewRow footer = gridSummary.FooterRow;

      // first cell to span all the row
      footer.Cells[0].ColumnSpan = 3;
      footer.Cells[0].HorizontalAlign = HorizontalAlign.Center;

      // delete unnecessary cells
      footer.Cells.RemoveAt(2);
      footer.Cells.RemoveAt(1); // think why we delete backwards
      // add the text 
      footer.Cells[0].Text = "Total value in stock (On the page): " + valueInStock.ToString("C");
    }

    protected void gridMaster_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
      // find the data source
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        // get the GridView control
        GridView gridChild = (GridView)e.Row.Cells[1].Controls[1];

        // set teh category ID to find the products belongs to that category
        string catID = gridMaster.DataKeys[e.Row.DataItemIndex].Value.ToString();
        sourceProducts2.SelectParameters[0].DefaultValue = catID;

        // fetch data from the data object
        object data = sourceProducts2.Select(DataSourceSelectArguments.Empty);

        // bind the data
        gridChild.DataSource = data;
        gridChild.DataBind();
      }
    }
  }
}