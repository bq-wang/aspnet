using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebSite.States
{
  public partial class SessionState_Form : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      // the Application.Lock prevent multiple instances corrupted the data
      Application.Lock();


      int count = 0;
      if (Application["HitCounterForOrderPage"] != null)
      {
        count = (int)Application["HitCounterForOrderPage"];
      }

      count++;
      Application["HitCounterForOrderPage"] = count;

      Application.UnLock();
      lblInfo.Text = count.ToString();
    }
  }
}