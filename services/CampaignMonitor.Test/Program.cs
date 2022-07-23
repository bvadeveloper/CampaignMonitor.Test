using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CampaignMonitor.Test
{
    public static class Program
    {
        public static async Task Main(string[] args) =>
            await Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services
                        .AddHttpClient()
                        .AddHostedService<TestHost>()
                        .AddHostedService<LinksCheckerHost>();
                })
                .ConfigureLogging(builder => builder.AddConsole())
                .Build()
                .RunAsync();
    }
}