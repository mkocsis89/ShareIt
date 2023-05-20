using Domain;

namespace Persistence
{
    public sealed class Seed
    {
        public static async Task SeedDataAsync(DataContext context, bool isDevelopment)
        {
            if (isDevelopment)
                context.Clear();
            else if (context.Posts.Any())
                return;

            var specialParts = new List<Part>
            {
                { new Part { DesignId = 3001, Name = "Diamond", Color = "White" } },
                { new Part { DesignId = 4003, Name = "Shield", Color = "Black" } },
                { new Part { DesignId = 5008, Name = "Star", Color = "Red"} },
                { new Part { DesignId = 5014, Name = "Star", Color = "Blue"} }
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

            var designIds = context.SpecialParts.Select(p => p.DesignId).ToList();
            var postIds = context.Posts.Select(p => p.Id).ToList();

            var connectors = new List<PostPart>
            {
                new PostPart { PostId = postIds[0], PartId = designIds[0] },
                new PostPart { PostId = postIds[1], PartId = designIds[1] },
                new PostPart { PostId = postIds[2], PartId = designIds[2] },
                new PostPart { PostId = postIds[2], PartId = designIds[3] }
            };

            await context.PostParts.AddRangeAsync(connectors);
            await context.SaveChangesAsync();
        }
    }
}