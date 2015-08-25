using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebSite.Cache
{
  public class TimerTestCacheDependency : System.Web.Caching.CacheDependency
  {
    private System.Threading.Timer timer;

    private int pollTime = 5000;

    public TimerTestCacheDependency()
    {
      timer = new System.Threading.Timer(new System.Threading.TimerCallback(CheckDependencyCallback),
        this,
        0,
        pollTime);
    }
    private int count;
    private void CheckDependencyCallback(object sender)
    {

      count++;
      if (count > 4)
      {
        base.NotifyDependencyChanged(this, EventArgs.Empty);
        timer.Dispose();
      }
    }
  }
}