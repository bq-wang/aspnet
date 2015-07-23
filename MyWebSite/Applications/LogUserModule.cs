using System;
using System.Diagnostics;
using System.Web;

namespace MyWebSite.Applications
{
  public class LogUserModule : IHttpModule
  {
    public void Init(HttpApplication context)
    {
      // attach the application event process program
      context.AuthenticateRequest += new EventHandler(OnAuthentication);
    }

    public void Dispose()
    {
    }


    // NOTE:
    // you will be able to check the event from the 
    //    Program -> Management Tool -> "event viewere"
    private void OnAuthentication(object sender, EventArgs e)
    {
      // get the current user identity
      if (HttpContext.Current.User != null && HttpContext.Current.User.Identity != null && HttpContext.Current.User.Identity.Name != null)
      {
        string name = HttpContext.Current.User.Identity.Name;

        // Logging User name
        EventLog log = new EventLog();

        log.Source = "Log User Module";
        log.WriteEntry(name + "was authenticated.");
      }

      if (HttpContext.Current.User == null)
      {
        Trace.Write("HttpContext.Current.User == null");

        // seems that I lack the access right to the Event log
        // error message is as follow
        /*
Oops! looks like an error occurred!The source was not found, but some or all event logs could not be searched. To create the source, you need permission to read all event logs to make sure that the new source name is unique. Inaccessible logs: Security.
System.Security.SecurityException: The source was not found, but some or all event logs could not be searched. To create the source, you need permission to read all event logs to make sure that the new source name is unique. Inaccessible logs: Security. at System.Diagnostics.EventLog.FindSourceRegistration(String source, String machineName, Boolean readOnly, Boolean wantToCreate) at System.Diagnostics.EventLog.SourceExists(String source, String machineName, Boolean wantToCreate) at System.Diagnostics.EventLogInternal.VerifyAndCreateSource(String sourceName, String currentMachineName) at System.Diagnostics.EventLogInternal.WriteEntry(String message, EventLogEntryType type, Int32 eventID, Int16 category, Byte[] rawData) at System.Diagnostics.EventLog.WriteEntry(String message) at MyWebSite.Applications.LogUserModule.OnAuthentication(Object sender, EventArgs e) in c:\dev\workspaces\asp.net\aspnet\MyWebSite\Applications\LogUserModule.cs:line 43 at System.Web.HttpApplication.SyncEventExecutionStep.System.Web.HttpApplication.IExecutionStep.Execute() at System.Web.HttpApplication.ExecuteStep(IExecutionStep step, Boolean& completedSynchronously) The Zone of the assembly that failed was: MyComputer
Retrieved service information...
Location: OrderComputer
Available: True
Timeout: 00:01:00
         */
        EventLog log = new EventLog();
        log.Source = "Log User Module";
        log.WriteEntry("Cannot get User Identity");
        return;
      }


      if (HttpContext.Current.User.Identity == null)
      {
        Trace.Write("HttpContext.Current.User.Identity == null");
        return;
      }

      if (HttpContext.Current.User.Identity.Name == null)
      {
        Trace.Write("HttpContext.Current.User.Identity.Name == null");
        return;
      }

    }


  }
}