using JvA.Library.Persistence.DbContexts;
using JvA.Library.Persistence.Seeds;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Linq;

namespace JvA.Library.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

            Log.Logger = new LoggerConfiguration()
               .ReadFrom.Configuration(config)
               .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
               .CreateLogger();

            var host = CreateHostBuilder(args).Build();
            if (args.Contains("seed"))
            {
                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                    try
                    {
                        var dbContext = services.GetRequiredService<AraujoDbContext>();
                        DatabaseBootStrap.AddDevContext(dbContext);
                        Log.Information("Application Starting");
                    }
                    catch (Exception ex)
                    {
                        Log.Warning(ex, "An error occured while starting the application");
                    }
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
