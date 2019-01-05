using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

#if( NLog )
using NLog.Web;
using System;
using Microsoft.Extensions.Logging;
#endif

namespace WebApiScaffold.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
#if( NLog )
            var logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

            try 
            {
                CreateWebHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Stopped program because of exception");
                throw;
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
#else
            CreateWebHostBuilder(args).Build().Run();
#endif
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
#if( NLog )
            WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.SetMinimumLevel(LogLevel.Trace);
            })
            .UseNLog();
#else
            WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>();
#endif
    }
}
