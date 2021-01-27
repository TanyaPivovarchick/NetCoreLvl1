using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppNETCore
{
    public class TestService : IHostedService, IDisposable
    {
        private ConfigOptions Options { get; }
        private ILogger Logger { get; }
        private Timer _timer;
        private bool _isDisposed = false;

        public TestService(IOptions<ConfigOptions> options, ILogger<TestService> logger)
        {
            Options = options.Value;
            Logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Logger.LogInformation("Starting test service");

            _timer = new Timer(_ => Logger.LogInformation(ReturnNewString()), null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

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
