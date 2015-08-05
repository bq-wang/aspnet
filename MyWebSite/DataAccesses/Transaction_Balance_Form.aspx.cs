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
  public partial class Transaction_Balance_Form : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void cmdTransferClick(object sender, EventArgs e)
    {
      string connectionString = WebConfigurationManager.ConnectionStrings["Bank"].ConnectionString;

      SqlConnection con = new SqlConnection(connectionString);

      try
      {
        con.Open();
        SqlCommand cmd = new SqlCommand("TransferAmount", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Money, 8));
        cmd.Parameters.Add(new SqlParameter("@ID_A", SqlDbType.Int, 4));
        cmd.Parameters.Add(new SqlParameter("@ID_B", SqlDbType.Int, 4));

        cmd.Parameters["@ID_A"].Value = "001";
        cmd.Parameters["@ID_B"].Value = "002";
        cmd.Parameters["@Amount"].Value = (Decimal)decimal.Parse(money.Text);
        int numAff = cmd.ExecuteNonQuery();

        HtmlContent.Text = "Done transfer!";

      }
      catch (Exception ex)
      {
        HtmlContent.Text = string.Format("Error in transfer, message = {0}", ex);
      }
      finally
      {
        con.Close();
      }


    }
  }
}