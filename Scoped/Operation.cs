using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Scoped
{
    public class Operation : IOperation
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public Operation(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task StartAsync(string thread, CancellationToken stoppingToken)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var repo = scope.ServiceProvider.GetService<IRepo>();
            var screen = scope.ServiceProvider.GetService<IScreen>();
            repo.Set(thread);

            while (!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine($"{thread}, {DateTime.Now}, {screen.Show()}");
                Thread.Sleep(1000);
            }
        }
    }
}