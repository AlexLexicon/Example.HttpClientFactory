using System.Text.Json.Serialization;

namespace Example.HttpClientFactory.After.Models;
public class SubCommit
{
    [JsonPropertyName("comment_count")]
    public int CommentCount { get; set; }
    [JsonPropertyName("message")]
    public string? Message { get; set; }
    public string? Url { get; set; }
    public SubCommitAuthor? Author { get; set; }
}
