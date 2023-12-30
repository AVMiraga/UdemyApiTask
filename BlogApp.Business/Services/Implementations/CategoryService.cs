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
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository rep, IMapper mapper)
        {
            _rep = rep;
            _mapper = mapper;
        }

        public async Task<Category> AddAsync(CreateCategoryDTO entity)
        {
            if(entity == null) throw new CategoryNullException("Null Category Pass Into Argument");

            //Category category = new()
            //{
            //    Name = entity.Name,
            //    ImageUrl = imgUrl
            //};

            if(entity.ParentCategoryId != null) 
                if (await _rep.GetByIdAsync((int)entity.ParentCategoryId) == null) throw new CategoryNotFoundException("Parent Category Not Found");

            var config = new MapperConfiguration(cfg => cfg.CreateMap<CreateCategoryDTO, Category>());

            Category category = config.CreateMapper().Map<Category>(entity);

            await _rep.AddAsync(category);
            await _rep.SaveChanges();
            return category;
        }

        public async Task Delete(int Id)
        {
            if(Id <= 0) throw new NegativeIdException("Id Can't Be Negative Or Zero");

            Category category = await _rep.GetByIdAsync(Id);

            if(category == null) throw new CategoryNotFoundException("Category Not Found");

            await _rep.DeleteAsync(category);
            await _rep.SaveChanges();
        }

        public async Task<ICollection<GetCategoryDTO>> GetAllAsync()
        {
            var categories = await _rep.GetAllAsync(includes: "ChildCategories");

            return _mapper.Map<ICollection<GetCategoryDTO>>(categories);
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            if(id <= 0) throw new NegativeIdException("Id Can't Be Negative Or Zero");

            var category = await _rep.GetByIdAsync(id);

            if (category == null) throw new CategoryNotFoundException("Category Not Found");

            return category;
        }

        public async Task<Category> UpdateAsync(UpdateCategoryDTO entity)
        {
            if(entity == null) throw new CategoryNullException("Null Category Pass Into Argument");

            if (entity.ParentCategoryId != null)
                if (_rep.GetByIdAsync((int)entity.ParentCategoryId) == null) throw new CategoryNotFoundException("Parent Category Not Found");

            var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateCategoryDTO, Category>());

            Category category = config.CreateMapper().Map<Category>(entity);

            _rep.Update(category);
            await _rep.SaveChanges();
            return category;
        }
    }
}
