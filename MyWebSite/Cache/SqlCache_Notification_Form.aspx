<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SqlCache_Notification_Form.aspx.cs" Inherits="MyWebSite.Cache.SqlCache_Notification_Form" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <!-- 
      1. understand sql cache notification

      first you need to enable Database cache notification 
        aspnet_regsql -ed -E -d Northwind

      then you will need to enable table notification 
        aspnet_regsql -et -E -d Northwind -t Employees


      to reverse the operations mentioned above, you can do the following.
        aspnet_regsql -dt -E -d Northwind -t Employees
      and 
        aspnet_regsql -dd -E -d Northwind

      well after that if you view from the management studio, you will find the following..

        Store procedure 

          USE [Northwind]
          GO
          /****** Object:  StoredProcedure [dbo].[AspNet_SqlCacheUpdateChangeIdStoredProcedure]    Script Date: 08/24/2015 21:34:14 ******/
          SET ANSI_NULLS ON
          GO
          SET QUOTED_IDENTIFIER ON
          GO
          ALTER PROCEDURE [dbo].[AspNet_SqlCacheUpdateChangeIdStoredProcedure] 
                       @tableName NVARCHAR(450) 
           AS

           BEGIN 
               UPDATE dbo.AspNet_SqlCacheTablesForChangeNotification WITH (ROWLOCK) SET changeId = changeId + 1 
               WHERE tableName = @tableName
           END
   
      then there would be a trigger on the table for Employees.

        USE [Northwind]
        GO
        /****** Object:  Trigger [dbo].[Employees_AspNet_SqlCacheNotification_Trigger]    Script Date: 08/24/2015 21:33:12 ******/
        SET ANSI_NULLS ON
        GO
        SET QUOTED_IDENTIFIER ON
        GO
        ALTER TRIGGER [dbo].[Employees_AspNet_SqlCacheNotification_Trigger] ON [dbo].[Employees]
                               FOR INSERT, UPDATE, DELETE AS BEGIN
                               SET NOCOUNT ON
                               EXEC dbo.AspNet_SqlCacheUpdateChangeIdStoredProcedure N'Employees'
                               END


    2.  SQL Server 2005 and Sql Server 2008 the way to do the Sql notification are different .

      User Northwind
      ALTER DATABASE Northwind SET ENABLE_BROKER

    to query if a database/table has broker enabled.
          SELECT name, is_broker_enabled FROM sys.databases;
          GO

    google then give you a more detailed 

      ALTER DATABASE Northwind SET NEW_BROKER WITH ROLLBACK IMMEDIATE;
      ALTER DATABASE Northwind SET ENABLE_BROKER;


    then you will need to grant query access to the service/users.

      GRANT SUBSCRIBE QUERY NOTIFICATIONS TO "YJ104\Administrator"
      GO

      GRANT SUBSCRIBE QUERY NOTIFICATIONS TO "NT SERVICE\MSSQLSERVER"
      GO


    while, when you do connection string and sql command with ado.net you will need to do the following.


      string sql = "SELECT EmployeeID, FirstName, LastName, City FROM dbo.Employees";
      
    Last, in the Global.ashx handler, you will need to call the SqlDependency.Start method in Application_Start handler
      string connectionString = WebConfigurationManager.ConnectionStrings["NorthWind"].ConnectionString;
      SqlDependency.Start(connectionString);
    you can stop the Sql Dependency on the Application_End handler.
      string connectionString = WebConfigurationManager.ConnectionStrings["NorthWind"].ConnectionString;
      SqlDependency.Stop(connectionString);
      
    you can find the following reference data link
        http://blog.csdn.net/rise51/article/details/6063090

        http://www.asp.net/web-forms/overview/data-access/caching-data/using-sql-cache-dependencies-vb

        http://www.dotnetcurry.com/showarticle.aspx?ID=263

      -->
    </div>
    </form>
</body>
</html>
