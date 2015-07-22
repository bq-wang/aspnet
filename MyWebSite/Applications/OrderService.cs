using System;
using System.Configuration;

namespace MyWebSite.Applications
{
  public class OrderService : ConfigurationSection
  {
    [ConfigurationProperty("available", IsRequired = false, DefaultValue = true)]
    public bool Available
    {
      get
      {
        return (bool)base["available"];
      }

      set
      {
        base["available"] = value;
      }
    }

    [ConfigurationProperty("pollTimeout", IsRequired = true)]
    public TimeSpan PollTimeout
    {
      get
      {
        return (TimeSpan)base["pollTimeout"];
      }

      set
      {
        base["pollTimeout"] = value;
      }
    }

    [ConfigurationProperty("location", IsRequired = true)]
    public Location Location
    {
      get
      {
        return (Location)base["location"];
      }

      set
      {
        base["location"] = value;
      }
    }

  }
}