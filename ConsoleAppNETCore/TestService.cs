using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppNETCore
{
    public class TestService : IHostedService
    {
        private ConfigOptions Options { get; }
        private ILogger Logger { get; }

        public TestService(IOptions<ConfigOptions> options, ILogger<TestService> logger)
        {
            Options = options.Value;
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
            return $"{Options.FirstName} {Options.LastName}";
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Logger.LogInformation("Stopping test service");

            return Task.CompletedTask;
        }
    }
}
