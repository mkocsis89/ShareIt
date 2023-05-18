using Domain;

namespace Persistence
{
    public sealed class Seed
    {
        public static async Task SeedDataAsync(DataContext context, bool isDevelopment)
        {
            if (isDevelopment)
                context.ClearPosts();
            else if (context.Posts.Any())
                return;

            var specialParts = new List<Part>
            {
                { new Part { Name = "Diamond" } },
                { new Part { Name = "Shield" } },
                { new Part { Name = "Star" } }
            };

            await context.SpecialParts.AddRangeAsync(specialParts);

            var posts = new List<Post>
            {
                new Post
                {
                    Title = "Street lamp",
                    Date = DateTime.UtcNow.AddMonths(-2),
                    Description = "Inspired by Margaret bridge, Budapest",
                    Scores = new List<Score>
                    {
                        new Score { Type = ScoreType.Creativity },
                        new Score { Type = ScoreType.Uniqueness }
                    }
                },
                new Post
                {
                    Title = "Litter bin",
                    Date = DateTime.UtcNow.AddMonths(-1),
                    Description = "Based on litter bins all across London",
                    Scores = new List<Score>
                    {
                        new Score { Type = ScoreType.Creativity },
                        new Score { Type = ScoreType.Uniqueness }
                    }
                },
                new Post
                {
                    Title = "Cake",
                    Date = DateTime.UtcNow.AddMonths(1),
                    Description = "Happy birthday to brick fans ;)",
                    Scores = new List<Score> { new Score { Type = ScoreType.Creativity } }
                }
            };

            await context.Posts.AddRangeAsync(posts);
            await context.SaveChangesAsync();
        }
    }
}