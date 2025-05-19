using Core.Models.AccountsDto;
using Core.Interfaces.Serivces;
using DAL.Entities.UserModels;
using Microsoft.AspNetCore.Identity;

namespace Core.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public UserService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> RegisterAsync(RegisterDto userDTO)
        {
            var user = new User { UserName = userDTO.UserName, FirstName = userDTO.FirstName, LastName = userDTO.LastName };

            var result = await _userManager.CreateAsync(user, userDTO.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Guest");
            }

            return result;
        }

        public async Task<SignInResult> LoginAsync(LoginDto loginDTO)
        {
            var user = await _userManager.FindByNameAsync(loginDTO.UserName);
            if (user == null) return SignInResult.Failed;

            return await _signInManager.PasswordSignInAsync(user,
                loginDTO.Password,
                isPersistent: loginDTO.RememberMe,
                lockoutOnFailure: false);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
