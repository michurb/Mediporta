using System.Text.Json;
using Mediporta.Controllers;
using Mediporta.Models;
using Mediporta.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Mediporta.Tests.Integration.Controller;

public class TagsControllerTests
{
    private readonly Mock<ITagService> _tagServiceMock = new Mock<ITagService>();
    private readonly TagsController _tagsController;

    public TagsControllerTests()
    {
        _tagsController = new TagsController(_tagServiceMock.Object, new Mock<ILogger<TagsController>>().Object);
    }

    [Fact]
    public async Task get_tags_should_return_200_status_code()
    {
        var fakeTags = new List<TagModel>
        {
            //Arrange
            new TagModel
            {
                TagId = 1,
                Name = "Tag1",
                Count = 1,
                HasSynonyms = true,
                IsModeratorOnly = true,
                IsRequired = true,
                Synonyms = new List<string> { "synonym1" },
                Collectives = new List<CollectiveModel>
                {
                    new CollectiveModel
                    {
                        CollectiveId = 1,
                        Description = "description1",
                        Link = "link1",
                        Slug = "slug1",
                        Name = "Collective1",
                        ExternalLinks = new List<CollectiveExternalLinkModel>
                        {
                            new CollectiveExternalLinkModel()
                            {
                                Id = 1,
                                Link = "https://example.com",
                                Type = "type1"
                            }
                        }
                    }
                }
            }
        };
        _tagServiceMock.Setup(x => x.FetchTagsAsync(It.IsAny<int>(),It.IsAny<int>())).ReturnsAsync(fakeTags);
        
        //Act
        var result = await _tagsController.GetTagsAsync();
        var okResult = result.Result as OkObjectResult;
        var returnValue = okResult.Value as List<TagModel>;
                
        //Assert
        Assert.NotNull(okResult);
        Assert.Equal(fakeTags.Count, returnValue.Count);
        Assert.Equal(200, okResult.StatusCode);
        Assert.NotNull(returnValue);
    }
}