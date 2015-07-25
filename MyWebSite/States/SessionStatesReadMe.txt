there are several mode to manage the sttae , here we are talking about session

Session can be provided by 

- InProc
- State Server
- SQLServer
- Custom 

if you want to register the Sql server you can do the following. 

aspnet_regsql.exe -S localhost -E -ssadd


you can remove the local session state data base can be

aspnet_regsql.exe -S localhost -E -ssremove



-- to create a persistent data base /table , you can use the following commmand

aspnet_regsql.exe -S localhost -E -ssadd -sstype p 


-- or you can ask to create your own persisted table by specyfing the database name

aspnet_regsql.exe -S localhost -E -ssadd -sstype c -d MyCustomStateDb


the server will repond with the following information

若要在 Web 应用程序中使用此自定义会话状态数据库，请在配置文件中使用 <system.web>\<sessionState> 节中的“allowCustomSqlDatabase”和“sqlConnectionString”特性，进行相应的指定。

<sessionState allowCustomSqlDatabase="true" sqlConnectionString="data source=localhost;integrated Security=SSPI;Initial Catalog=MyCustomStateDb" />
