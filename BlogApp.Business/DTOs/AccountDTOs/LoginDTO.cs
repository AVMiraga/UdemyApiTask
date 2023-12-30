using FluentValidation;

namespace BlogApp.Business.DTOs.AccountDTOs
{
    public class LoginDTO
    {
        public required string LoginID { get; set; }
        public required string Password { get; set; }
    }

    public class LoginDTOValidation : AbstractValidator<LoginDTO>
    {
        public LoginDTOValidation()
        {
            RuleFor(x => x.LoginID)
            .NotEmpty()
            .WithMessage("Login ID is required");

            RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password is required");
        }
    }
}