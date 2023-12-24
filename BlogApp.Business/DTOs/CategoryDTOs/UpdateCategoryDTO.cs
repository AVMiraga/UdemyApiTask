using Microsoft.AspNetCore.Http;

namespace BlogApp.Business.DTOs.CategoryDTOs
{
    public class UpdateCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}
