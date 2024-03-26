using System.ComponentModel.DataAnnotations;

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
    public DateTime? LastActivityDate { get; set; }
    public List<string> Synonyms { get; set; } = new List<string>();
    public int? UserId { get; set; }

    // New: Navigation property to Collective
    public int? CollectiveId { get; set; }
    public CollectiveModel Collective { get; set; }
}