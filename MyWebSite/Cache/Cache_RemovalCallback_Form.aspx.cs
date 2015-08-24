using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Caching;
using System.Collections;

namespace MyWebSite.Cache
{
  public partial class Cache_RemovalCallback_Form : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!this.IsPostBack)
      {
        lblInfo.Text += "Creating Items ... <br />";
        string itemA = "Item A";
        string itemB = "Item B";
        Cache.Insert("itemA", itemA, null, DateTime.Now.AddMinutes(60), TimeSpan.Zero, CacheItemPriority.Default, new System.Web.Caching.CacheItemRemovedCallback(ItemRemovedCallback));
        Cache.Insert("itemB", itemB, null, DateTime.Now.AddMinutes(60), TimeSpan.Zero, CacheItemPriority.Default, new System.Web.Caching.CacheItemRemovedCallback(ItemRemovedCallback));
      }
    }

    protected void cmdCheck_Click(object sender, EventArgs e)
    {
      string itemList = "";
      foreach (DictionaryEntry item in Cache)
      {
        itemList += item.Key.ToString() + " ";
      }
      lblInfo.Text += "<br />Found: " + itemList + "<br />";
    }

    protected void cmdRemove_Click(object sender, EventArgs e)
    {
      lblInfo.Text +=  "<br />Removing ItemA.<br />";
       Cache.Remove("itemA");
    }

    protected void ItemRemovedCallback(string key, object value, CacheItemRemovedReason reason)
    {
      if (key == "itemA" || key == "itemB")
      {
        Cache.Remove("itemA");
        Cache.Remove("itemB");
      }
    }
  }
}