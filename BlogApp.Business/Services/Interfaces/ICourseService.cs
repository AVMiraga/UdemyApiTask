using BlogApp.Business.DTOs.CategoryDTOs;
using BlogApp.Business.DTOs.CourseDTOs;
using BlogApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Services.Interfaces
{
	public interface ICourseService
	{
		Task<ICollection<GetCourseDTO>> GetAllAsync();
		Task<Course> GetByIdAsync(int id);
		Task<Course> AddAsync(CreateCourseDTO entity);
		Task<Course> UpdateAsync(UpdateCourseDTO entity);
		Task Delete(int Id);
	}
}
