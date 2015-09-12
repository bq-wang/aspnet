using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using MyWebSite.LinqSql.AutoGen;

namespace MyWebSite.LinqSql
{
    public class AutoGenLinqNorthwindDB
    {
        private DataContext dataContext;
        #region Ctor(s) 
        public AutoGenLinqNorthwindDB() : this (WebConfigurationManager.ConnectionStrings["NorthWind"].ConnectionString)
        {

        }
        public AutoGenLinqNorthwindDB(string connection)
        {
            dataContext = new DataContext(connection);
        }
        #endregion
        
        public List<Customers> GetCustomers()
        {
            return dataContext.GetTable<Customers>().ToList();
        }
    }
}