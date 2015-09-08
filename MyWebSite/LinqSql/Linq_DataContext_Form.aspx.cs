using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace MyWebSite.LinqSql
{
  public partial class Linq_DataContext_Form : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack)
      {
        LinqNorthwindDB db = new LinqNorthwindDB();
        gridEmployees.DataSource = db.GetEmployees();

        try
        {
          // here to do the data binding 
          gridEmployees.DataBind();
        }
        catch (SqlException err)
        {
        }
        catch (InvalidOperationException err)
        {
        }
      }
    }
  }
}