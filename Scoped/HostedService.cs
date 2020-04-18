using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Scoped
{
    public class HostedService : BackgroundService
    {
        private readonly IOperation _operation;

        public HostedService(IOperation operation)
        {
            _operation = operation;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.Run(() =>
            {
                for (int i = 0; i < 2; i++)
                {
                    var a = i.ToString();
                    Task.Run(() => _operation.StartAsync(a, stoppingToken), stoppingToken);
                }
            }, stoppingToken);
        }
    }
}