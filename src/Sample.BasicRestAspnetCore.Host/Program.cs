using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Sample.BasicRestAspnetCore.Host
{
    /// <summary>
    /// 
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }
        

        /// <summary>
        /// CreateWebHostBuilder
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            // WebHost.CreateDefaultBuilder(args)
            //     .UseKestrel(options => {
            //         options.Listen(IPAddress.Any, 8081);
            //     })
            //     .UseStartup<Startup>();
            WebHost.CreateDefaultBuilder()
            .ConfigureKestrel((context, options) =>{
                options.ListenAnyIP(9090);
                options.AddServerHeader = false;  
            }).UseStartup<Startup>().UseEnvironment("Production");
    }
}
