using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Mediporta.Models;

public class TagModel
{
    [Key]
    public int TagId { get; set; }
    public string Name { get; set; }
    public int Count { get; set; }
    public bool HasSynonyms { get; set; }
    public bool IsModeratorOnly { get; set; }
    public bool IsRequired { get; set; }
    [JsonPropertyName("lastActivityDate")]
    public DateTime? LastActivityDate { get; set; }
    [JsonPropertyName("synonyms")]
    public List<string> Synonyms { get; set; } = new();
    [JsonPropertyName("userId")]
    public int? UserId { get; set; }
    [JsonPropertyName("collectives")]
    public List<CollectiveModel>? Collectives { get; set; } = new();
}