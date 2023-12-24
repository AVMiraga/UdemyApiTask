using BlogApp.Core.Entities.Common;

namespace BlogApp.DAL.Repository.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        void Update(T entity);
        void DeleteAsync(T entity);

        Task<int> SaveChanges();
    }
}
