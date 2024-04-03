using System.Text.Json;
using Mediporta.Models;
using Mediporta.Repositories;

namespace Mediporta.Services;

public class TagService : ITagService
{
    private readonly HttpClient _httpClient;
    private readonly ITagRepository _tagRepository;
    private readonly ILogger<TagService> _logger;

    public TagService(IHttpClientFactory httpClient, ITagRepository tagRepository, ILogger<TagService> logger)
    {
        _httpClient = httpClient.CreateClient("StackExchangeClient");
        _tagRepository = tagRepository;
        _logger = logger;
    }

    public async Task<IEnumerable<TagModel>> FetchTagsAsync(int pageSize, int tagsNumber)
    {
        await _tagRepository.DeleteAllTagsAsync();
        _logger.LogInformation("Fetching tags started...");
        List<TagModel> allTags = new();
        int pageNumber = 1;
        bool keepFetching = true;

        while (keepFetching)
        {
            var response = await _httpClient.GetAsync($"tags?page={pageNumber}&pagesize={pageSize}&order=desc&sort=popular&site=stackoverflow");
            if (response.IsSuccessStatusCode)
            {
                _logger.LogInformation("Resposne is successful");
                var result = await JsonSerializer.DeserializeAsync<StackExchangeResponse>(await response.Content.ReadAsStreamAsync(), 
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (result?.Items != null)
                {

                    foreach (var tagModel in result.Items)
                    {
                        var tag = new TagModel
                        {
                            Count = tagModel.Count,
                            HasSynonyms = tagModel.HasSynonyms,
                            IsModeratorOnly = tagModel.IsModeratorOnly,
                            IsRequired = tagModel.IsRequired,
                            LastActivityDate = tagModel.LastActivityDate,
                            Name = tagModel.Name,
                            Synonyms = tagModel.Synonyms,
                            UserId = tagModel.UserId,
                            TagId = tagModel.TagId,
                            Collectives = tagModel.Collectives?.Select(c => new CollectiveModel
                            {
                                Description = c.Description,
                                Name = c.Name,
                                CollectiveId = c.CollectiveId,
                                Slug = c.Slug,
                                Link = c.Link,
                                Tags = c.Tags,
                                ExternalLinks = c.ExternalLinks.Select(e => new CollectiveExternalLinkModel
                                {
                                    Link = e.Link,
                                    Type = e.Type,
                                }).ToList()
                            }).ToList()
                        };
                        allTags.Add(tag);
                    }

                    if (result.Items.Count < pageSize || allTags.Count >= tagsNumber)
                    {
                        keepFetching = false;
                    }
                }
            }
            else
            {
                _logger.LogError("Failed to fetch tags");
                keepFetching = false;
            }

            pageNumber++;
        }
        var totalCount = allTags.Sum(tag => tag.Count);

        foreach (var tag in allTags)
        {
            var percentage = (tag.Count / (double)totalCount) * 100;
            _logger.LogInformation($"Tag: {tag.Name}, Percentage: {percentage:F2}% of total population");
        }
        await _tagRepository.SaveTagsAsync(allTags.Take(tagsNumber));
        _logger.LogInformation("Fetching tags finished");
        return allTags.Take(tagsNumber);
    }

    public async Task<IEnumerable<TagModel>> GetPagedTagsAsync(int pageNumber = 1, int pageSize = 10,
        string orderBy = "Name", string sortDirection = "asc")
    {
        var tags = await _tagRepository.GetTagsAsync();
        if(sortDirection.ToLower() == "asc")
        { 
            tags = orderBy.ToLower() == "name" ? tags.OrderByDescending(t => t.Name) : tags.OrderByDescending(t => t.Count);
        }
        else
        {
            tags = orderBy.ToLower() == "name" ? tags.OrderBy(t => t.Name) : tags.OrderBy(t => t.Count);
        }
        return tags.Skip((pageNumber - 1) * pageSize).Take(pageSize);
    }
}