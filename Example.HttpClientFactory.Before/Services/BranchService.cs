using Example.HttpClientFactory.Before.Models;
using System.Net.Http.Json;

namespace Example.HttpClientFactory.Before.Services;
public interface IBranchService
{
    Task<List<Branch>> GetBranchesAsync(string owner, string repo);
}
public class BranchService : IBranchService
{
    public async Task<List<Branch>> GetBranchesAsync(string owner, string repo)
    {
        using HttpClient httpClient = new HttpClient();

        httpClient.BaseAddress = new Uri("https://api.github.com/repos/");
        httpClient.DefaultRequestHeaders.Add("User-Agent", "Example.HttpClientFactory");

        using HttpResponseMessage response = await httpClient.GetAsync($"{owner}/{repo}/branches");

        var branches = await response.Content.ReadFromJsonAsync<List<Branch>>();

        if (branches is null)
        {
            throw new Exception("The json was null");
        }

        return branches;
    }
}
