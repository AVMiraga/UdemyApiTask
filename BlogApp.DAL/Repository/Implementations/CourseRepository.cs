using BlogApp.Core.Entities;
using BlogApp.DAL.Context;
using BlogApp.DAL.Repository.Interfaces;

namespace BlogApp.DAL.Repository.Implementations
{
	public class CourseRepository : Repository<Course>, ICourseRepository
	{
		public CourseRepository(AppDbContext context) : base(context)
		{
		}
	}
}
