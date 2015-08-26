using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Data;

namespace MyWebSite.Asyncs
{
  public class CompletedResultSyncResult : IAsyncResult
  {
    private DataTable result;
    public DataTable Result
    {
      get
      {
        if (operationException != null)
        {
          throw OperationException;
        }
        return result;
      }

      set
      {
        result = value;
      }
    }

    private Exception operationException;

    public Exception OperationException
    {
      get
      {
        return operationException;
      }
      set
      {
        operationException = value;
      }
    }

    private object state;
    public CompletedResultSyncResult(Exception operationException, AsyncCallback asyncCallback, object asyncState)
    {
      state = asyncState;
      OperationException = operationException;
      if (asyncCallback != null)
      {
        asyncCallback(this);
      }
    }


    object IAsyncResult.AsyncState
    {
      get { return state; }
    }

    WaitHandle IAsyncResult.AsyncWaitHandle
    {
      get
      {
        return null;
      }
    }

    bool IAsyncResult.CompletedSynchronously
    {
      get { return true; }
    }

    bool IAsyncResult.IsCompleted
    {
      get { return true; }
    }

  }
}