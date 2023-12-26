using AutoMapper;
using BlogApp.Business.DTOs.CourseDTOs;
using BlogApp.Business.Exceptions.Common;
using BlogApp.Business.Exceptions;
using BlogApp.Core.Entities;
using BlogApp.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Business.Services.Interfaces;

namespace BlogApp.Business.Services.Implementations
{
	public class CourseService : ICourseService
	{
		private readonly ICourseRepository _rep;
		private readonly IMapper _mapper;

		public CourseService(ICourseRepository rep, IMapper mapper)
		{
			_rep = rep;
			_mapper = mapper;
		}

		public async Task<Course> AddAsync(CreateCourseDTO entity)
		{
			//if (entity == null) throw new CourseNullException("Null Course Pass Into Argument");

			//Course Course = new()
			//{
			//    Name = entity.Name,
			//    ImageUrl = imgUrl
			//};

			var config = new MapperConfiguration(cfg => cfg.CreateMap<CreateCourseDTO, Course>());

			Course Course = config.CreateMapper().Map<Course>(entity);

			Course.CreatedAt = DateTime.Now;
			Course.UpdatedAt = DateTime.Now;

			//Course.ImageUrl = imgUrl;

			await _rep.AddAsync(Course);
			await _rep.SaveChanges();
			return Course;
		}

		public async Task Delete(int Id)
		{
			if (Id <= 0) throw new NegativeIdException("Id Can't Be Negative Or Zero");

			//Course Course = await _rep.GetByIdAsync(Id) ?? throw new CourseNotFoundException("Course Not Found");
			//await _rep.DeleteAsync(Course);
			await _rep.SaveChanges();
		}

		public async Task<ICollection<GetCourseDTO>> GetAllAsync()
		{
			var categories = await _rep.GetAllAsync();

			return _mapper.Map<ICollection<GetCourseDTO>>(categories);
		}

		public Task<Course> GetByIdAsync(int id)
		{
			if (id <= 0) throw new NegativeIdException("Id Can't Be Negative Or Zero");

			var Course = _rep.GetByIdAsync(id);

			return Course;
		}

		public async Task<Course> UpdateAsync(UpdateCourseDTO entity)
		{
			//if (entity == null) throw new CourseNullException("Null Course Pass Into Argument");

			var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateCourseDTO, Course>());

			Course Course = config.CreateMapper().Map<Course>(entity);

			//if (imgUrl != null) Course.ImageUrl = imgUrl;

			_rep.Update(Course);
			await _rep.SaveChanges();
			return Course;
		}
	}
}
