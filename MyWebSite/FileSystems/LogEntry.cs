using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebSite.FileSystems
{
  [Serializable()]
  public class LogEntry
  {
    private string message;
    private DateTime date;


    public string Message
    {
      get { return message; }
      set { message = value; }
    }

    public DateTime Date
    {
      get { return date; }
      set { date = value; }
    }

    public LogEntry(string message)
    {
      Message = message;
      Date = DateTime.Now;
    }
  }
}