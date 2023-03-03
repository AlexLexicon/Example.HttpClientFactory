using Example.HttpClientFactory.After.Models;
using Example.HttpClientFactory.After.Options;
using System.Net.Http.Json;

namespace Example.HttpClientFactory.After.Services;
public interface ICommitService
{
    Task<List<Commit>> GetCommitsAsync(string owner, string repo);
}
public class CommitService : ICommitService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public CommitService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<List<Commit>> GetCommitsAsync(string owner, string repo)
    {
        HttpClient httpClient = _httpClientFactory.CreateClient(nameof(GitHubHttpClientOptions));

        using HttpResponseMessage response = await httpClient.GetAsync($"{owner}/{repo}/commits");

        var commits = await response.Content.ReadFromJsonAsync<List<Commit>>();

        if (commits is null)
        {
            throw new Exception("The json was null");
        }

        return commits;
    }
}
