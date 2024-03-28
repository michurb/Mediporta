using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Mediporta.Models;

public class CollectiveModel
{
    [Key]
    public int CollectiveId { get; set; }
    public string Description { get; set; }
    public string Link { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    [JsonPropertyName("external_links")]
    public List<CollectiveExternalLinkModel> ExternalLinks { get; set; }

    public List<string>? Tags { get; set; } = new();
}