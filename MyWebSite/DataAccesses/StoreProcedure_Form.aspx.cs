using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace MyWebSite.DataAccesses
{
  public partial class StoreProcedure_Form : System.Web.UI.Page
  {
    // in this page we will show you how to use the store procedure to prevent the sql injection attach
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void cmdInsertEmployeeClick(object sender, EventArgs e)
    {
      string connectionString = WebConfigurationManager.ConnectionStrings["NorthWind"].ConnectionString;
      SqlConnection con = new SqlConnection(connectionString);

      try
      {
        con.Open();

        
        SqlCommand cmd = new SqlCommand("InsertEmployee", con);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@TitleOfCourtesy", SqlDbType.VarChar, 25));
        cmd.Parameters["@TitleOfCourtesy"].Value = title.Text;

        cmd.Parameters.Add(new SqlParameter("@LastName", SqlDbType.VarChar, 20));
        cmd.Parameters["@LastName"].Value = lastName.Text;


        cmd.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.VarChar, 10));
        cmd.Parameters["@FirstName"].Value = firstName.Text;


        cmd.Parameters.Add(new SqlParameter("@EmployeeID", SqlDbType.Int, 4));
        cmd.Parameters["@EmployeeID"].Direction = ParameterDirection.Output;

        int numAff = cmd.ExecuteNonQuery();
        HtmlContent.Text += string.Format("INserted <b> {0}</b> record(s) <br />", numAff);


        // get the new generated ID
        int empID = (int)cmd.Parameters["@EmployeeID"].Value;
        HtmlContent.Text += "New ID: " + empID.ToString();

      }
      finally
      {
        con.Close();
      }

    }
  }
}