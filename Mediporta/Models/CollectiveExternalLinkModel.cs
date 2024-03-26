using System.ComponentModel.DataAnnotations;

namespace Mediporta.Models;

public class CollectiveExternalLinkModel
{
    [Key]
    public int CollectiveExternalLinkId { get; set; }
    public string Link { get; set; }
    
    public ExternalLinkType Type { get; set; }

    // Navigation property to Collective
    public int CollectiveId { get; set; }
    public CollectiveModel Collective { get; set; }
}
public enum ExternalLinkType
{
    Website,
    Twitter,
    Github,
    Facebook,
    Instagram,
    Support,
    Linkedin
}