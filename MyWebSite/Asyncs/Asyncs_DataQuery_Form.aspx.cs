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
  public partial class Asyncs_DataQuery_Form : System.Web.UI.Page
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
      reader = cmd.EndExecuteReader(ar);
    }

    protected void Page_PreRenderComplete(object sender, EventArgs e)
    {
      // NOT SURE WHY WE NEED TO GUARD AGAINT SECOND TIME INITIALIZATION
      if (!_initialized)
      {
        _initialized = true;
        grid.DataSource = reader;
        grid.DataBind();
        con.Close();
      }
    }
    public override void Dispose()
    {
      if (con != null) con.Close();
      base.Dispose();
    }
  }
}