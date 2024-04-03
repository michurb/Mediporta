using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Mediporta.Models;

public sealed class AppDbContext : DbContext
{
 public DbSet<TagModel> Tags { get; set; }
 public DbSet<CollectiveModel> Collectives { get; set; }
 public DbSet<CollectiveExternalLinkModel> CollectiveExternalLinks { get; set; }

 public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

 protected override void OnModelCreating(ModelBuilder modelBuilder)
 {
  
 }
}