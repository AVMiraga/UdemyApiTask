using BlogApp.Business.DTOs.CourseDTOs;
using BlogApp.Business.Services.Interfaces;
using BlogApp.DAL.Context;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers
{
		[ApiController]
		[Route("api/[controller]")]
	public class CourseController : Controller
	{
		private readonly IWebHostEnvironment _env;
		private readonly ICourseService _CourseService;
		private readonly AppDbContext _context;


		public CourseController(IWebHostEnvironment env, ICourseService CourseService, AppDbContext context)
		{
			_env = env;
			_CourseService = CourseService;
			_context = context;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var categories = await _CourseService.GetAllAsync();
			return StatusCode(StatusCodes.Status200OK, categories);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var Course = await _CourseService.GetByIdAsync(id);
			return StatusCode(StatusCodes.Status200OK, Course);
		}

		[HttpPost]
		public async Task<IActionResult> Add([FromForm] CreateCourseDTO entity)
		{
			if (!ModelState.IsValid) return StatusCode(StatusCodes.Status400BadRequest, ModelState);

			//string imgUrl = entity.ImageFile.SaveImage(_env.WebRootPath, "Upload");

			var Course = await _CourseService.AddAsync(entity);
			return StatusCode(StatusCodes.Status201Created, Course);
		}

		[HttpPut]
		public async Task<IActionResult> Update([FromForm] UpdateCourseDTO entity)
		{
			if (!ModelState.IsValid) return StatusCode(StatusCodes.Status400BadRequest, ModelState);

			//string? imgUrl = null;
			//if (entity.ImageFile != null)
			//{
			//	//imgUrl = entity.ImageFile.SaveImage(_env.WebRootPath, "Upload");
			//}
			//else
			//{
			//	imgUrl = _context.Categories.AsNoTracking().FirstOrDefault(x => x.Id == entity.Id)?.ImageUrl;
			//}

			var Course = await _CourseService.UpdateAsync(entity);
			return StatusCode(StatusCodes.Status200OK, Course);
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			_CourseService.Delete(id);
			return StatusCode(StatusCodes.Status200OK);
		}
	}
}
