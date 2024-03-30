using Mediporta.Models;

namespace Mediporta.Repositories;

public interface ITagRepository
{
    Task<IEnumerable<TagModel>> GetTagsAsync();
    Task SaveTagsAsync(IEnumerable<TagModel> tags);
    Task DeleteAllTagsAsync();
}