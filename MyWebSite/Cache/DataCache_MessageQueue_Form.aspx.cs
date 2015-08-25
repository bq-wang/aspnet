using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Messaging;
using System.Collections;

namespace MyWebSite.Cache
{
  public partial class DataCache_MessageQueue_Form : System.Web.UI.Page
  {
    // to use the windows message queue, you will need to install the windows message queue feature, 
    // you can turn this on by 
    // program, window features then find Window Message queue and expand to tick Window Message queeu core.
    //
    // seems that @".\Private$\TEstQueue" has been used somewhere.
    //
    private string queueName = @".\Private$\TestQueue1";

    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack)
      {
        MessageQueue queue;

        if (MessageQueue.Exists(queueName))
        {
          queue = new MessageQueue(queueName);
        }
        else
        {
          queue = MessageQueue.Create(queueName);
        }

        lblInfo.Text += "Create dependencies item...<br />";
        Cache.Remove("Item");
        MessageQueueCacheDependency  dependency = new MessageQueueCacheDependency(queueName);
        string item = "Dependent cached item";
        lblInfo.Text += "Adding dependent item<br />";
        Cache.Insert("Item", item, dependency);
      }
    }

    protected void cmdModify_OnClick(object sender, EventArgs e)
    {
      MessageQueue queue = new MessageQueue(queueName);
      // you can send not only a string ,but also a custom object
      queue.Send("Invalidated!");
      lblInfo.Text += "Message Sent<br />";
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