using System.ComponentModel.DataAnnotations;

namespace Mediporta.Models;

public class CollectiveModel
{
    [Key]
    public int CollectiveId { get; set; }
    public string Description { get; set; }
    public string Link { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    
    public List<CollectiveExternalLinkModel> ExternalLinks { get; set; } = new List<CollectiveExternalLinkModel>();
    
    public List<TagModel> Tags { get; set; } = new List<TagModel>();
}