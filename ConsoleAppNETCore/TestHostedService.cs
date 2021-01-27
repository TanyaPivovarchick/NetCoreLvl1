using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppNETCore
{
    public class TestHostedService : IHostedService, IDisposable
    {
        private ConfigOptions Options { get; }
        private ILogger Logger { get; }
        private Timer _timer;
        private bool _isDisposed = false;

        public TestHostedService(IOptions<ConfigOptions> options, ILogger<TestHostedService> logger)
        {
            Options = options.Value;
            Logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Logger.LogInformation("Starting TestHostedService");

            _timer = new Timer(_ => Logger.LogInformation(ReturnNewString()), null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        public string ReturnNewString()
        {
            return $"{Options.FirstName} {Options.LastName}";
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Logger.LogInformation("Stopping TestHostedService");

            return Task.CompletedTask;
        }

        public void Dispose() => Dispose(true);

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    _timer?.Dispose();
                }

                _isDisposed = true;
            }
        }
    }
}
