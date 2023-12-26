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

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses {  get; set; }
        public DbSet<Student> Students { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            modelBuilder.Entity<Category>()
                .HasOne(s => s.ParentCategory)
                .WithMany(m => m.ChildCategories)
                .HasForeignKey(c => c.ParentCategoryId);
		}
	}
}
