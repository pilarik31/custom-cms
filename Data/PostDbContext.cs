using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using CustomCMS.Model;

namespace CustomCMS.Data
{
    public class PostDbContext : DbContext
    {
        public PostDbContext(DbContextOptions<PostDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Post> Post{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasData(GetPosts());
            base.OnModelCreating(modelBuilder);
        }


        private List<Post> GetPosts()
        {
            return new List<Post>
            {
                new Post { Id = 1001, Title = "Laptop"},
                new Post { Id = 1002, Title = "Microsoft Office"},
                new Post { Id = 1003, Title = "Lazer Mouse"},
                new Post { Id = 1004, Title = "USB Storage"}
            };
        }
    }
}