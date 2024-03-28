using Mediporta.Models;
using Mediporta.Services;
using Microsoft.AspNetCore.Mvc;

namespace Mediporta.Controllers;
[ApiController]
[Route("api/[controller]")]
public class TagsController : ControllerBase
{
    private readonly TagService _tagService;

    public TagsController(TagService tagService)
    {
        _tagService = tagService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TagModel>>> GetTagsAsync()
    {
        var tags = await _tagService.FetchTagsAsync();
        return Ok(tags);
    }
}