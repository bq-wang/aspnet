using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.IO;

namespace MyWebSite.Applications
{
  public class ImageGuardHandler : IHttpHandler
  {
    public void ProcessRequest(System.Web.HttpContext context)
    {
      // the key here is check the referrer and the host to avoid cross-site link (which causes unnecessary burden to your web-browser)
      HttpResponse response = context.Response;
      HttpRequest request = context.Request;
      string imagePath = null;

      // check if the path is from the same host 
      if (request.UrlReferrer != null)
      {
        if (string.Compare(request.Url.Host, request.UrlReferrer.Host, true, CultureInfo.InvariantCulture) == 0)
        {
          // the request host is the right host 
          // satifsfy the request from the request
          imagePath = request.PhysicalPath;
          if (!File.Exists(imagePath))
          {
            response.Status = "Image Not found";
            response.StatusCode = 404;
            return;
          }
        }
      }

      if (imagePath == null)
      {
        // no valid image being permitteds
        // return the warning picture instead 
        // you can configure the warning picture from the web.config
        imagePath = context.Server.MapPath("~/Applications/Images/notAllowed.gif");
      }

      // set the right content 
      // and response with the right file
      response.ContentType = "image" + Path.GetExtension(imagePath).ToLower();

      // server the picture
      response.WriteFile(imagePath);

    }

    public bool IsReusable
    {
      get { return true; }
    }

  }
}