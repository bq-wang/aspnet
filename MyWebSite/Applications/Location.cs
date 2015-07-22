using System.Configuration;

namespace MyWebSite.Applications
{
  public class Location : ConfigurationElement
  {
    [ConfigurationProperty("computer", IsRequired = true)]
    public string Computer
    {
      get
      {
        return (string)base["computer"];
      }

      set
      {
        base["computer"] = value;
      }
    }

    [ConfigurationProperty("port", IsRequired = true)]
    public int Port
    {
      get
      {
        return (int)base["port"];
      }

      set
      {
        base["port"] = value;
      }
    }

    [ConfigurationProperty("endpoint", IsRequired = true)]
    public string Endpoint
    {
      get
      {
        return (string)base["endpoint"];
      }

      set
      {
        base["endpoint"] = value;
      }
    }
  }
}