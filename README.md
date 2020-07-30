# ConsoleAppSerilogNoDI
Sample settings and packages required to use Serilog in a .NET Core 3.1 console app.
The log file is rolling by day as in the settings.

STEPS:
1. Install the packages
* PM> Install-Package Microsoft.Extensions.Configuration
* PM> Install-Package Microsoft.Extensions.Configuration.FileExtensions
* PM> Install-Package Microsoft.Extensions.Configuration.Json
* PM> Install-Package Serilog.Settings.Configuration
* PM> Install-Package Serilog.Sinks.File
* PM> Install-Package Serilog.Sinks.Console

2. Use the following config
```json
{
  "Serilog": {
    "Using": [ "Serilog.Sinks.Console" ],
    "MinimumLevel": "Information",
    "Enrich": [ "WithProcessId" ],
    "WriteTo": [
      {
        "Name": "File",
        "Args": {
          "path": ".\\Logs\\Log-.txt",
          "rollingInterval": "Day",
          "outputTemplate": "[{Timestamp} [{Level}] {Message} {Exception} {NewLine}"
        }
      }
    ],
    "Properties": {
      "Application": "Serilog Console Application"
    }
  }
}
```
