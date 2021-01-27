using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppNETCore
{
    public interface IWorker
    {
        public Task PrintNumber(CancellationToken cancellationToken);
    }
}
