using BlogApp.DAL.Context;
using BlogApp.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.DAL.Repository.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _Table;

        public Repository(AppDbContext context)
        {
            _context = context;
            _Table = _context.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _Table.AddAsync(entity);
            return entity;
        }

        public void DeleteAsync(T entity)
        {
            _Table.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var entities = await _Table.ToListAsync();
            return entities;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _Table.FindAsync(id);
            return entity;
        }

        public async Task<int> SaveChanges()
        {
            var result = await _context.SaveChangesAsync();
            return result;
        }

        public void UpdateAsync(T entity)
        {
            _Table.Update(entity);
        }
    }
}
