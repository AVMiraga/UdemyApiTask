using BlogApp.Business.DTOs.BaseEntityDTOs;

namespace BlogApp.Business.DTOs.CourseDTOs
{
	public class UpdateCourseDTO : BaseDTO
	{
		public string Title { get; set; }
		public string Description { get; set; }
	}
}
