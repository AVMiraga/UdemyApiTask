using AutoMapper;
using BlogApp.Business.DTOs.CategoryDTOs;
using BlogApp.Business.Exceptions;
using BlogApp.Business.Exceptions.Common;
using BlogApp.Business.Services.Interfaces;
using BlogApp.Core.Entities;
using BlogApp.DAL.Repository.Interfaces;

namespace BlogApp.Business.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _rep;

        public CategoryService(ICategoryRepository rep)
        {
            _rep = rep;
        }

        public async Task<Category> AddAsync(CreateCategoryDTO entity, string imgUrl)
        {
            if(entity == null) throw new CategoryNullException("Null Category Pass Into Argument");

            //Category category = new()
            //{
            //    Name = entity.Name,
            //    ImageUrl = imgUrl
            //};

            var config = new MapperConfiguration(cfg => cfg.CreateMap<CreateCategoryDTO, Category>());

            Category category = config.CreateMapper().Map<Category>(entity);

            category.ImageUrl = imgUrl;


            await _rep.AddAsync(category);
            await _rep.SaveChanges();
            return category;
        }

        public async Task Delete(int Id)
        {
            if(Id <= 0) throw new NegativeIdException("Id Can't Be Negative Or Zero");

            Category category = await _rep.GetByIdAsync(Id) ?? throw new CategoryNotFoundException("Category Not Found");
            _rep.DeleteAsync(category);
            await _rep.SaveChanges();
        }

        public async Task<IQueryable<Category>> GetAllAsync()
        {
            var categories = await _rep.GetAllAsync();

            return categories.AsQueryable();
        }

        public Task<Category> GetByIdAsync(int id)
        {
            if(id <= 0) throw new NegativeIdException("Id Can't Be Negative Or Zero");

            var category = _rep.GetByIdAsync(id);

            return category;
        }

        public async Task<Category> UpdateAsync(UpdateCategoryDTO entity, string? imgUrl)
        {
            if(entity == null) throw new CategoryNullException("Null Category Pass Into Argument");

            var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateCategoryDTO, Category>());

            Category category = config.CreateMapper().Map<Category>(entity);

            if(imgUrl != null) category.ImageUrl = imgUrl;

            _rep.Update(category);
            await _rep.SaveChanges();
            return category;
        }
    }
}
