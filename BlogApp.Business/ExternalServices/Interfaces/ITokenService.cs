using BlogApp.Business.DTOs.AccountDTOs;
using BlogApp.Core.Entities;

namespace BlogApp.Business.ExternalServices.Interfaces
{
    public interface ITokenService
    {
        TokenResponseDTO CreateToken(AppUser user, int expireDate = 60);
    }
}