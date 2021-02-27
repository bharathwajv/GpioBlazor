using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace MyBlazor.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        public static IWebHost BuildWebHost(string[] args) =>
       WebHost.CreateDefaultBuilder(args)
           .UseConfiguration(new ConfigurationBuilder()
               .AddCommandLine(args)
               .Build())
           .UseUrls("http://*:5000/")
           .UseStartup<Startup>()
           .Build();
    }
}
