using Mediporta.Models;

namespace Mediporta.Repositories;

public interface ITagRepository
{
    Task SaveTagsAsync(IEnumerable<TagModel> tags);
    Task DeleteAllTagsAsync();
}