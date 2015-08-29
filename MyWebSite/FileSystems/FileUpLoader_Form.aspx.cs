using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace MyWebSite.FileSystems
{
  public partial class FileUpLoader_Form : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void cmdUpload_OnClick(object sender, EventArgs e)
    {
      try
      {
        if (UpLoader.PostedFile.ContentLength > 1048576)
        {
          // it has exceeds the size which are allowed.
          lblStatus.Text = "Too large, this file is not allowed.";
        }
        else
        {
          string destDir = Server.MapPath("./Upload");
          string fileName = Path.GetFileName(UpLoader.PostedFile.FileName);
          string destPath = Path.Combine(destDir, fileName);

          // you can use SaveAs to directly save the file back disk
          //
          // UpLoader.PostedFile.SaveAs(destPath);
          ReadAndDisplayPostedFile();
          //lblStatus.Text = "Thanks for submitting your file.";
        }
      }
      catch (Exception err)
      {
        lblStatus.Text = err.Message;
      }
    }

    protected void ReadAndDisplayPostedFile()
    {
      StreamReader r = new StreamReader(UpLoader.PostedFile.InputStream);
      lblStatus.Text = r.ReadToEnd();
      r.Close();
    }
  }
}