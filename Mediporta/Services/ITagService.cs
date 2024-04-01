using Mediporta.Models;

namespace Mediporta.Services;

public interface ITagService
{
    Task<IEnumerable<TagModel>> FetchTagsAsync(int pageSize, int tagsNumber);
    Task<IEnumerable<TagModel>> GetPagedTagsAsync(int pageNumber, int pageSize, string orderBy, string sortDirection);
}