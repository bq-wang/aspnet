using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;
using System.Web.Configuration;

namespace MyWebSite.LinqSql
{
  public class LinqNorthwindDB
  {
    private DataContext dataContext;
    public LinqNorthwindDB() : this (WebConfigurationManager.ConnectionStrings["NorthWind"].ConnectionString)
    {
    }

    public LinqNorthwindDB(string connectionString)
    {
      dataContext = new DataContext(connectionString);
    }

    public IQueryable<EmployeeDetails> GetEmployees()
    {
      //DataContext dataContext = new DataContext(connectionString);
      return dataContext.GetTable<EmployeeDetails>();
    }

    public EmployeeDetails GetEmployee(int ID)
    {
      var matches = from employee in dataContext.GetTable<EmployeeDetails>()
                    where employee.EmployeeID == ID
                    select employee;
      return matches.Single();
    }

  }
}