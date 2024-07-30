using Microsoft.AspNetCore.Mvc;
using Social_Media.Models;
using Social_Media.Services;

namespace Social_Media.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeedController : ControllerBase
    {
        private readonly FeedService _feedService;

        public FeedController(FeedService feedService)
        {
            _feedService = feedService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeedDto>>> GetFeed()
        {
            var feed = await _feedService.GetFeedAsync();
            return Ok(feed);
        }
    }
}
