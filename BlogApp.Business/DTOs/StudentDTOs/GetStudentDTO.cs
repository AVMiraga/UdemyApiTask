using BlogApp.Business.DTOs.BaseEntityDTOs;
using BlogApp.Business.DTOs.CourseDTOs;
using BlogApp.Core.Entities;

namespace BlogApp.Business.DTOs.StudentDTOs
{
	public class GetStudentDTO : BaseAuditableEntityDTO
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public int Age { get; set; }
		public ICollection<GetCourseDTO> Courses { get; set; }
	}
}
