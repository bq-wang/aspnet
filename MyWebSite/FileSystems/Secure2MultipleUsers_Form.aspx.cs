using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;

namespace MyWebSite.FileSystems
{
  public partial class Secure2MultipleUsers_Form : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack)
      {
        Log("Page loaded for the first time.");
      }
      else
      {
        Log("Page Posted back.");
      }
    }

    private void Log(string message)
    {
      FileMode mode;
      if (ViewState["LogFile"] == null)
      {
        ViewState["LogFile"] = GetFileName();
        mode = FileMode.Create;
      }
      else
      {
        // Append to existing file
        mode = FileMode.Append;
      }

      string fileName = (string)ViewState["LogFile"];
      using (FileStream fs = new FileStream(fileName, mode))
      {
        StreamWriter w = new StreamWriter(fs);
        w.WriteLine(DateTime.Now);
        w.WriteLine(message);
        w.WriteLine();
        w.Close();
      }
    }

    protected string GetFileName()
    {
      string fileName = "User." + Guid.NewGuid().ToString();
      return Path.Combine(Request.PhysicalApplicationPath, fileName);
    }

    protected void cmdRead_Click(object sender, EventArgs e)
    {
      if (ViewState["LogFile"] != null)
      {
        StringBuilder log = new StringBuilder();

        // get the files to add html line breaker line by line
        string fileName = (string)ViewState["LogFile"];
        using (FileStream fs = new FileStream(fileName, FileMode.Open))
        {
          StreamReader r = new StreamReader(fs);
          string line;
          do{
            line = r.ReadLine();
            if (line != null)
            {
              log.Append(line + "<br />");
            }
          } while (line != null);
          r.Close();
        }

         lblInfo.Text = log.ToString();
        
      }
      else
      {
        lblInfo.Text = "There is no log file.";
      }
    }

    protected void cmdDelete_Click(object sender, EventArgs e)
    {
      if (ViewState["LogFile"] != null)
      {
        File.Delete((string)ViewState["LogFile"]);
        ViewState["LogFile"] = null;
      }
    }
  }
}