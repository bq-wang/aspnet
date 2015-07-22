using System;
using System.Configuration;
using System.Web.Configuration;

namespace MyWebSite.Applications
{
  public partial class OrderService_Form : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack)
      {
        Configuration config = WebConfigurationManager.OpenWebConfiguration("/");

        OrderService custSection = (OrderService)config.GetSection("orderService");

        if (custSection != null)
        {
          lblInfo.Text = "Retrieved service information...<br />" + "<b>Location:</b> " + custSection.Location.Computer +
              "<br /><b>Available: </b> " + custSection.Available.ToString() + "<br /><b>Timeout: </b> " + custSection.PollTimeout.ToString() + "<br /><br />";
        }
      }
    }
  }
}