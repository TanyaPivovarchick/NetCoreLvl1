using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppNETCore
{
    public class TestBackgroundService : BackgroundService
    {
        private ILogger Logger { get; }
        private IWorker Worker { get; }

        public TestBackgroundService(IWorker worker, ILogger<TestHostedService> logger)
        {
            Worker = worker;
            Logger = logger;
        }

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            Logger.LogInformation("Starting TestBackgroundService");

            await base.StartAsync(cancellationToken);
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            Logger.LogInformation("Stopping TestBackgroundService");

            await base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            await Worker.PrintNumber(cancellationToken);
        }
    }
}
