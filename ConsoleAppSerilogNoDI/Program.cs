using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.IO;

namespace ConsoleAppSerilogNoDI
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read the appsettings file
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Apply the config to the logger
            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            logger.Verbose("This is a verbose statement");
            logger.Debug("This is a debug statement");
            logger.Information("This is a info statement");
            logger.Warning("This is a warning statement");
            logger.Error(new IndexOutOfRangeException(), "This is an error statement");
            logger.Fatal(new AggregateException(), "This is an fatal statement");
        }
    }
}
