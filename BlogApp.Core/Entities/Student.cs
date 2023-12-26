using BlogApp.Core.Entities.Common;

namespace BlogApp.Core.Entities
{
    public class Student : BaseAuditableEntity
	{
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public List<Course> Courses { get; set; }
    }
}
