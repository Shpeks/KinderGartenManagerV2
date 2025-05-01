using Core.DTOs.AccountsModels;
using Microsoft.AspNetCore.Identity;

namespace Core.Interfaces.Serivces
{
    public interface IUserService
    {
        Task<bool> LoginAsync(LoginDTO loginDTO);
        Task LogoutAsync();
        Task<IdentityResult> RegisterAsync(RegisterDTO userDTO);
    }
}