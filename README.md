# Serilog logger class library
This class library can be published as a Nuget or can be referenced directly in the project.

[![Build Status](https://dev.azure.com/bm1905/SharedLibraries/_apis/build/status/bm1905.Logger?branchName=master)](https://dev.azure.com/bm1905/SharedLibraries/_build/latest?definitionId=1&branchName=master)

## Usage

In `Program.cs` file, use the Serilog's UeSerilog hosting extension by providing the nuget configuration. `SeriLogger.Configure` comes from the nuget.
```cs
public static class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    private static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .UseSerilog(SeriLogger.Configure)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}
```

Then add the following to the configuration file `appsettings.YOUR ENV.json`
```json
"Serilog": {
    "MinimumLevel": {
        "Default": "Information",
        "Override": {
            "Microsoft": "Information",
            "System": "Warning"
        }
    }
},
"ElasticConfiguration": {
    "Uri": "URI for elastic"
}
```
If using just Program.cs file in .NET 6, then:
```cs
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog(SeriLogger.Configure);
```
