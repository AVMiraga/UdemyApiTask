using BlogApp.Core.Entities;
using BlogApp.DAL.Context;
using BlogApp.DAL.Repository.Interfaces;

namespace BlogApp.DAL.Repository.Implementations
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
