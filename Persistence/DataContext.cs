using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public sealed class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Part> SpecialParts { get; set; }

        public void ClearPosts()
        {
            foreach (var post in Posts)
                Posts.Remove(post);
            SaveChanges();
        }
    }
}
