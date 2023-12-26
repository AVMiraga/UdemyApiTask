using BlogApp.Business.DTOs.BaseEntityDTOs;
using FluentValidation;

namespace BlogApp.Business.DTOs.CategoryDTOs
{
	public class GetCategoryDTO : BaseAuditableEntityDTO
	{
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
        public GetCategoryDTO ParentCategory { get; set; }
        public ICollection<GetCategoryDTO> ChildCategories { get; set; }
    }

    public class GetCategoryDTOValidation : AbstractValidator<GetCategoryDTO>
    {
        public GetCategoryDTOValidation()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Name must be filled!");
        }
    }
}
