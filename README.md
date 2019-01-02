# Web API Scaffold
ASP.NET Core dotnet new template for scaffolding Web API projects. Default implementation includes Bearer Token authentication. Optional parameters for configuring NLog, Entity Framework Core, and Solution file. 

Example:
```
dotnet new apiscaffold -N -E -A
```

## Options
-N|--NLog : When set to true configures app to use NLog
* bool - Optional          
* Default: false / (*) true


-E|--EntityFramework : When set to true configures app to use Entity Framework Core  
* bool - Optional          
* Default: false / (*) true


-A|--AddSolution : When set to true includes Visual Studio solution file (use this option with Windows)
* bool - Optional
* Default: false / (*) true
                        
(* Indicates the value used if the switch is provided without a value.)


## Template Installation
After getting the project from git install the dotnet new template using the `--install` option. For example:

```
dotnet new --install ~/Projects/dotnet/Templates/WebApiScaffold/
```


## App Settings Configuration

Settings for JWT TokenLifeInMinutes, TokenAudience, and TokenIssuer are set in appsettings.json. For development Token Secret and Connetion Strings are stored using [app secrets](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-2.2). 

Example:
```
    dotnet user-secrets set "JwtSettings:TokenSecret" "YOUR SECRET STRING"
    dotnet user-secrets set "ConnectionStrings:AppDatabase" "YOUR CONNECTION STRING"
```
