using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Messaging;
using System.Threading;

// we need to add the reference to the System.Messaging.dll
namespace MyWebSite.Cache
{
  public class MessageQueueCacheDependency : CacheDependency
  {
    private MessageQueue queue;

    public MessageQueueCacheDependency(string queueName)
    {
      queue = new MessageQueue(queueName);

      // on another thread
      WaitCallback callback = new WaitCallback(WaitForMessage);

      ThreadPool.QueueUserWorkItem(callback);
    }

    public void WaitForMessage(object state)
    {
      // check the resource 

      /*
      Message msg = null;
      while (true)
      {
        msg = queue.Receive();
        if (!string.IsNullOrEmpty(msg.Label))
        {
          break;
        }
      }
      */
      Message msg = queue.Receive();
      // block until the message sent to the queue 
      base.NotifyDependencyChanged(this, EventArgs.Empty);
    }

  }
}