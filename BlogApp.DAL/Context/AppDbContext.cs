using BlogApp.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.DAL.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
    }
}
