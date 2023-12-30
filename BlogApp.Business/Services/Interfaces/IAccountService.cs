using BlogApp.Business.DTOs.AccountDTOs;
using Microsoft.AspNetCore.Identity;

namespace BlogApp.Business.Services.Interfaces
{
    public interface IAccountService
    {
        Task<IdentityResult> Register(RegisterDTO registerDto);
        Task<TokenResponseDTO> Login(LoginDTO loginDto);
    }
}