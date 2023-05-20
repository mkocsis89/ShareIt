using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Persistence
{
    public sealed class DataContext : DbContext
    {
        private readonly ILogger<DataContext> _logger;

        public DataContext(DbContextOptions options, ILogger<DataContext> logger) : base(options)
        {
            _logger = logger;
        }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Part> SpecialParts { get; set; }

        public DbSet<PostPart> PostParts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostPart>()
                .HasKey(pp => new { pp.PostId, pp.PartId });

            modelBuilder.Entity<PostPart>()
                .HasOne(pp => pp.Post)
                .WithMany()
                .HasForeignKey(pp => pp.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PostPart>()
                .HasOne(pp => pp.Part)
                .WithMany()
                .HasForeignKey(pp => pp.PartId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public void Clear()
        {
            foreach (var post in Posts)
                Posts.Remove(post);

            var postsCountRemoved = SaveChanges();
            _logger.LogInformation($"{postsCountRemoved} posts have been purged from db");

            foreach (var part in SpecialParts)
                SpecialParts.Remove(part);
            SaveChanges();
            
            var partsCountRemoved = SaveChanges();
            _logger.LogInformation($"{partsCountRemoved} parts have been purged from db");
        }
    }
}
