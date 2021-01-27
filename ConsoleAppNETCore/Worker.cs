using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppNETCore
{
    public class Worker : IWorker
    {
        private ILogger Logger { get; }
        private int _number = 0;

        public Worker(ILogger<Worker> logger)
        {
            Logger = logger;
        }

        public async Task PrintNumber(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                Interlocked.Increment(ref _number);
                Logger.LogInformation($"Number: {_number}");

                await Task.Delay(3000, cancellationToken);
            }
        }
    }
}
