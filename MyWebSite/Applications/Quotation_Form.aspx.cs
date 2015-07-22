using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SherlockLib;

namespace MyWebSite.Applications
{
  public partial class Quotation_Form : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack)
      {
        SherlockQuotes quotes = new SherlockQuotes(Server.MapPath("../App_Code/sherlock-holmes.xml"));

        Quotation quote = quotes.GetRandomQuote();

        Response.Write("<b>" + quote.Source + "</b> (<i>" + quote.Date + "</i>)");

        Response.Write("<blockquote>" + quote.QuotationText + "</blockQuote>");


      }
    }
  }
}