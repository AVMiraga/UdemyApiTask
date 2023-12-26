using BlogApp.Business.DTOs.BaseEntityDTOs;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace BlogApp.Business.DTOs.CategoryDTOs
{
    public class UpdateCategoryDTO : BaseDTO
    {
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
    }
    public class UpdateCategoryDTOValidation : AbstractValidator<UpdateCategoryDTO>
    {
        public UpdateCategoryDTOValidation()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("Id must be filled!");

            RuleFor(c => c.Name)
                .NotNull()
                .WithMessage("Name must be filled!")
                .MaximumLength(50)
                .WithMessage("Name's length must be lower than 50!");

        }
    }
}
