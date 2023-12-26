using BlogApp.Business.DTOs.BaseEntityDTOs;
using BlogApp.Business.DTOs.StudentDTOs;
using BlogApp.Business.DTOs.TeacherDTOs;
using BlogApp.Core.Entities;

namespace BlogApp.Business.DTOs.CourseDTOs
{
	public class GetCourseDTO : BaseAuditableEntityDTO
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public int TeacherId { get; set; }
		public GetTeacherDTO Teacher { get; set; }
		public ICollection<GetStudentDTO> Students { get; set; }
	}
}
