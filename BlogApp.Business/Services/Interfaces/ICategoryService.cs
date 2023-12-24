using BlogApp.Business.DTOs.CategoryDTOs;
using BlogApp.Core.Entities;

namespace BlogApp.Business.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IQueryable<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
        Task<Category> AddAsync(CreateCategoryDTO entity, string imgUrl);
        Task<Category> UpdateAsync(UpdateCategoryDTO entity, string? imgUrl);
        Task Delete(int Id);
    }
}