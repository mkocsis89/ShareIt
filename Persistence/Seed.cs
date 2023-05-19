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
                { new Part { SerialNumber = 3001, Name = "Diamond", Color = "Blue" } },
                { new Part { SerialNumber = 3002, Name = "Diamond", Color = "Red" } },
                { new Part { SerialNumber = 4003, Name = "Shield", Color = "Black" } },
                { new Part { SerialNumber = 4004, Name = "Shield", Color = "Brown" } },
                { new Part { SerialNumber = 5001, Name = "Star", Color = "Blue"} }
            };

            await context.SpecialParts.AddRangeAsync(specialParts);
            await context.SaveChangesAsync();

            var posts = new List<Post>
            {
                new Post
                {
                    Title = "Street lamp",
                    Date = DateTime.UtcNow.AddMonths(-2),
                    Description = "Inspired by Margaret bridge, Budapest",
                    SpecialParts = new List<Part>
                    {
                        specialParts[0]
                    },
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
                    SpecialParts = new List<Part>
                    {
                        specialParts[2]
                    },
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
                    SpecialParts = new List<Part>
                    {
                        specialParts[4]
                    },
                    Scores = new List<Score> { new Score { Type = ScoreType.Creativity } }
                }
            };

            await context.Posts.AddRangeAsync(posts);
            await context.SaveChangesAsync();
        }
    }
}