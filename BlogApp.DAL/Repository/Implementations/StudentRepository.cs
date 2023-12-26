using BlogApp.Core.Entities;
using BlogApp.DAL.Context;
using BlogApp.DAL.Repository.Interfaces;

namespace BlogApp.DAL.Repository.Implementations
{
	public class StudentRepository : Repository<Student>, IRepository<Student>
	{
		public StudentRepository(AppDbContext context) : base(context)
		{
		}
	}
}
