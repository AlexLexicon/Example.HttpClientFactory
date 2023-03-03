using Example.HttpClientFactory.Before.Models;
using Example.HttpClientFactory.Before.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

/*
 * -------------------------------------------------------
 *            Dependency Injection Registration
 * -------------------------------------------------------
 */

IServiceCollection services = new ServiceCollection();
IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

services.AddSingleton(configuration);

services.AddScoped<IBranchService, BranchService>();
services.AddScoped<ICommitService, CommitService>();

ServiceProvider provider = services.BuildServiceProvider();

/*
 * -------------------------------------------------------
 *                       Console App
 * -------------------------------------------------------
 */

const string GITHUB_OWNER = "AlexLexicon";
const string GTIHUB_REPO = "Example.HttpClientFactory";


var branchService = provider.GetRequiredService<IBranchService>();
List<Branch> branches = await branchService.GetBranchesAsync(GITHUB_OWNER, GTIHUB_REPO);

Console.WriteLine("Branches:");
foreach (Branch branch in branches)
{
    Console.WriteLine($"-{branch.Name}");
}


var commitService = provider.GetRequiredService<ICommitService>();
List<Commit> commits = await commitService.GetCommitsAsync(GITHUB_OWNER, GTIHUB_REPO);

Console.WriteLine("Commits:");
foreach (Commit commit in commits)
{
    Console.WriteLine($"-[{commit.SubCommit?.Author?.Date}]: {commit.SubCommit?.Message}");
}