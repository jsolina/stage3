using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace CourseAPI
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

            /* cedie configuration code
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("System", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File(new RenderedCompactJsonFormatter(), "/serilog/log.json")
                .WriteTo.Seq("http://localhost:5341")
                .CreateLogger();
            */

            /*
            Log.Logger = new LoggerConfiguration()
            .Enrich.WithSensitiveDataMaskingInArea()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .MinimumLevel.Override("System", LogEventLevel.Warning)
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .WriteTo.File(new RenderedCompactJsonFormatter(), "/serilog/log.json")
            .WriteTo.Seq("http://localhost:5341")

            .CreateLogger();

            using (Log.Logger.EnterSensitiveArea())
            {
                Log.Logger.Information("This is a sensitive {taskName}", TaskLists.taskName);
            }
            */

            /*
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .MinimumLevel.Override("System", LogEventLevel.Warning)
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .WriteTo.File(new RenderedCompactJsonFormatter(), "/serilog/log.json")
            .WriteTo.Seq("http://localhost:5341")
            .Destructure.ByMaskingProperties(opts =>
            {
                opts.PropertyNames.Add("taskName");
                opts.Mask = "******";
            })
            .CreateLogger();
            */

            try
            {
                Log.Information(messageTemplate: "'SERILOG' Application Started");
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
