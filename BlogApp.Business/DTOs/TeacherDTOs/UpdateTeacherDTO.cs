using BlogApp.Business.DTOs.BaseEntityDTOs;

namespace BlogApp.Business.DTOs.TeacherDTOs
{
	public class UpdateTeacherDTO : BaseDTO
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public int Age { get; set; }
	}
}
