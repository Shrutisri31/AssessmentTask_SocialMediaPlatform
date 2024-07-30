using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Social_Media;

public class UserEngagementService
{
    private readonly ApplicationDbContext _context;

    public UserEngagementService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<UserEngagementDto>> GetUserEngagementScoresAsync()
    {
        var posts = await _context.Posts.GroupBy(p => p.UserID)
            .Select(g => new { UserID = g.Key, PostCount = g.Count() })
            .ToListAsync();

        var likes = await _context.Likes.GroupBy(l => l.UserID)
            .Select(g => new { UserID = g.Key, LikeCount = g.Count() })
            .ToListAsync();

        var comments = await _context.Comments.GroupBy(c => c.UserID)
            .Select(g => new { UserID = g.Key, CommentCount = g.Count() })
            .ToListAsync();

        var userEngagementScores = from user in await _context.Users.ToListAsync()
                                   join post in posts on user.UserID equals post.UserID into userPosts
                                   join like in likes on user.UserID equals like.UserID into userLikes
                                   join comment in comments on user.UserID equals comment.UserID into userComments
                                   select new UserEngagementDto
                                   {
                                       UserID = user.UserID,
                                       UserName = user.UserName,
                                       EngagementScore = (userPosts.FirstOrDefault()?.PostCount ?? 0) * 5 +
                                                          (userLikes.FirstOrDefault()?.LikeCount ?? 0) * 2 +
                                                          (userComments.FirstOrDefault()?.CommentCount ?? 0) * 3
                                   };

        return userEngagementScores.OrderByDescending(u => u.EngagementScore);
    }
}
