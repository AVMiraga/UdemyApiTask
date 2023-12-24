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
        private readonly IWebHostEnvironment _env;
        private readonly ICategoryService _categoryService;
        private readonly AppDbContext _context;


        public CategoryController(IWebHostEnvironment env, ICategoryService categoryService,AppDbContext context)
        {
            _env = env;
            _categoryService = categoryService;
            _context = context;
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
            var category = await _categoryService.GetByIdAsync(id);
            return StatusCode(StatusCodes.Status200OK, category);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] CreateCategoryDTO entity)
        {
            if (!ModelState.IsValid) return StatusCode(StatusCodes.Status400BadRequest, ModelState);

            string imgUrl = entity.ImageFile.SaveImage(_env.WebRootPath, "Upload");

            var category = await _categoryService.AddAsync(entity, imgUrl);
            return StatusCode(StatusCodes.Status201Created, category);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateCategoryDTO entity)
        {
            if (!ModelState.IsValid) return StatusCode(StatusCodes.Status400BadRequest, ModelState);

            string? imgUrl = null;
            if (entity.ImageFile != null)
            {
                imgUrl = entity.ImageFile.SaveImage(_env.WebRootPath, "Upload");
            }
            else
            {
                imgUrl = _context.Categories.AsNoTracking().FirstOrDefault(x=>x.Id == entity.Id)?.ImageUrl; 
            }

            var category = await _categoryService.UpdateAsync(entity, imgUrl);
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
