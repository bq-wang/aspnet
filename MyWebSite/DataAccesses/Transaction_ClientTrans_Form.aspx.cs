using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace MyWebSite.DataAccesses
{
  public partial class Transaction_ClientTrans_Form : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void cmdTransactionClick(object sender, EventArgs e)
    {
      string connectionString = WebConfigurationManager.ConnectionStrings["NorthWind"].ConnectionString;
      SqlConnection con = new SqlConnection(connectionString);

      SqlCommand cmd1 = new SqlCommand("INSERT INTO Employees (LastName, FirstName) VALUES ('Joe', 'Tester')", con);
      SqlCommand cmd2 = new SqlCommand("INSERT INTO Employees (LastName, FirstName) VALUES ('Harry', 'Sullivan')", con);
      SqlTransaction tran = null;

      try
      {
        // open connection and create transaction 
        con.Open();

        // begin transaction 
        tran = con.BeginTransaction();

        // add transaction with two commands 
        cmd1.Transaction = tran;
        cmd2.Transaction = tran;

        // execute the two commands
        cmd1.ExecuteNonQuery();
        cmd2.ExecuteNonQuery();

        // commit the change 
        tran.Commit();

        HtmlContent.Text = "Transaction is done!";
      }
      catch (Exception ex)
      {
        tran.Rollback();
       
        HtmlContent.Text = "Transaction is aborted";

        HtmlContent.Text += "<br />";

        HtmlContent.Text += ex.ToString();
      }
      finally
      {
        con.Close();
      }
    }

    protected void cmdTransactionRemoveClick(object sender, EventArgs e)
    {
      string connectionString = WebConfigurationManager.ConnectionStrings["NorthWind"].ConnectionString;
      SqlConnection con = new SqlConnection(connectionString);

      SqlCommand cmd1 = new SqlCommand("DELETE FROM Employees WHERE LastName = 'Joe' AND FirstName = 'Tester'", con);
      SqlCommand cmd2 = new SqlCommand("DELETE FROM Employees WHERE LastName = 'Harry' AND FirstName = 'Sullivan'", con);
      SqlTransaction tran = null;

      try
      {
        // open connection and create transaction 
        con.Open();

        // begin transaction 
        tran = con.BeginTransaction();

        // add transaction with two commands 
        cmd1.Transaction = tran;
        cmd2.Transaction = tran;

        // execute the two commands
        cmd1.ExecuteNonQuery();
        cmd2.ExecuteNonQuery();

        // commit the change 
        tran.Commit();

        HtmlContent.Text = "Transaction (remove) is done!";
      }
      catch
      {
        tran.Rollback();
        HtmlContent.Text = "Transaction (remove) is aborted";
      }
      finally
      {
        con.Close();
      }
    }

  }
}