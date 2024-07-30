using Social_Media.Models;
using Microsoft.EntityFrameworkCore;

namespace Social_Media.Services;

public class PostService
{
    private readonly ApplicationDbContext _context;

     private readonly List<string> bannedWords = new List<string> { "monolith", "spaghettiCode", "goto", "hack", "architrixs", "quickAndDirty", "cowboy", "yo", "globalVariable", "recursiveHell", "backdoor", "hotfix", "leakyAbstraction", "mockup", "singleton", "silverBullet", "technicalDebt" };


    public PostService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Post>> GetPostsAsync()
    {
        return await _context.Posts.ToListAsync();
    }

    public async Task<Post> GetPostByIdAsync(int id)
    {
        return await _context.Posts.FindAsync(id);
    }

      public async Task CreatePostAsync(Post post)
    {
        if (bannedWords.Any(word => post.Content.Contains(word, StringComparison.OrdinalIgnoreCase)))
        {
            throw new ArgumentException("Content contains inappropriate words.");
        }

        _context.Posts.Add(post);
        await _context.SaveChangesAsync();
    }

     public async Task<Post> UpdatePostAsync(Post post)
    {
        if (bannedWords.Any(word => post.Content.Contains(word, StringComparison.OrdinalIgnoreCase)))
        {
            throw new ArgumentException("Content contains inappropriate words.");
        }

        _context.Entry(post).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return post;
    }


    public async Task<Post> DeletePostAsync(int id)
    {
        var post = await _context.Posts.FindAsync(id);
        if (post == null)
        {
            return null;
        }

        _context.Posts.Remove(post);
        await _context.SaveChangesAsync();

        return post;
    }

    private bool PostExists(int id)
    {
        return _context.Posts.Any(e => e.PostID == id);
    }
}