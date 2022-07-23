using Microsoft.Extensions.Hosting;

namespace CampaignMonitor.Test;

public class TestHost : IHostedService
{
    /// <inheritdoc/>
    public Task StartAsync(CancellationToken cancellationToken)
    {
        var testCaseOutput1 = TestCases.isNullOrEmpty(null);
        var testCaseOutput2 = TestCases.TestCase2(60);
        var testCase1Output3 = TestCases.TestCase3(3, 4, 5);
        var testCase1Output4 = TestCases.TestCase4(new List<int> { 1, 2, 3, 4, 5, 6, 7 });

        return Task.CompletedTask;
    }

    /// <inheritdoc/>
    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}