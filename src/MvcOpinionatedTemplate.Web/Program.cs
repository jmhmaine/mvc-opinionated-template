using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog.Events;
using Serilog;
using Serilog.Formatting.Compact;

namespace MvcOpinionatedTemplate.Web
{
    public class Program
    {
        public static int Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                                .MinimumLevel.Debug()
                                .MinimumLevel.Override("Microsoft", LogEventLevel.Fatal)
                                .MinimumLevel.Override("System", LogEventLevel.Fatal)
                                .Enrich.FromLogContext()
                                .WriteTo.Console()
                                .WriteTo.File(new CompactJsonFormatter(), @"..\..\log\mvc.log", rollingInterval: RollingInterval.Minute)
                                .CreateLogger();

            try
            {
                Log.Information("Starting web host");
                BuildWebHost(args).Build().Run();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IWebHostBuilder BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseSerilog();
        }
    }
}
