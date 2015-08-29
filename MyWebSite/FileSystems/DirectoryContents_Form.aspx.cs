using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Diagnostics;
using System.Collections;

namespace MyWebSite.FileSystems
{
  public partial class DirectoryContents_Form : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack)
      {
        ShowDirectoryContents(Server.MapPath("."));
      }
    }

    protected void ShowDirectoryContents(string path)
    {
      // Define the current directory 
      DirectoryInfo dir = new DirectoryInfo(path);

      // get current directory and files
      FileInfo[] files = dir.GetFiles();
      DirectoryInfo[] dirs = dir.GetDirectories();


      lblCurrentDir.Text = "Currently showing " + path;

      gridFileList.DataSource = files;
      gridDirList.DataSource = dirs;

      // show indicator
      Page.DataBind();

      gridFileList.SelectedIndex = -1;
      ViewState["CurrentPath"] = path;
    }

    protected string GetVersionInfoString(object path)
    {
      FileVersionInfo info = FileVersionInfo.GetVersionInfo((string)path);
      return info.FileName + " " + info.FileVersion + "br />" + info.ProductName + " " + info.ProductVersion;
    }

    protected void gridDirList_OnSelectedIndexChanged(object sender, EventArgs e)
    {
      // get selected directory 
      string dir = (string)gridDirList.DataKeys[gridDirList.SelectedIndex].Value;
      // Refresh the directory conents;
      ShowDirectoryContents(dir);
    }


    protected void gridFileList_OnSelectedIndexChanged(object sender, EventArgs e)
    {
      string file = (string)gridFileList.DataKeys[gridFileList.SelectedIndex].Value;
      ArrayList files = new ArrayList();

      files.Add(new FileInfo(file));

      formFileDetails.DataSource = files;
      formFileDetails.DataBind();
    }

    protected void cmdUp_Click(object sender, EventArgs e)
    {
      string path = (string)ViewState["CurrentPath"];
      path = Path.Combine(path, "..");
      path = Path.GetFullPath(path);
      ShowDirectoryContents(path);
    }
  }
}