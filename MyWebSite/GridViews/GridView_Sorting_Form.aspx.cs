using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebSite.GridViews
{
  public partial class GridView_Sorting_Form : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void gridEmployees_Sorting(object sender, GridViewSortEventArgs e)
    {
      if (e.SortExpression == "FirstName" && sourceEmployeesSortedGridView.SortExpression == "LastName")
      {
        e.SortExpression = "LastName, FirstName";
      }
    }

    protected void sortingLists_SelectedIndexChanged(object sender, EventArgs e)
    {
       sourceEmployeesSortedGridView.Sort(sortingLists.SelectedValue, SortDirection.Ascending);
    }
  }
}