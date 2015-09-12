using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebSite.LinqSql.AutoGen
{
    // @partial class that provides the Partial implementation of OnLastNameChanging() method to do
    // ehck on the value and throw an exception to fail the update.
    public partial class Employees
    {
        partial void OnLastNameChanging(string value)
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("' " + value + "' is too short. The last name must be three characters.");
            }
        }
    }
}