using Example.HttpClientFactory.Before.Models;
using System.Net.Http.Json;

namespace Example.HttpClientFactory.Before.Services;
public interface ICommitService
{
    Task<List<Commit>> GetCommitsAsync(string owner, string repo);
}
public class CommitService : ICommitService
{
    public async Task<List<Commit>> GetCommitsAsync(string owner, string repo)
    {
        using HttpClient httpClient = new HttpClient();

        httpClient.BaseAddress = new Uri("https://api.github.com/repos/");
        httpClient.DefaultRequestHeaders.Add("User-Agent", "Example.HttpClientFactory");

        using HttpResponseMessage response = await httpClient.GetAsync($"{owner}/{repo}/commits");

        var commits = await response.Content.ReadFromJsonAsync<List<Commit>>();

        if (commits is null)
        {
            throw new Exception("The json was null");
        }

        return commits;
    }
}
