using System.Text.Json;
using Mediporta.Models;
using Mediporta.Repositories;

namespace Mediporta.Services;

public class TagService
{
    private readonly HttpClient _httpClient;
    private readonly ITagRepository _tagRepository;

    public TagService(IHttpClientFactory httpClient, ITagRepository tagRepository)
    {
        _httpClient = httpClient.CreateClient("StackExchangeClient");
        _tagRepository = tagRepository;
    }

    public async Task<IEnumerable<TagModel>> FetchTagsAsync(int pageSize = 100, int tagsNumber = 1000)
    {
        await _tagRepository.DeleteAllTagsAsync();
        List<TagModel> allTags = new();
        int pageNumber = 1;
        bool keepFetching = true;

        while (keepFetching)
        {
            var response = await _httpClient.GetAsync($"tags?page={pageNumber}&pagesize={pageSize}&order=desc&sort=popular&site=stackoverflow");
            if (response.IsSuccessStatusCode)
            {
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
                keepFetching = false;
            }

            pageNumber++;
        }

        await _tagRepository.SaveTagsAsync(allTags.Take(tagsNumber));
        return allTags.Take(tagsNumber);
    }
}

public class StackExchangeResponse
{
    public List<TagModel> Items { get; set; }
}