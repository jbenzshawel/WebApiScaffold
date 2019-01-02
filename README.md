# Web API Scaffold
ASP.NET Core dotnet new template for scaffolding Web API projects. Default implementation includes Bearer Token authentication. Optional parameters for configuring NLog and Entity Framework Core. 


## Options
-N|--NLog : When set to true configures app to use NLog
* bool - Optional          
* Default: false / (*) true


-E|--EntityFramework : When set to true configures app to use Entity Framework Core  
* bool - Optional          
* Default: false / (*) true
                        
(* Indicates the value used if the switch is provided without a value.)


## Template Installation
After getting the project from git install the dotnet new template using the `--install` option. For example:

```
dotnet new --install ~/Projects/dotnet/Templates/WebApiScaffold/
```


## First Time Configuration

JWT TokenLifeInMinutes, TokenAudience, and TokenIssuer are set in appsettings.json. For development store Token Secret and Connetion Strings using app secrets. 

Example:
```
    dotnet user-secrets set "JwtSettings:TokenSecret" "YOUR SECRET STRING"
    dotnet user-secrets set "ConnectionStrings:AppDatabase" "YOUR CONNECTION STRING"
```

App Secrets Documentation:

https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-2.2
