using Example.HttpClientFactory.After.Models;
using Example.HttpClientFactory.After.Options;
using System.Net.Http.Json;

namespace Example.HttpClientFactory.After.Services;
public interface IBranchService
{
    Task<List<Branch>> GetBranchesAsync(string owner, string repo);
}
public class BranchService : IBranchService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public BranchService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<List<Branch>> GetBranchesAsync(string owner, string repo)
    {
        HttpClient httpClient = _httpClientFactory.CreateClient(nameof(GitHubHttpClientOptions));

        using HttpResponseMessage response = await httpClient.GetAsync($"{owner}/{repo}/branches");

        var branches = await response.Content.ReadFromJsonAsync<List<Branch>>();

        if (branches is null)
        {
            throw new Exception("The json was null");
        }

        return branches;
    }
}
