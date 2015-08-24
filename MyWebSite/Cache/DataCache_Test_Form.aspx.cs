using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace MyWebSite.Cache
{
  public partial class DataCache_Test_Form : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      // 
      if (this.IsPostBack)
      {
        lblInfo.Text += "Page posted back.<br />";
      }
      else
      {
        lblInfo.Text += "Page Created.<br />";
      }

      DateTime? testItem = (DateTime?)Cache["TestItem"];
      if (testItem == null)
      {
        lblInfo.Text += "Creating TestItem...<br/>";
        testItem = DateTime.Now;
        lblInfo.Text += "Storing TestItem in Cache";
        lblInfo.Text += "For 30 seconds.<br />";
        Cache.Insert("TestItem", testItem, null, DateTime.Now.AddSeconds(30), TimeSpan.Zero);
      }
      else
      {
        lblInfo.Text += "Retrieving TestItem ..<br />";
        lblInfo.Text += "Test item is : '" + testItem.ToString();
        lblInfo.Text += "'<br />";
      }

      lblInfo.Text += "<br />";
    }


    // well, the code below shows a real-case application on how to Get Customer data and how to use that in Cache
    private DataSet GetCustomerData()
    {
      DataSet ds = Cache["CustomerData"] as DataSet;

      if (ds == null)
      {
        ds = QueryCustomerDataFromDataBase();
        Cache.Insert("CustomerData", ds);
        // well there is overrides which you can specify expiration
        //Cache.Insert("CUstomerData", ds, null, DateTime.Now.AddMinutes(60), TimeSpan.Zero);
      }

      return ds;
    }

    private DataSet QueryCustomerDataFromDataBase()
    {
      // here to get data from database
      string connectionString = WebConfigurationManager.ConnectionStrings["NorthWind"].ConnectionString;

      SqlConnection con = new SqlConnection(connectionString);

      string sql = "SELECT * FROM Customers";

      SqlDataAdapter da = new SqlDataAdapter(sql, con);

      DataSet ds = new DataSet();

      try
      {
        con.Open();
        // fill two data sets
        da.Fill(ds, "Customers");
      }
      finally
      {
        con.Close();
      }

      return ds;

    }
  }
}