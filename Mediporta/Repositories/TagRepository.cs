using Mediporta.Models;
using Microsoft.EntityFrameworkCore;

namespace Mediporta.Repositories;

public sealed class TagRepository : ITagRepository
{
    private readonly AppDbContext _context;

    public TagRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<TagModel>> GetTagsAsync()
    {
        return await _context.Tags
            .Include(t => t.Collectives)
            .ThenInclude(c => c.ExternalLinks).ToListAsync();
    }
    
    public async Task SaveTagsAsync(IEnumerable<TagModel> tags)
    {
        await _context.Tags.AddRangeAsync(tags);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAllTagsAsync()
    {
        var collectives = _context.Collectives.ToList();
        _context.CollectiveExternalLinks.RemoveRange(_context.CollectiveExternalLinks);
        _context.Collectives.RemoveRange(collectives);
        _context.Tags.RemoveRange(_context.Tags);
        await _context.SaveChangesAsync();
    }
}