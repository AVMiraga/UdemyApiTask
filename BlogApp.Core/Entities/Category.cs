using BlogApp.Core.Entities.Common;

namespace BlogApp.Core.Entities
{
    public class Category : BaseAuditableEntity
    {
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }
        public ICollection<Category> ChildCategories { get; set; }
    }
}
