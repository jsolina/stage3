using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAppAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                  .AddJsonFile("appsettings.json").Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            try
            {
                Log.Information(messageTemplate: "'SERILOG' Stag 3 - Application Started");
                CreateWebHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, " The application failed to start correctly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }   

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
              WebHost.CreateDefaultBuilder(args)
                  .UseStartup<Startup>().UseSerilog();


        public static void ConfigureLogger()
        {
            Log.Logger = new LoggerConfiguration().WriteTo.Console().WriteTo.File("@log.txt").CreateLogger();
        }
    }
}
