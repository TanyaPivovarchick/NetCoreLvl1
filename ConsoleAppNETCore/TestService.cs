using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppNETCore
{
    public class TestService : IHostedService
    {
        private ILogger Logger { get; }

        public TestService(ILogger<TestService> logger)
        {
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
            return "Some test string";
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Logger.LogInformation("Stopping test service");

            return Task.CompletedTask;
        }
    }
}
