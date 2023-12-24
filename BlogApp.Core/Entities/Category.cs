using BlogApp.Core.Entities.Common;

namespace BlogApp.Core.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}
