using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Configuration;

namespace MyWebSite.GridViews
{
  public class ImageFromDB : IHttpHandler
  {
    public void ProcessRequest(HttpContext context)
    {
      string connectionString = WebConfigurationManager.ConnectionStrings["Pubs"].ConnectionString;

      string id = context.Request.QueryString["id"];
      if (id == null) throw new ApplicationException("Must specify ID");


      SqlConnection con = new SqlConnection(connectionString);
      string SQL = "SELECT logo FROM pub_info WHERE pub_id=@ID";
      SqlCommand cmd = new SqlCommand(SQL, con);
      cmd.Parameters.AddWithValue("@ID", id);


      try
      {
        con.Open();
        SqlDataReader r = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
        context.Response.ContentType = "image";
        if (r.Read())
        {
          int bufferSize = 100;
          byte[] bytes = new byte[bufferSize];
          long bytesRead;
          long readFrom = 0;

          do
          {
            bytesRead = r.GetBytes(0, readFrom, bytes, 0, bufferSize);
            context.Response.BinaryWrite(bytes);
            readFrom += bufferSize;
          } while (bytesRead == bufferSize);

        }
        r.Close();
      }
      finally
      {
        con.Close();
      }
    }

    public bool IsReusable { get { return true; } }
  }
}