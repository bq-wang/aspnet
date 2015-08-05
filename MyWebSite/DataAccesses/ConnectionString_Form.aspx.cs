using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient; // to use the Connection string 
using System.Web.Configuration; // to use WebConfiguationManager

namespace MyWebSite.DataAccesses
{
  public partial class ConnectionString_Form : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack)
      {
        TestConnectionString();
      }
    }

    protected void TestConnectionString()
    {
      string connectionString = WebConfigurationManager.ConnectionStrings["NorthWind"].ConnectionString;

      SqlConnection con = new SqlConnection(connectionString);

      try
      {
        con.Open();
        lblInfo.Text = "<b> Server version: </b> " + con.ServerVersion;
        lblInfo.Text = "<br /> <b> Connection is:</b> " + con.State.ToString();
      }
      catch (Exception err)
      {
        // display information to handle process
        lblInfo.Text = "Error reading the database. " + err.Message;
      }
      finally
      {
        // no matter which way to ensure that the connectionis closed properly
        con.Close();
        lblInfo.Text += "<br /><b>Now connnection is : </b> " + con.State.ToString();
      }

    }
  }
}