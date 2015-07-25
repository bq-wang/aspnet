using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebSite.States
{
  public partial class SimpleCookie : System.Web.UI.Page
  {
    // you can find the location to the Chrome cookie location 
    // at %userprofile%\AppData\Local\Google\Chrome\User Data\Default
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void cmdSetCookieClick(object sender, EventArgs e)
    {
      SetCookie();

      lblInfo.Text = "Set cookie done";
    }

    protected void SetCookie()
    {
      HttpCookie cookie = new HttpCookie("Preferences");
      // set one of the values

      cookie["LanguagePref"] = "English";

      // add another value 
      cookie["Country"] = "US";

      // add the cookie back to the current web response

      Response.Cookies.Add(cookie);

      cookie.Expires = DateTime.Now.AddYears(1);
    }

    protected void cmdRemoveCookieClick(object sender, EventArgs e)
    {
      RemoveCookie();

      lblInfo.Text = "Cookie removed";
    }

    protected void RemoveCookie()
    {
      HttpCookie cookie = new HttpCookie("Preferences");
      cookie.Expires = DateTime.Now.AddDays(-1);
      Response.Cookies.Add(cookie);
    }


    protected void cmdShowCookieClick(object sender, EventArgs e)
    {
      ShowCookie();
    }

    protected void ShowCookie()
    {
      // find the cookie
      HttpCookie cookie = Request.Cookies["Preferences"];

      if (cookie != null)
      {
        string language = cookie["LanguagePref"];
        lblInfo.Text = language;
      }
      else
      {
        lblInfo.Text = "cookie not found";
      }

    }

  }
}