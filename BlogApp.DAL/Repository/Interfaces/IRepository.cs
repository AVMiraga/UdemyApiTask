using BlogApp.Core.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.DAL.Repository.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> _Table { get; }
        Task<IQueryable<T>> GetAllAsync(params string[] includes);
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        void Update(T entity);
        Task DeleteAsync(T entity);

        Task<int> SaveChanges();
    }
}
