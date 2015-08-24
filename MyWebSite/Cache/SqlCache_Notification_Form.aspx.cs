using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.Caching;

namespace MyWebSite.Cache
{
  public partial class SqlCache_Notification_Form : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack)
      {
        // here to get data from database
        string connectionString = WebConfigurationManager.ConnectionStrings["NorthWind"].ConnectionString;

        SqlConnection con = new SqlConnection(connectionString);
        string sql = "SELECT EmployeeID, FirstName, LastName, City FROM dbo.Employees";
        SqlCommand cmd = new SqlCommand(sql, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);

        try
        {
          // fill two data sets
          DataSet ds = new DataSet();
          da.Fill(ds, "Employees");

          SqlCacheDependency empDependency = new SqlCacheDependency(cmd);
          Cache.Insert("Employees", ds, empDependency);

        }
        finally
        {
        }

      }
    }
  }
}