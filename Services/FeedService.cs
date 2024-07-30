using Social_Media.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Social_Media.Services
{
    public class FeedService
    {
        private readonly ApplicationDbContext _context;

        public FeedService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FeedDto>> GetFeedAsync()
        {
            var posts = await _context.Posts.ToListAsync();

            var feed = posts.Select(post => new FeedDto
            {
                PostID = post.PostID,
                Content = post.Content,
                UserName = _context.Users.FirstOrDefault(user => user.UserID == post.UserID)?.UserName,
                Comments = _context.Comments.Where(comment => comment.PostID == post.PostID).Select(comment => comment.Content),
                LikeCount = _context.Likes.Count(like => like.PostID == post.PostID)
            });

            return feed;
        }
    }
}
