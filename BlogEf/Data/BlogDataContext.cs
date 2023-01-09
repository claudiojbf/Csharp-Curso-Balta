using BlogEf.Data.Mappings;
using BlogEf.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogEf.Data
{
    public class BlogDataContext : DbContext
    {
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Post>? Posts { get; set; }
        // public DbSet<PostTag> PostTags { get; set; }
        public DbSet<User>? Users { get; set; }
        // public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=localhost,1433;Database=BlogEf;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=true");
            // options.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new PostMap());   
        }
    }
}