using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace MyWebSite.Applications
{
  /// <summary>
  /// a simple Handler which server source file (html encode file)
  /// </summary>
  /// <remarks>
  /// you can visit the url with the following URL 
  /// 
  /// http://localhost:3413/Applications/source.simple?file=Quotation_Form.aspx.cs
  /// </remarks>
  public class SourceHandler : IHttpHandler
  {

    public void ProcessRequest(System.Web.HttpContext context)
    {
      HttpResponse response = context.Response;
      HttpRequest request = context.Request;
      HttpServerUtility server = context.Server;

      response.Write("<html><body>");

      string file = request.QueryString["file"];
      response.Write("file: <b>" + file + "</b>");

      try
      {
        response.Write("<b>Listing " + file + "</b><br />");
        StreamReader r = File.OpenText(server.MapPath(Path.Combine("./", file)));
        string line = "";
        while (line != null)
        {
          line = r.ReadLine();
          if (line != null)
          {
            line = server.HtmlEncode(line);
            line = line.Replace(" ", "&nbsp;");
            line = line.Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;");
            response.Write(line + "<br />");
          }
        }


        r.Close();
      }
      catch (Exception ex)
      {
        response.Write(ex.Message);
      }
    }

    public bool IsReusable
    {
      get { return true; }
    }
  }
}