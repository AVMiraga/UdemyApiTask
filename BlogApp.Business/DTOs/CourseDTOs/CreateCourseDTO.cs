using BlogApp.Core.Entities;

namespace BlogApp.Business.DTOs.CourseDTOs
{
	public class CreateCourseDTO
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public int TeacherId { get; set; }
	}
}
