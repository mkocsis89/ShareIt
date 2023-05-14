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
                    Description = "Inspired by Margaret bridge, Budapest",
                    SpecialParts = new List<Part>{new Part { Name = "Diamond" } },
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
                    SpecialParts = new List<Part>{new Part {Name = "Shield" } },
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
                    SpecialParts = new List<Part>{new Part {Name = "Star" } },
                    Scores = new List<Score> { new Score { Type = ScoreType.Creativity } }
                }
            };

            await context.Posts.AddRangeAsync(posts);
            await context.SaveChangesAsync();
        }
    }
}