using Mediporta.Models;
using Mediporta.Services;
using Microsoft.AspNetCore.Mvc;

namespace Mediporta.Controllers;
[ApiController]
[Route("api/[controller]")]
public class TagsController : ControllerBase
{
    private readonly TagService _tagService;
    private readonly ILogger<TagsController> _logger;

    public TagsController(TagService tagService, ILogger<TagsController> logger)
    {
        _tagService = tagService;
        _logger = logger;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TagModel>>> GetTagsAsync()
    {
        try
        {
            var tags = await _tagService.FetchTagsAsync();
            _logger.LogInformation("Fetched tags successfully");
            return Ok(tags);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while fetching tags");
            return StatusCode(500, "An error occurred while processing your request");
        }
    }
    
    [HttpGet("paged")]
    public async Task<ActionResult> GetPagedTags([FromQuery] int pageNumber = 1, [FromQuery]int pageSize = 10, [FromQuery]string orderBy = "Name"
        ,[FromQuery]string sortDirection = "asc")
    {
        try
        {
            var tags = await _tagService.GetPagedTagsAsync(pageNumber, pageSize, orderBy, sortDirection);
            _logger.LogInformation("Fetched paged tags successfully");
            return Ok(tags);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while fetching paged tags");
            return StatusCode(500, "An error occurred while processing your request");
        }
    }
}