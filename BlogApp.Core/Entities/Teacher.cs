using BlogApp.Core.Entities.Common;

namespace BlogApp.Core.Entities
{
	public class Teacher : BaseAuditableEntity
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public int Age { get; set; }
		public List<Course> Courses { get; set; }
	}
}
