using BlogApp.Core.Entities.Common;

namespace BlogApp.DAL.Repository.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IQueryable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        void Update(T entity);
        Task DeleteAsync(T entity);

        Task<int> SaveChanges();
    }
}
