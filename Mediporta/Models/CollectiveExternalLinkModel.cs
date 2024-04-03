using System.ComponentModel.DataAnnotations;

namespace Mediporta.Models;

public sealed class CollectiveExternalLinkModel
{
    [Key]
    public int Id { get; set; }
    public string Link { get; set; }
    public string Type { get; set; }
}