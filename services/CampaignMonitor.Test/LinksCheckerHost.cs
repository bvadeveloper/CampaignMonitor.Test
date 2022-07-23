using System.Net;
using System.Threading.Tasks.Dataflow;
using HtmlAgilityPack;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CampaignMonitor.Test;

public class LinksCheckerHost : IHostedService
{
    private const int MaxParallelism = 10;
    private const string TargetLink = "https://www.campaignmonitor.com/";

    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger _logger;

    public LinksCheckerHost(IHttpClientFactory clientFactory, ILogger<LinksCheckerHost> logger)
    {
        _httpClientFactory = clientFactory;
        _logger = logger;
    }

    /// <inheritdoc/>
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var links = await GetLinksAsync(cancellationToken);
        var responses = await CheckLinksAsync(links, cancellationToken);

        foreach (var (url, httpStatusCode) in responses)
        {
            _logger.LogWarning("Link '{Url}' status code '{HttpStatusCode}'", url.ToString(), httpStatusCode);
        }
    }

    private async Task<IList<(Uri, HttpStatusCode)>> CheckLinksAsync(IEnumerable<string> links,
        CancellationToken cancellationToken)
    {
        var downloaderBlock = new TransformBlock<string, (Uri, HttpStatusCode)>(Downloader,
            new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = MaxParallelism });

        var bufferBlock = new BufferBlock<(Uri, HttpStatusCode)>();
        downloaderBlock.LinkTo(bufferBlock);

        foreach (var link in links)
        {
            await downloaderBlock.SendAsync(link, cancellationToken);
        }

        downloaderBlock.Complete();
        await downloaderBlock.Completion;

        if (bufferBlock.TryReceiveAll(out var responses))
        {
            return responses;
        }

        throw new Exception("Couldn't get responses");
    }

    private async Task<(Uri, HttpStatusCode)> Downloader(string link)
    {
        var httpClient = _httpClientFactory.CreateClient(); // reuse http clients from pool

        var url = new Uri(link);
        var response = await httpClient.GetAsync(url);

        return (url, response.StatusCode);
    }

    private static async Task<IEnumerable<string>> GetLinksAsync(CancellationToken cancellationToken)
    {
        var links = new HashSet<string>(); // avoiding duplicates

        var web = new HtmlWeb();
        var doc = await web.LoadFromWebAsync(TargetLink, cancellationToken);

        // extracting all links
        foreach (var link in doc.DocumentNode.SelectNodes("//a[@href]"))
        {
            var att = link.Attributes["href"];

            if (att.Value.Contains('a') && Uri.IsWellFormedUriString(att.Value, UriKind.Absolute))
            {
                links.Add(att.Value);
            }
        }

        return links;
    }

    /// <inheritdoc/>
    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}