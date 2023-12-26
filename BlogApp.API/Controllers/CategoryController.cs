using BlogApp.Business.DTOs.CategoryDTOs;
using BlogApp.Business.Extensions;
using BlogApp.Business.Services.Interfaces;
using BlogApp.DAL.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            return StatusCode(StatusCodes.Status200OK, categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var category = await _categoryService.GetByIdAsync(id);

                return StatusCode(StatusCodes.Status200OK, category);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] CreateCategoryDTO entity)
        {
            if (entity == null) return StatusCode(StatusCodes.Status400BadRequest, ModelState);

            var category = await _categoryService.AddAsync(entity);
            return StatusCode(StatusCodes.Status201Created, category);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateCategoryDTO entity)
        {
            if (!ModelState.IsValid) return StatusCode(StatusCodes.Status400BadRequest, ModelState);

            var category = await _categoryService.UpdateAsync(entity);
            return StatusCode(StatusCodes.Status200OK, category);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _categoryService.Delete(id);
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
