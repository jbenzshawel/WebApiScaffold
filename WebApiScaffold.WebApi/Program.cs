using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
#if( NLog )
using NLog.Web;
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
                logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
            })
            .UseNLog();
#else
            WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>();
#endif
    }
}
