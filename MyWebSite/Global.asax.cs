using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.IO;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace MyWebSite
{
  public class Global : System.Web.HttpApplication
  {
    // another way to do session is static data (variable)
    // to use the Global.asax
    // 
    /*
    private static string[] fileList;
    public static string[] FileList
    {
      get
      { return fileList; }
    }
    */


    private static string[] fileList;
    public static string[] FileList
    {
      get
      {
        if (fileList == null)
        {
          fileList = Directory.GetFiles(
              HttpContext.Current.Request.PhysicalApplicationPath);
        }

        return fileList;
      }
    }
    private static Dictionary<string, string> metadata = new Dictionary<string, string>();

    public void AddGetMetadata(string key, string value)
    {
      lock (metadata)
      {
        metadata[key] = value;
      }
    }

    public string GetMetadata(string key)
    {
      lock (metadata)
      {
        return metadata[key];
      }
    }

    void Application_Start(object sender, EventArgs e)
    {
      // 在应用程序启动时运行的代码

      string connectionString = WebConfigurationManager.ConnectionStrings["NorthWind"].ConnectionString;
      SqlDependency.Start(connectionString);

    }

    void Application_End(object sender, EventArgs e)
    {
      //  在应用程序关闭时运行的代码
      string connectionString = WebConfigurationManager.ConnectionStrings["NorthWind"].ConnectionString;
      SqlDependency.Stop(connectionString);
    }

    void Application_Error(object sender, EventArgs e)
    {
      // 在出现未处理的错误时运行的代码

    }

    void Session_Start(object sender, EventArgs e)
    {
      // 在新会话启动时运行的代码

    }

    void Session_End(object sender, EventArgs e)
    {
      // 在会话结束时运行的代码。 
      // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
      // InProc 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer 
      // 或 SQLServer，则不会引发该事件。

    }

  }
}
