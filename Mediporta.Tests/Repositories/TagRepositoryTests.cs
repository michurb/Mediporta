using Mediporta.Models;
using Xunit;
using Mediporta.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Mediporta.Tests.Repositories;

public class TagRepositoryTests
{
    private readonly DbContextOptions<AppDbContext> _options;
    [Fact]
    public async Task get_tag_should_succeed()
    {
        // Arrange

        // Act
        IEnumerable<TagModel> result;
        using (var context = new AppDbContext(_options))
        {
            var repository = new TagRepository(context);
            result = await repository.GetTagsAsync();
        }

        // Assert
        Assert.NotEmpty(result);
        Assert.Equal("Tag1", result.First().Name);
        Assert.Equal(1, result.First().Count);
        Assert.True(result.First().HasSynonyms);
        Assert.True(result.First().IsModeratorOnly);
        Assert.True(result.First().IsRequired);
        Assert.Equal("synonym1", result.First().Synonyms.First());
        Assert.Equal("description1", result.First().Collectives.First().Description);
        Assert.Equal("link1", result.First().Collectives.First().Link);
        Assert.Equal("slug1", result.First().Collectives.First().Slug);
        Assert.Equal("Collective1", result.First().Collectives.First().Name);
        Assert.Equal("https://example.com", result.First().Collectives.First().ExternalLinks.First().Link);
    }
    
    [Fact]
    public async Task delete_all_tags_should_succeed()
    {
        // Arrange

        // Act
        using (var context = new AppDbContext(_options))
        {
            var repository = new TagRepository(context);
            await repository.DeleteAllTagsAsync();
        }

        // Assert
        using (var context = new AppDbContext(_options))
        {
            Assert.Empty(context.Tags);
            Assert.Empty(context.Collectives);
            Assert.Empty(context.CollectiveExternalLinks);
        }
    }
    
    

    #region Arrange

    public TagRepositoryTests()
    {
        _options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        using (var context = new AppDbContext(_options))
        {
            context.Tags.Add(new TagModel
            {
                Name = "Tag1",
                Count = 1,
                HasSynonyms = true,
                IsModeratorOnly = true,
                IsRequired = true,
                Synonyms = ["synonym1", "sumonym2"],
                Collectives = new List<CollectiveModel>
                {
                    new CollectiveModel
                    {
                        Name = "Collective1",
                        Slug = "slug1",
                        CollectiveId = 1,
                        Description = "description1",
                        Link = "link1",
                        ExternalLinks = new List<CollectiveExternalLinkModel>
                        {
                            new CollectiveExternalLinkModel
                            {
                                Link = "https://example.com",
                                Type = "Type1"
                            }
                        }
                    }
                }
            });
            context.SaveChanges();
        }
    }

    #endregion
}