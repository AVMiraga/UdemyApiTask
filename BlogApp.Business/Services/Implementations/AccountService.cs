using BlogApp.Business.DTOs.AccountDTOs;
using BlogApp.Business.Exceptions.UserExceptions;
using BlogApp.Business.ExternalServices.Interfaces;
using BlogApp.Business.Services.Interfaces;
using BlogApp.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace BlogApp.Business.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;

        public AccountService(UserManager<AppUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<TokenResponseDTO> Login(LoginDTO loginDto)
        {
            var user = (await _userManager.FindByEmailAsync(loginDto.LoginID) ?? await _userManager.FindByNameAsync(loginDto.LoginID)) ?? throw new UserNotFoundException();
            if (!await _userManager.CheckPasswordAsync(user, loginDto.Password)) throw new UserNotFoundException();

            return _tokenService.CreateToken(user);
        }

        public async Task<IdentityResult> Register(RegisterDTO registerDto)
        {
            AppUser user = new()
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Email = registerDto.Email,
                UserName = registerDto.Username
            };
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            return result;
        }
    }
}