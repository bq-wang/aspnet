using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace MyWebSite.Cache
{
  public partial class DataCache_TimerTestCache_Form : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack)
      {
        var item = "TestString";
        TimerTestCacheDependency dependency = new TimerTestCacheDependency();
        Cache.Insert("MyItem", item, dependency);
      }
    }
    protected void cmdCheckitems_OnClick(object sender, EventArgs e)
    {
      string itemList = "";
      foreach (DictionaryEntry item in Cache)
      {
        itemList += item.Key.ToString() + " ";
      }
      lblInfo.Text += "<br />Found: " + itemList + "<br />";
    }
  }
}