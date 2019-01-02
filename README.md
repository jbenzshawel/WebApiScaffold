#Web API Scaffold
ASP.NET Core dotnet new template for scaffolding Web API projects. Default implementation includes Bearer Token authentication. Optional parameters for configuring NLog and Entity Framework Core. 

##Options
  -N|--NLog : When set to true configures app to use NLog                                
                        bool - Optional          
                        Default: false / (*) true
    

  -E|--EntityFramework : When set to true configures app to use EntityFramework
                        bool - Optional          
                        Default: false / (*) true
* Indicates the value used if the switch is provided without a value.

##First Time Configuration
In development store  Token Secret and Connetion Strings using app secrets:
    dotnet user-secrets set "JwtSettings:TokenSecret" "YOUR SECRET STRING"
    dotnet user-secrets set "ConnectionStrings:AppDatabase" "YOUR CONNECTION STRING"

https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-2.2

TokenLifeInMinutes, TokenAudience, and TokenIssuer are set in appsettings.json