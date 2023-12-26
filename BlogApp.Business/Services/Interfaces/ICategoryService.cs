using BlogApp.Business.DTOs.CategoryDTOs;
using BlogApp.Core.Entities;

namespace BlogApp.Business.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<ICollection<GetCategoryDTO>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
        Task<Category> AddAsync(CreateCategoryDTO entity);
        Task<Category> UpdateAsync(UpdateCategoryDTO entity);
        Task Delete(int Id);
    }
}