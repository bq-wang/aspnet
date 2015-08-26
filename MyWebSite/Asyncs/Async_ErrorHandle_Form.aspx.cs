using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;
namespace MyWebSite.Asyncs
{
  public partial class Async_ErrorHandle_Form : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      Page.AddOnPreRenderCompleteAsync(BeginTask, EndTask);
    }

    private SqlConnection con;
    private SqlCommand cmd;
    private SqlDataReader reader;
    private bool _initialized;
    private IAsyncResult BeginTask(object sender, EventArgs e, AsyncCallback cb, object state)
    {
      string connectionString = WebConfigurationManager.ConnectionStrings["NorthWind"].ConnectionString;
      con = new SqlConnection(connectionString);
      cmd = new SqlCommand("SELECT * FROM Employees", con);
      con.Open();
      return cmd.BeginExecuteReader(cb, state);
    }

    private void EndTask(IAsyncResult ar)
    {
      // well it is GOOD that you capture the event, it is NOT GOOD that you can do about it
      try
      {
        reader = cmd.EndExecuteReader(ar);
        grid.DataSource = reader;
        grid.DataBind();
        con.Close();
      }
      catch (SqlException err)
      {
        lblError.Text = "The query failed";
      }
    }
  }
}