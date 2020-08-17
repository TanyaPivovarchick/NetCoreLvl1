using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppNETCore
{
    public class TestService : IHostedService
    {
        private IConfiguration Config { get; }
        private ILogger Logger { get; }

        public TestService(IConfiguration config, ILogger<TestService> logger)
        {
            Config = config;
            Logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Logger.LogInformation("Starting test service");
            Logger.LogInformation(ReturnNewString());

            return Task.CompletedTask;
        }

        public string ReturnNewString()
        {
            return $"{Config["User:FirstName"]} {Config["User:LastName"]}";
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Logger.LogInformation("Stopping test service");

            return Task.CompletedTask;
        }
    }
}
