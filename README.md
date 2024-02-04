#Web Application Architecture# 

##Web API:##
  - **.Net Core Web API Project File**
  - Includes functions such as 'Get', 'Post', 'Put', 'Delete'
  
##Database:##
  - **Azure Database**
  - To access the database, *please provide your current IP address*. After that, you may follow the credentials below to access the database.
  - Login credentials:
    Server admin login: AdminAcc
    Password: 890123456Ji@
    ServerName : testing125.database.windows.net
    

*Remark: To connect the Web API to the database, **Scaffold-DbContext** was implemented.* 
"Data Source=tcp:testing125.database.windows.net,1433;Database=TestingDB;Persist Security Info=False;User ID=AdminAcc;Password=890123456Ji@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;Connect Timeout=30;"Microsoft.EntityFrameworkCore.SqlServer -Context DBContext -OutputDir Models -f






