using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace MyWebSite.LinqSql
{
  [Table(Name="Employees")]
  public class EmployeeDetails
  {
    [Column]
    public int EmployeeID { get; set; }

    [Column]
    public string FirstName { get; set; }

    [Column]
    public string LastName { get; set; }

    [Column]
    public string TitleOfCourtesy { get; set; }

    public EmployeeDetails(int employeeID, string firstName, string lastName, string titleOfCourtesy)
    {
      EmployeeID = employeeID;
      FirstName = firstName;
      LastName = lastName;
      TitleOfCourtesy = titleOfCourtesy;
    }

    public EmployeeDetails() { }
  }
}