using Microsoft.AspNetCore.Http;

namespace BlogApp.Business.DTOs.CategoryDTOs
{
    public class CreateCategoryDTO
    {
        public string Name { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
