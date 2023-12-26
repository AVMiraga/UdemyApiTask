using BlogApp.Core.Entities.Common;
using BlogApp.DAL.Context;
using BlogApp.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.DAL.Repository.Implementations
{
    public class Repository<T> : IRepository<T> where T : BaseAuditableEntity, new()
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

        public async Task DeleteAsync(T entity)
        {
            entity.IsDeleted = true;

            _Table.Update(entity);

            //_Table.Remove(entity);
        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            var entities = _Table.Where(x => !x.IsDeleted);
            return entities;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _Table.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        }

        public async Task<int> SaveChanges()
        {
            var result = await _context.SaveChangesAsync();
            return result;
        }

        public void Update(T entity)
        {
            _Table.Update(entity);
        }
    }
}
