using Microsoft.AspNetCore.Mvc;
using Social_Media.Models;
using Social_Media.Services;

namespace Social_Media.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UserEngagementController : ControllerBase
{
    private readonly UserEngagementService _userEngagementService;

    public UserEngagementController(UserEngagementService userEngagementService)
    {
        _userEngagementService = userEngagementService;
    }

    [HttpGet("engagement-scores")]
    public async Task<IActionResult> GetUserEngagementScores()
    {
        var engagementScores = await _userEngagementService.GetUserEngagementScoresAsync();
        return Ok(engagementScores);
    }
}
