# Serilog logger class library
This class library can be published as a Nuget or can be referenced directly in the project.

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