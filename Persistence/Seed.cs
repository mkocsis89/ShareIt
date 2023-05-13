using Domain;

namespace Persistence
{
    public sealed class Seed
    {
        public static async Task SeedDataAsync(DataContext context)
        {
            if (context.Posts.Any()) return;

            var posts = new List<Post>
            {
                new Post
                {
                    Title = "Street lamp",
                    Date = DateTime.UtcNow.AddMonths(-2),
                    SpecialParts = new List<Part>{new Part{Name = "Diamond"}}
                },
                new Post
                {
                    Title = "Litter bin",
                    Date = DateTime.UtcNow.AddMonths(-1),
                    SpecialParts = new List<Part>{new Part{Name = "Shield" } }
                },
                new Post
                {
                    Title = "Cake",
                    Date = DateTime.UtcNow.AddMonths(1),
                    SpecialParts = new List<Part>{new Part{Name = "Star" } }
                }
            };

            await context.Posts.AddRangeAsync(posts);
            await context.SaveChangesAsync();
        }
    }
}