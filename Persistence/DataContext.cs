using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }

        public async Task<Post> LoadPostAsync(Guid postId, CancellationToken cancellationToken)
        {
            return await Posts
                .Include(post => post.SpecialParts)
                .Include(post => post.Scores)
                .FirstOrDefaultAsync(post => post.Id == postId, cancellationToken);
        }

        public async Task<List<Post>> LoadPostsAsync(CancellationToken cancellationToken)
        {
            return await Posts
                .Include(post => post.SpecialParts)
                .Include(post => post.Scores)
                .ToListAsync(cancellationToken);
        }

        public void ClearPosts()
        {
            foreach (var post in Posts)
                Posts.Remove(post);
            SaveChanges();
        }
    }
}
