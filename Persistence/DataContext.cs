﻿using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Post> Posts { get; set; }

        public void ClearPosts()
        {
            foreach (var post in Posts)
                Posts.Remove(post);
            SaveChanges();
        }
    }
}
