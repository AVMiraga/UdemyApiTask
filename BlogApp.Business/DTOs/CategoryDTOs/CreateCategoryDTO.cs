using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace BlogApp.Business.DTOs.CategoryDTOs
{
    public class CreateCategoryDTO
    {
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
    }

    public class CreateCategoryDTOValidation : AbstractValidator<CreateCategoryDTO>
    {
        public CreateCategoryDTOValidation()
        {
            RuleFor(c => c.Name)
                .NotNull()
                .WithMessage("Name must be filled!")
                .MaximumLength(50)
                .WithMessage("Name's length must be lower than 50!");

        }
    }
}
