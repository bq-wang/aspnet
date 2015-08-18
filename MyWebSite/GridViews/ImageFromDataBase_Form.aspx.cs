using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace MyWebSite.GridViews
{
  public partial class ImageFromDataBase_Form : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      //LoadAndResponseImage();
      //MoreEffecientLoadAndResponseBinaryImage();
    }

    /* Read once and write response with BinaryWrite.. */
    protected void LoadAndResponseImage()
    {
      string connectionString = WebConfigurationManager.ConnectionStrings["Pubs"].ConnectionString;
      SqlConnection con = new SqlConnection(connectionString);
      string SQL = "SELECT logo FROM pub_info WHERE pub_id='1389'";
      SqlCommand cmd = new SqlCommand(SQL, con);

      try
      {
        con.Open();
        SqlDataReader r = cmd.ExecuteReader();
        if (r.Read())
        {
          byte[] bytes = (byte[])r["logo"];
          // Response image type has to be set
          Response.ContentType = "image/gif";
          Response.BinaryWrite(bytes);
        }
        r.Close();
      }
      finally
      {
        con.Close();
      }
    }

    protected void MoreEffecientLoadAndResponseBinaryImage()
    {
      string connectionString = WebConfigurationManager.ConnectionStrings["Pubs"].ConnectionString;
      SqlConnection con = new SqlConnection(connectionString);
      string SQL = "SELECT logo FROM pub_info WHERE pub_id='1389'";
      SqlCommand cmd = new SqlCommand(SQL, con);

      try
      {
        con.Open();
        SqlDataReader r = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
        if (r.Read())
        {
          int bufferSize = 100;
          byte[] bytes = new byte[bufferSize];
          long bytesRead = 0;
          long readFrom = 0;

          // content type has to be specified.
          Response.ContentType = "image/gif";

          // 100 bytes per loop
          do
          {
            bytesRead = r.GetBytes(0, readFrom, bytes, 0, bufferSize);
            Response.BinaryWrite(bytes); ;
            readFrom += bufferSize;
          }
          while (bytesRead == bufferSize);

        }
        r.Close();
      }
      finally
      {
        con.Close();
      }
    }


  }
}