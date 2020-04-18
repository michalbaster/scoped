using System.Threading;
using System.Threading.Tasks;

namespace Scoped
{
    public interface IOperation
    {
        Task StartAsync(string thread, CancellationToken stoppingToken);
    }
}