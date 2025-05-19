using Core.Models.AccountsDto;
using Microsoft.AspNetCore.Identity;

namespace Core.Interfaces.Serivces
{
    public interface IUserService
    {
        Task<SignInResult> LoginAsync(LoginDto loginDTO);
        Task LogoutAsync();
        Task<IdentityResult> RegisterAsync(RegisterDto userDTO);
    }
}