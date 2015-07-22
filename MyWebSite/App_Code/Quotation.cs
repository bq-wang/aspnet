using System.Xml;

namespace SherlockLib
{
  public class Quotation
  {
    private string qsource;

    public string Source
    {
      get { return qsource; }
      set { qsource = value; }
    }

    private string date;
    public string Date
    {
      get { return date; }
      set { date = value; }
    }

    private string quotation;
    public string QuotationText
    {
      get { return quotation; }
      set { quotation = value; }
    }

    public Quotation(XmlNode quoteNode)
    {
      if (quoteNode.SelectSingleNode("source") != null)
        qsource = quoteNode.SelectSingleNode("source").InnerText;

      if ((quoteNode.Attributes.GetNamedItem("date")) != null)
        date = quoteNode.Attributes.GetNamedItem("date").Value;

      quotation = quoteNode.FirstChild.InnerText;

    }
  }
}