using Social_Media.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Social_Media.Services
{
    public class LikeService
    {
        private readonly ApplicationDbContext _context;

        public LikeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Like>> GetLikesAsync()
        {
            return await _context.Likes.ToListAsync();
        }

        public async Task<Like> GetLikeByIdAsync(int id)
        {
            return await _context.Likes.FindAsync(id);
        }

        public async Task<Like> CreateLikeAsync(Like like)
        {
            _context.Likes.Add(like);
            await _context.SaveChangesAsync();
            return like;
        }

        public async Task<Like> DeleteLikeAsync(int id)
        {
            var like = await _context.Likes.FindAsync(id);
            if (like == null)
            {
                return null;
            }

            _context.Likes.Remove(like);
            await _context.SaveChangesAsync();
            return like;
        }
    }
}
