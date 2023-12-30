using System.Text.RegularExpressions;
using FluentValidation;

namespace BlogApp.Business.DTOs.AccountDTOs
{
    public class RegisterDTO
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string ConfirmPassword { get; set; }
    }

    public partial class RegisterDTOValidation : AbstractValidator<RegisterDTO>
    {
        public RegisterDTOValidation()
        {
            RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("First name is required");

            RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("Last name is required");

            RuleFor(x => x.Username)
            .NotEmpty()
            .WithMessage("Username is required");

            RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is required")
            .Must(x =>
            {
                Regex regex = MyRegex();
                return regex.IsMatch(x);
            })
            .WithMessage("Email is not valid");

            RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password is required");

            RuleFor(x => x.ConfirmPassword)
            .NotEmpty()
            .WithMessage("Confirm password is required")
            .Equal(x => x.Password)
            .WithMessage("Password and confirm password must be same");
        }

        [GeneratedRegex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$")]
        private static partial Regex MyRegex();
    }
}