using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;

namespace MyWebSite.FileSystems
{
  public partial class Serializer_Formatter_Form : System.Web.UI.Page
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
          // what is different from the Secure2MultipleUsers_Form is 1. create LogEntry object, and serialize with Fromatter
        LogEntry entry = new LogEntry(message);

        // Create Formatter
        BinaryFormatter formatter = new BinaryFormatter();

        // serialize the object to file
        formatter.Serialize(fs, entry);
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

        // what is different from Secure2MultipleUsers_Form is 1. use BinaryFormatter to deserialize the files 

        // the key here is to deserialize the object out of the file object by object.
        //
        string fileName = (string)ViewState["LogFile"];
        using (FileStream fs = new FileStream(fileName, FileMode.Open))
        {

          // Create Formatter 
          BinaryFormatter formatter = new BinaryFormatter();

          // get deserialized object
          while (fs.Position < fs.Length)
          {
            // get file the deserialized object 
            LogEntry entry = (LogEntry)formatter.Deserialize(fs);

            // display its information 
            log.Append(entry.Date.ToString());
            log.Append("<br />");
            log.Append(entry.Message);
            log.Append("<br /><br />");
          }
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