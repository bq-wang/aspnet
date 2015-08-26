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
  public partial class Async_DataCache_Form : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      Page.AddOnPreRenderCompleteAsync(BeginTask, EndTask);
      if (!Page.IsPostBack)
      {
        Page.PreRenderComplete += Page_PreRenderComplete;
      }
    }

    private SqlConnection con;
    private SqlCommand cmd;
    private SqlDataReader reader;
    private bool _initialized;
    private DataTable table;
    private IAsyncResult BeginTask(object sender, EventArgs e, AsyncCallback cb, object state)
    {
      string connectionString = WebConfigurationManager.ConnectionStrings["NorthWind"].ConnectionString;
      con = new SqlConnection(connectionString);
      cmd = new SqlCommand("SELECT * FROM Employees", con);

      try
      {

        con.Open();
      }
      catch (Exception ex)
      {
        return new CompletedSyncResult(ex, cb, state);
      }
      return cmd.BeginExecuteReader(cb, state);
    }

    private void EndTask(IAsyncResult ar)
    {
      // Fist we handle the BeginTask error 
      CompletedResultSyncResult completedSync = ar as CompletedResultSyncResult;
      if (completedSync != null)
      {
        try
        {
          table = completedSync.Result;
          lblError.Text = "Completed with data from the cache";
          lblError.Text += ((CompletedSyncResult)ar).OperationException.Message;
          return;
        }
        catch (Exception ex)
        {
          lblError.Text = "A connection error occured.";
        }
      }
      else
      {
        // well it is GOOD that you capture the event, it is NOT GOOD that you can do about it
        try
        {
          reader = cmd.EndExecuteReader(ar);
          table = new DataTable("Employees");
          table.Load(reader);
          Cache.Insert("Employees", table, null, DateTime.Now.AddMinutes(5), TimeSpan.Zero);

        }
        catch (SqlException err)
        {
          lblError.Text = "The query failed";
        }
      }
    }

    private void Page_PreRenderComplete(object sender, EventArgs e)
    {
      if (!_initialized)
      {
        _initialized = true;
        grid.DataSource = table;
        grid.DataBind();
      }
    }
  }
}