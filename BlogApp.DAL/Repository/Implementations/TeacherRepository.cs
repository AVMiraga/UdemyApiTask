using BlogApp.Core.Entities;
using BlogApp.DAL.Context;
using BlogApp.DAL.Repository.Interfaces;

namespace BlogApp.DAL.Repository.Implementations
{
	public class TeacherRepository : Repository<Teacher>, IRepository<Teacher>
	{
		public TeacherRepository(AppDbContext context) : base(context)
		{
		}
	}
}
