using Microsoft.EntityFrameworkCore;
using Social_Media.Models;

namespace Social_Media.Services;

public class UserService
{
    private readonly ApplicationDbContext _context;

    public UserService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<User> CreateUserAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> UpdateUserAsync(User user)
    {
        _context.Entry(user).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UserExists(user.UserID))
            {
                return null;
            }
            else
            {
                throw;
            }
        }

        return user;
    }

    public async Task<User> DeleteUserAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return null;
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<IEnumerable<UserEngagementDto>> GetUserEngagementScoresAsync()
    {
        var users = await _context.Users.ToListAsync();
        var posts = await _context.Posts.ToListAsync();
        var comments = await _context.Comments.ToListAsync();
        var likes = await _context.Likes.ToListAsync();

        var userEngagementScores = users.Select(user => new UserEngagementDto
        {
            UserID = user.UserID,
            UserName = user.UserName,
            EngagementScore = (posts.Count(p => p.UserID == user.UserID) * 5) +
                              (comments.Count(c => c.UserID == user.UserID) * 3) +
                              (likes.Count(l => l.UserID == user.UserID) * 2)
        }).OrderByDescending(u => u.EngagementScore);

        return userEngagementScores;
    }

    private bool UserExists(int id)
    {
        return _context.Users.Any(e => e.UserID == id);
    }
}

public class UserEngagementDto
{
    public int UserID { get; set; }
    public string UserName { get; set; }
    public int EngagementScore { get; set; }
}