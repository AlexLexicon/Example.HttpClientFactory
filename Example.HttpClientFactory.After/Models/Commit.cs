using System.Text.Json.Serialization;

namespace Example.HttpClientFactory.After.Models;
public class Commit
{
    [JsonPropertyName("comments_url")]
    public string? CommentsUrl { get; set; }
    [JsonPropertyName("node_id")]
    public string? NodeId { get; set; }
    [JsonPropertyName("sha")]
    public string? Sha { get; set; }
    [JsonPropertyName("url")]
    public string? Url { get; set; }
    [JsonPropertyName("commit")]
    public SubCommit? SubCommit { get; set; }
}
