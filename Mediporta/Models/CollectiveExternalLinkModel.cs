using System.ComponentModel.DataAnnotations;

namespace Mediporta.Models;

public class CollectiveExternalLinkModel
{
    [Key]
    public int Id { get; set; }
    public string Link { get; set; }
    public string Type { get; set; }
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