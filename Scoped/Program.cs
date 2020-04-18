using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Scoped
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddTransient<IOperation, Operation>();
                    services.AddTransient<IScreen, Screen>();
                    services.AddScoped<IRepo, Repo>();
                    services.AddHostedService<HostedService>();
                }).Build().Run();
        }
    }
}