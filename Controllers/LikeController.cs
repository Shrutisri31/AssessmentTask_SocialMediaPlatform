using Microsoft.AspNetCore.Mvc;
using Social_Media.Models;
using Social_Media.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Social_Media.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly LikeService _likeService;

        public LikeController(LikeService likeService)
        {
            _likeService = likeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Like>>> GetLikes()
        {
            return Ok(await _likeService.GetLikesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Like>> GetLike(int id)
        {
            var like = await _likeService.GetLikeByIdAsync(id);

            if (like == null)
            {
                return NotFound();
            }

            return like;
        }

        [HttpPost]
        public async Task<ActionResult<Like>> PostLike(Like like)
        {
            await _likeService.CreateLikeAsync(like);
            return CreatedAtAction("GetLike", new { id = like.LikeID }, like);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLike(int id)
        {
            var like = await _likeService.DeleteLikeAsync(id);

            if (like == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
