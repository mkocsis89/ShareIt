using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedDataAsync(DataContext context)
        {
            if (context.Posts.Any()) return;

            var activities = new List<Post>
            {
                new Post
                {
                    Title = "Pirate ship",
                    Date = DateTime.UtcNow.AddMonths(-2),
                    Description = "Cool pirate ship",
                     
                },
                new Post
                {
                    Title = "Wizard castle",
                    Date = DateTime.UtcNow.AddMonths(-1),
                    Description = "Enchanting castle"
                },
                new Post
                {
                    Title = "Expert sport car",
                    Date = DateTime.UtcNow.AddMonths(1),
                    Description = "Futuristic car of 2050"
                }
            };

            await context.Posts.AddRangeAsync(activities);
            await context.SaveChangesAsync();
        }
    }
}