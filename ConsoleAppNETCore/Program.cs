using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SharedLibraryNETStandard;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleAppNETCore
{
    class Program
    {
        public static IConfiguration Configuration { get; set; }

        static async Task Main(string[] args)
        {
            Console.WriteLine(TestClass.GetCurrentDate());

            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables(prefix: "PREFIX_")
                .AddCommandLine(args)
                .Build();


            await CreateHostBuilder(args).Build().RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureHostConfiguration(configHost =>
                {
                    configHost.SetBasePath(Directory.GetCurrentDirectory());
                    configHost.AddJsonFile("appsettings.json", optional: true);
                    configHost.AddEnvironmentVariables(prefix: "PREFIX_");
                    configHost.AddCommandLine(args);
                })
                .ConfigureServices(services =>
                {
                    services.AddOptions<ConfigOptions>()
                        .Bind(Configuration.GetSection(ConfigOptions.Section));
                    services.AddSingleton<IHostedService, TestService>();
                });
    }
}
